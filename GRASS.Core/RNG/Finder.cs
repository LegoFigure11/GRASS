using GRASS.Core.Enums;
using GRASS.Core.Interfaces;
using PKHeX.Core;
using System.Diagnostics;

namespace GRASS.Core.RNG;

public static class Finder
{
    public static Task<List<StaticFrame>> Generate(List<uint> seeds, FinderConfig cfg)
    {
        return Task.Run(() =>
        {
            List<StaticFrame> results = [];

            var personal = PersonalTable.FR[cfg.TargetSpecies];

            foreach (var seed in seeds)
            {
                foreach (var method in cfg.Methods)
                {
                    var s = seed;
                    var PID = Recovery.RecoverPIDFromIVSeed(ref s, method);

                    var shinyXor = RNGUtil.GetShinyXOR(PID, cfg.TSV);
                    if (!Validator.CheckIsShiny(shinyXor, cfg.TargetShiny)) continue;

                    var Nature = PID.Nature;
                    if (!Validator.CheckNature(Nature, cfg.TargetNature)) continue;

                    var iv = seed;
                    var IVs = PIDIV.GetIVs(ref iv, cfg.BuggedRoamer, method);
                    if (!Validator.CheckIVs(IVs, cfg)) continue;

                    var Gender = personal.Gender switch
                    {
                        PersonalInfo.RatioMagicGenderless => '-',
                        PersonalInfo.RatioMagicFemale => 'F',
                        PersonalInfo.RatioMagicMale => 'M',
                        _ => PID.GenderVal < personal.Gender ? 'F' : 'M'
                    };

                    if (method.IsMethodH())
                    {
                        uint huntPID;
                        uint nextRNG = LCRNG.Prev16(ref s);
                        uint nextRNG2 = LCRNG.Prev16(ref s);
                        var ct = 0;

                        do
                        {
                            if (nextRNG.Nature == Nature)
                            {
                                var LevelRand = nextRNG2; // Unused for now
                                var SlotRand = LCRNG.Prev16(ref s) % 100;

                                if (cfg.AcceptableEncounterSlots.ContainsKey(SlotRand))
                                {
                                    var areas = Encounters.GetAllAreasForSpeciesAndSlot(cfg.TargetSpecies, SlotRand, cfg.Game);

                                    Debug.WriteLine($"({LCRNG.Prev(s):X8}:{ct:000}) {PID:X8} ({(Nature)Nature}) - {method} - {string.Join("/", IVs)} | {string.Join(", ", areas)}");

                                }

                            }

                            huntPID = (nextRNG << 16) | nextRNG2;
                            nextRNG = LCRNG.Prev16(ref s);
                            nextRNG2 = LCRNG.Prev16(ref s);
                            ct++;
                        } while (huntPID.Nature != Nature);
                    }
                }
            }

            return results;
        });
    }
}
