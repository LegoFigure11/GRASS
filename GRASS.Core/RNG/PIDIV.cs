using GRASS.Core.Enums;
using PKHeX.Core;

namespace GRASS.Core.RNG;

public static class PIDIV
{
    public static uint GetPID(ref uint seed, Method method = Method.Method1)
    {
        var low = LCRNG.Next16(ref seed);
        if (method.IsMethod3()) _ = LCRNG.Next16(ref seed); // A_CDE
        var high = LCRNG.Next16(ref seed);

        return (high << 16) | low;
    }

    public static byte[] GetIVs(ref uint seed, Method method = Method.Method1)
    {
        var iv1 = LCRNG.Next16(ref seed);
        if (method == Method.Method4) _ = LCRNG.Next16(ref seed); // ABC_E
        var iv2 = LCRNG.Next16(ref seed);

        return [
            (byte)((iv1 >>  0) & 31), // HP
            (byte)((iv1 >>  5) & 31), // Atk
            (byte)((iv1 >> 10) & 31), // Def
            (byte)((iv2 >>  5) & 31), // SpA
            (byte)((iv2 >> 10) & 31), // SpD
            (byte)((iv2 >>  0) & 31), // Spe
        ];
    }

    public static (uint pid, byte[] iv) GetPIDIV(ref uint seed, Method method = Method.Method1)
    {
        var pid = GetPID(ref seed, method);
        if (method.IsMethod2()) _ = LCRNG.Next16(ref seed); // AB_DE
        var iv = GetIVs(ref seed, method);
        return (pid, iv);
    }

    public static (uint pid, byte[] iv) GetPIDIV(ref uint seed, uint nature, Method method = Method.MethodH1)
    {
        uint pid;
        do
        {
            pid = GetPID(ref seed, method);
        } while (method.IsMethodH() && (pid % 25 != nature /* || CuteCharm */));

        if (method.IsMethod2()) _ = LCRNG.Next16(ref seed); // AB_DE

        var iv = GetIVs(ref seed, method);
        return (pid, iv);
    }
}
