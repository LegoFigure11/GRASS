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

            var (AB, A_C) = GetPIDSeeds(pid);
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

    public static Task<List<IVsToPIDFrame>> GetIVsToPID(byte hp, byte atk, byte def, byte spa, byte spd, byte spe)
    {
        return Task.Run(() =>
        {
            List<IVsToPIDFrame> results = [];

            var (_123, _4) = GetIVSeeds(hp, atk, def, spa, spd, spe);

            Method[] methods = [Method.Method1, Method.Method2, Method.Method3];

            var max = Math.Max(_123.Count, _4.Count);

            for (var i = 0; i < max; i++)
            {
                try
                {
                    foreach (var method in methods)
                    {
                        var ivseed = _123[i];
                        var tmp = ivseed;
                        var prevs = 2;
                        if (method is Method.Method2 or Method.Method3) prevs = 3;

                        for (var j = 0; j < prevs; j++) tmp = LCRNG.Prev(tmp);

                        var copy = tmp;
                        var copyxor = copy ^ 0x80008000;
                        var tmpx = copyxor;
                        var (pid, ivs) = PIDIV.GetPIDIV(ref copy, false, method);
                        var (xpid, xivs) = PIDIV.GetPIDIV(ref copyxor, false, method);

                        if (ivs[0] == hp && ivs[1] == atk && ivs[2] == def && ivs[3] == spa && ivs[4] == spd && ivs[5] == spe)
                        {
                            var f = new IVsToPIDFrame()
                            {
                                _seed = tmp,
                                _method = method,
                                _pid = pid
                            };

                            results.Add(f);
                        }

                        if (xivs[0] == hp && xivs[1] == atk && xivs[2] == def && xivs[3] == spa && xivs[4] == spd && xivs[5] == spe)
                        {
                            var f = new IVsToPIDFrame()
                            {
                                _seed = tmpx,
                                _method = method,
                                _pid = xpid
                            };

                            results.Add(f);
                        }
                    }
                }
                catch
                {
                    // Ignored
                }

                try
                {
                    var ivseed = _4[i];
                    var tmp = ivseed;
                    var prevs = 2;

                    for (var j = 0; j < prevs; j++) tmp = LCRNG.Prev(tmp);

                    var copy = tmp;
                    var copyxor = copy ^ 0x80008000;
                    var tmpx = copyxor;
                    var (pid, ivs) = PIDIV.GetPIDIV(ref copy, false, Method.Method4);
                    var (xpid, xivs) = PIDIV.GetPIDIV(ref copyxor, false, Method.Method4);

                    if (ivs[0] == hp && ivs[1] == atk && ivs[2] == def && ivs[3] == spa && ivs[4] == spd && ivs[5] == spe)
                    {
                        var f = new IVsToPIDFrame()
                        {
                            _seed = tmp,
                            _method = Method.Method4,
                            _pid = pid
                        };

                        results.Add(f);
                    }

                    if (xivs[0] == hp && xivs[1] == atk && xivs[2] == def && xivs[3] == spa && xivs[4] == spd && xivs[5] == spe)
                    {
                        var f = new IVsToPIDFrame()
                        {
                            _seed = tmpx,
                            _method = Method.Method4,
                            _pid = xpid
                        };

                        results.Add(f);
                    }
                }
                catch
                {
                    // Ignored
                }
            }

            return results;
        });
    }

    private static (List<uint> AB, List<uint> A_C) GetPIDSeeds(uint pid)
    {
        Span<uint> ab = stackalloc uint[LCRNG.MaxCountSeedsIV];
        Span<uint> ac = stackalloc uint[LCRNG.MaxCountSeedsIV];

        var first = (pid & 0xFFFF) << 16;
        var second = pid >> 16 << 16;

        var ct1 = LCRNGReversal.GetSeeds(ab, first, second);
        var ct2 = LCRNGReversalSkip.GetSeeds(ac, first, second);

        var AB = new List<uint>();
        var A_C = new List<uint>();

        for (var i = 0; i < ct1; i++) AB.Add(ab[i]);
        for (var i = 0; i < ct2; i++) A_C.Add(ac[i]);
        return (AB, A_C);
    }

    private static (List<uint> _123, List<uint> _4) GetIVSeeds(byte hp, byte atk, byte def, byte spa, byte spd, byte spe)
    {
        Span<uint> cd = stackalloc uint[LCRNG.MaxCountSeedsIV];
        Span<uint> de = stackalloc uint[LCRNG.MaxCountSeedsIV];

        var first = (uint)((hp << 0) | (atk << 5) | (def << 10)) << 16;
        var second = (uint)((spe << 0) | (spa << 5) | (spd << 10)) << 16;

        var ct1 = LCRNGReversal.GetSeedsIVs(cd, first, second);
        var ct2 = LCRNGReversalSkip.GetSeedsIVs(de, first, second);

        var _123 = new List<uint>();
        var _4 = new List<uint>();

        for (var i = 0; i < ct1; i++) _123.Add(cd[i]);
        for (var i = 0; i < ct2; i++) _4.Add(de[i]);

        return (_123, _4);
    }
}

