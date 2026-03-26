using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using PKHeX.Core;

namespace GRASS.Core.RNG;

public static class RNGUtil
{
    extension(LCRNG)
    {
        public static uint Skip(uint seed, uint dist)
        {
            var jumpConstants = GetJumpConstants(dist);
            return seed * jumpConstants.Mult + jumpConstants.Add;
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
}

