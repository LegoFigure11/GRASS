using PKHeX.Core;

namespace GRASS.Core.RNG;

public static class Back16
{
    public static uint GetLast16(uint seed, bool returnCurrent = false)
    {
        if (!returnCurrent)
            if (seed >> 16 == 0) seed = LCRNG.Prev(seed);

        while (seed >> 16 != 0)
            seed = LCRNG.Prev(seed);

        return seed;
    }

    public static Task<(uint Advance, uint Seed)> FindMaxAdvance(uint seed, ushort count = 1)
    {
        return Task.Run(() =>
        {
            var prev = seed;
            var flag = true;

            for (ushort i = 0; i < count; i++)
            {
                prev = GetLast16(prev, flag);
                flag = false;
            }

            return (LCRNG.GetDistance(prev, seed), prev);
        });
    }

    public static Task<uint> CountSeedsInRange(uint seed, uint max = 2000000)
    {
        return Task.Run(() =>
        {
            var i = 0u;
            var prev = seed;
            var ct = 0u;
            while (i < max)
            {
                prev = GetLast16(prev);
                i = LCRNG.GetDistance(prev, seed);
                ct++;
            }

            return (ct == 0) ? 0 : ct - 1;
        });
    }

    public static Task<List<ushort>> GetSeedsByCount(uint seed, uint count)
    {
        return Task.Run(() =>
        {
            List<ushort> seeds = [];

            var tmp = seed;
            var flag = true;

            while (seeds.Count < count)
            {
                tmp = GetLast16(tmp, flag);
                flag = false;
                seeds.Add((ushort)tmp);
            }

            return seeds;
        });
    }

    public static Task<List<ushort>> GetSeedsByAdvances(uint seed, uint adv)
    {
        return Task.Run(() =>
        {
            List<ushort> seeds = [];

            var prev = seed;
            var flag = true;
            var i = 0u;

            while (i < adv)
            {
                prev = GetLast16(prev, flag);
                i = LCRNG.GetDistance(prev, seed);
                if (i >= adv) break;
                flag = false;
                seeds.Add((ushort)prev);
            }

            return seeds;
        });
    }
}

