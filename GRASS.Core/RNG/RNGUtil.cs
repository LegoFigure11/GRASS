using GRASS.Core.Interfaces;
using PKHeX.Core;

namespace GRASS.Core.RNG;

public static class RNGUtil
{
    extension(LCRNG)
    {
        public static uint Skip(uint seed, uint dist, uint mult = LCRNG.Mult, uint add = LCRNG.Add)
        {
            var (Mult, Add) = GetJumpConstants(dist, mult, add);
            return seed * Mult + Add;
        }

        public static uint SkipBack(uint seed, uint dist)
        {
            return Skip(seed, dist, LCRNG.rMult, LCRNG.rAdd);
        }
    }

    private static (uint Mult, uint Add) GetJumpConstants(uint dist, uint m, uint a)
    {
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

    extension (ushort id)
    {
        public bool IsPalindrome()
        {
            var d1 = (id / 10000) % 10;
            var d2 = (id /  1000) % 10;
          //var d3 = (id /   100) % 10;
            var d4 = (id /    10) % 10;
            var d5 = (id /     1) % 10;

            return d1 == d5 && d2 == d4;
        }

        public bool IsOneNumberOnly() => id % 11111 == 0;
        public bool IsTwoNumbersOnly()
        {
            var bin =
                (1 << ((id / 10000) % 10)) |
                (1 << ((id /  1000) % 10)) |
                (1 << ((id /   100) % 10)) |
                (1 << ((id /    10) % 10)) |
                (1 << ((id /     1) % 10)) ;

            var ct = 0;
            while (bin > 0) {
                bin &= (bin - 1);
                ct++;
            }

            return ct == 2;
        }

        public bool IsSequential()
        {
            var first = id % 10;
            bool up = true;
            bool down = true;
            id /= 10;

            for (var i = 1; i < 5; i++)
            {
                var nextUp = first + i;
                var nextDown = first - i;

                var next = id % 10;
                id /= 10;

                if (up && nextUp != next) up = false;
                if (down && nextDown != next) down = false;

                if (!up && !down) return false;
            }

            return true;
        }

        public bool IsLessThan(uint val) => id < val;
        public bool IsGreaterThan(uint val) => id > val;
    }
}

