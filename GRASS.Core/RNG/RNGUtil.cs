using GRASS.Core.Interfaces;
using PKHeX.Core;

namespace GRASS.Core.RNG;

public static class RNGUtil
{
    extension(LCRNG)
    {
        public static uint Skip(uint seed, uint dist)
        {
            var (Mult, Add) = GetJumpConstants(dist);
            return seed * Mult + Add;
        }
    }

    private static (uint Mult, uint Add) GetJumpConstants(uint dist)
    {
        var m = LCRNG.Mult;
        var a = LCRNG.Add;

        var outM = 1u;
        var outA = 0u;

        while (dist > 0)
        {
            if ((dist & 1) == 1)
            {
                outM *= m;
                outA = outA * m + a;
            }

            a *= (m + 1);
            m *= m;

            dist >>= 1;
        }

        return (outM, outA);
    }

    public static uint GetShinyValue(uint x, uint y) => x ^ y;
    public static uint GetShinyValue(uint x) => (x >> 16) ^ (x & 0xFFFF);

    public static uint GetShinyXOR(uint pid, uint tsv) => GetShinyValue(GetShinyValue(pid), tsv);

    public static Task<List<PIDtoIVsFrame>> GetPIDtoIVs(uint pid)
    {
        return Task.Run(() =>
        {
            List<PIDtoIVsFrame> results = [];

            var (AB, A_C) = PIDIV.GetPIDSeeds(pid);
            var max = Math.Max(AB.Count, A_C.Count);
            for (var i = 0; i < max; i++)
            {
                try
                {
                    var ab = AB.ElementAt(i);
                    var _ab = ab; // Copy
                    var (_, ivs) = PIDIV.GetPIDIV(ref _ab, false, Enums.Method.Method1);
                    var f = new PIDtoIVsFrame()
                    {
                        _seed = ab,
                        _ivs = ivs,
                        _method = Enums.Method.Method1,
                    };
                    results.Add(f);
                }
                catch
                {
                    // Ignored
                }

                try
                {
                    var ab = AB.ElementAt(i);
                    var _ab = ab; // Copy
                    var (_, ivs) = PIDIV.GetPIDIV(ref _ab, false, Enums.Method.Method2);
                    var f = new PIDtoIVsFrame()
                    {
                        _seed = ab,
                        _ivs = ivs,
                        _method = Enums.Method.Method2,
                    };
                    results.Add(f);
                }
                catch
                {
                    // Ignored
                }

                try
                {
                    var ac = A_C.ElementAt(i);
                    var _ac = ac; // Copy
                    var (_, ivs) = PIDIV.GetPIDIV(ref _ac, false, Enums.Method.Method3);
                    var f = new PIDtoIVsFrame()
                    {
                        _seed = ac,
                        _ivs = ivs,
                        _method = Enums.Method.Method3,
                    };
                    results.Add(f);
                }
                catch
                {
                    // Ignored
                }

                try
                {
                    var ab = AB.ElementAt(i);
                    var _ab = ab; // Copy
                    var (_, ivs) = PIDIV.GetPIDIV(ref _ab, false, Enums.Method.Method4);
                    var f = new PIDtoIVsFrame()
                    {
                        _seed = ab,
                        _ivs = ivs,
                        _method = Enums.Method.Method4,
                    };
                    results.Add(f);
                }
                catch
                {
                    // Ignored
                }
            }

            return results;
        });
    }
}

