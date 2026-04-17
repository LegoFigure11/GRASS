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

    public static List<NaturePairFrame> GetNaturePairFrames(uint pid)
    {
        var f = new List<NaturePairFrame>
        {
            new() { _pid = pid },
            new() { _pid = pid ^ 0x80008000 }
        };

        return f;
    }
}

