using GRASS.Core.Interfaces;
using PKHeX.Core;
using static GRASS.Core.RNG.Validator;

namespace GRASS.Core.RNG;

public static class Wild
{
    public static Task<List<WildFrame>> Generate(uint seed, uint startAdv, ulong endAdv, WildConfig cfg)
    {
        return Task.Run(() =>
        {
            List<WildFrame> results = [];

            if (cfg.UseDelay) seed = LCRNG.Skip(seed, cfg.Delay);
            var outer = LCRNG.Skip(seed, startAdv);

            for (ulong i = startAdv; i <= startAdv + endAdv; i++)
            {
                var s = outer;

                // if (rse && rocksmash) rand 2880 >= (rate * 16)
                // if (feebas) rand 100 < 50
                // else if (lead is magnetpull or static) && rand 2 == 0 && modifiedslots.Length >= 0
                //     encounterslot = modifiedslots[rand modifiedslots.Length]
                // else

                var SlotRand = LCRNG.Next16(ref s) % 100;
                var SlotIndex = Encounters.GetEncounterSlotIndex(SlotRand, cfg.Type);

                var Encounter = cfg.Table[SlotIndex];
                if (cfg.FiltersEnabled && cfg.FilterBySpecies && cfg.TargetSpecies != Encounter._species)
                {
                    outer = LCRNG.Next(outer);
                    continue;
                }

                var LevelDelta = Encounter.MaxLevel - Encounter.MinLevel + 1;
                var LevelRand = (byte)(LCRNG.Next16(ref s) % LevelDelta);
                // if (pressure)
                // var pressureRand = rand 2
                // if (pressureRand == 0) level = max;
                // else LevelRand = LevelRand == 0 : LevelRand : LevelRand - 1;
                var Level = Encounter.MinLevel + LevelRand;

                // if (sync && rand 2 == 0) nature = lead
                var Nature = LCRNG.Next16(ref s) % 25;
                if (cfg.FiltersEnabled && !CheckNature((byte)Nature, cfg.TargetNature))
                {
                    outer = LCRNG.Next(outer);
                    continue;
                }

                var (PID, IVs, Rerolls) = PIDIV.GetPIDIV(ref s, Nature, cfg.Method);

                var shinyXor = RNGUtil.GetShinyXOR(PID, cfg.TSV);

                if (cfg.FiltersEnabled &&
                    (
                        !CheckIsShiny(shinyXor, cfg.TargetShiny) ||
                        !CheckIVs(IVs, cfg)
                    )
                )
                {
                    outer = LCRNG.Next(outer);
                    continue;
                }

                var Gender = Encounter.Personal.Gender switch
                {
                    PersonalInfo.RatioMagicGenderless => '-',
                    PersonalInfo.RatioMagicFemale => 'F',
                    PersonalInfo.RatioMagicMale => 'M',
                    _ => PID.GenderVal < Encounter.Personal.Gender ? 'F' : 'M'
                };

                results.Add(new WildFrame()
                {
                    _seed = outer,
                    _advances = (uint)i,
                    _pid = PID,
                    _ivs = IVs,
                    _shinyXor = (ushort)shinyXor,
                    _species = Encounter._species,
                    _slotIndex = (byte)SlotIndex,
                    Level = (byte)Level,
                    Gender = Gender,
                    Ability = $"{Abilities[Encounter.Personal.GetAbilityAtIndex(PID.Ability)]} ({PID.Ability})",
                    Rerolls = Rerolls,
                });

                outer = LCRNG.Next(outer);
            }

            return results;
        });
    }
}
