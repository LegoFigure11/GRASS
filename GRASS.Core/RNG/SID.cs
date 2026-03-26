using GRASS.Core.Interfaces;
using PKHeX.Core;
using static GRASS.Core.RNG.Validator;

namespace GRASS.Core.RNG;

public static class SID
{
    public static Task<List<SIDFrame>> Generate(uint seed, uint startAdv, ulong endAdv, SIDConfig cfg)
    {
        return Task.Run(() =>
        {
            List<SIDFrame> results = [];

            if (cfg.UseDelay) seed = LCRNG.Skip(seed, cfg.Delay);
            var outer = LCRNG.Skip(seed, startAdv);

            for (ulong i = startAdv; i <= startAdv + endAdv; i++)
            {
                var s = outer;
                var SID = (ushort)LCRNG.Next16(ref s);

                if (cfg.FiltersEnabled && !CheckSID(SID, cfg))
                {
                    outer = LCRNG.Next(outer);
                    continue;
                }

                results.Add(new SIDFrame()
                {
                    _seed = outer,
                    _advances = (uint)i,
                    _sid = SID,
                });

                outer = LCRNG.Next(outer);
            }

            return results;
        });
    }
}

