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

            foreach (var seed in seeds)
            {
                foreach (var method in cfg.Methods)
                {
                    var PID = Recovery.RecoverPIDFromIVSeed(seed, method);
                    var Nature = PID.Nature;

                    if (!Validator.CheckNature(Nature, cfg.TargetNature)) continue;

                    if (method.IsMethodH())
                    {
                        uint huntPID, rerolls = 0xFFFFFFFF; // (uint)-1;
                        uint hunt = seed;
                        do
                        {
                            huntPID = Recovery.RecoverPIDFromIVSeed(ref hunt, method);
                            rerolls++;
                        } while (huntPID.Nature != Nature);

                        var LevelRand = LCRNG.Prev16(ref hunt);
                        var SlotRand = LCRNG.Prev16(ref hunt) % 100;

                        if (!cfg.AcceptableEncounterSlots.ContainsKey(SlotRand)) continue;

                        var areas = Encounters.GetAllAreasForSpeciesAndSlot(cfg.TargetSpecies, SlotRand, cfg.Game);

                        Debug.WriteLine($"{PID:X8} ({(Nature)Nature}) - {method} | {string.Join(", ", areas)}");
                        _ = true;
                    }
                }
            }

            return results;
        });
    }
}
