using GRASS.Core.Interfaces;
using GRASS.Core.Enums;
using PKHeX.Core;

namespace GRASS.Core.RNG;

public static class Recovery
{
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
                    var (_, ivs) = PIDIV.GetPIDIV(ref _ab, false, Method.Method1);
                    var f = new PIDtoIVsFrame()
                    {
                        _seed = ab,
                        _ivs = ivs,
                        _method = Method.Method1,
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
                    var (_, ivs) = PIDIV.GetPIDIV(ref _ab, false, Method.Method2);
                    var f = new PIDtoIVsFrame()
                    {
                        _seed = ab,
                        _ivs = ivs,
                        _method = Method.Method2,
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
                    var (_, ivs) = PIDIV.GetPIDIV(ref _ac, false, Method.Method3);
                    var f = new PIDtoIVsFrame()
                    {
                        _seed = ac,
                        _ivs = ivs,
                        _method = Method.Method3,
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
                    var (_, ivs) = PIDIV.GetPIDIV(ref _ab, false, Method.Method4);
                    var f = new PIDtoIVsFrame()
                    {
                        _seed = ab,
                        _ivs = ivs,
                        _method = Method.Method4,
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

