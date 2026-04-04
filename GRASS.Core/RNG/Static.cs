using GRASS.Core.Interfaces;
using PKHeX.Core;
using static GRASS.Core.RNG.Validator;

namespace GRASS.Core.RNG;

public static class Static
{
    public static Task<List<StaticFrame>> Generate(uint seed, uint startAdv, ulong endAdv, StaticConfig cfg)
    {
        return Task.Run(() =>
        {
            List<StaticFrame> results = [];

            if (cfg.UseDelay) seed = LCRNG.Skip(seed, cfg.Delay);
            var outer = LCRNG.Skip(seed, startAdv);

            for (ulong i = startAdv; i <= startAdv + endAdv; i++)
            {
                var s = outer;
                var (PID, IVs) = PIDIV.GetPIDIV(ref s, cfg.BuggedRoamer, cfg.Method);

                var shinyXor = RNGUtil.GetShinyXOR(PID, cfg.TSV);

                if (cfg.FiltersEnabled &&
                    (
                        !CheckIsShiny(shinyXor, cfg.TargetShiny)   ||
                        !CheckNature(PID.Nature, cfg.TargetNature) ||
                        !CheckIVs(IVs, cfg)
                    )
                )
                {
                    outer = LCRNG.Next(outer);
                    continue;
                }

                var Gender = cfg.Encounter.Personal.Gender switch
                {
                    PersonalInfo.RatioMagicGenderless => '-',
                    PersonalInfo.RatioMagicFemale => 'F',
                    PersonalInfo.RatioMagicMale => 'M',
                    _ => 'S',
                };

                if (Gender == 'S')
                {
                    var gv = PID.GenderVal;
                    Gender = gv < cfg.Encounter.Personal.Gender ? 'F' : 'M';
                }

                results.Add(new StaticFrame()
                {
                    _seed = outer,
                    _advances = (uint)i,
                    _pid = PID,
                    _ivs = IVs,
                    _shinyXor = (ushort)shinyXor,
                    Gender = Gender,
                    Ability = $"{Abilities[cfg.Encounter.Personal.GetAbilityAtIndex(PID.Ability)]} ({PID.Ability})",
                });

                outer = LCRNG.Next(outer);
            }

            return results;
        });
    }
}
