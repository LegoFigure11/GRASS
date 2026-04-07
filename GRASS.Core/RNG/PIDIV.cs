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

    public static byte[] GetIVs(ref uint seed, bool RoamerBug = false, Method method = Method.Method1)
    {
        var iv1 = RoamerBug ? LCRNG.Next16(ref seed) & 0xFF : LCRNG.Next16(ref seed);
        if (method.IsMethod4()) _ = LCRNG.Next16(ref seed); // ABC_E
        var iv2 = RoamerBug ? 0 : LCRNG.Next16(ref seed);

        return [
            (byte)((iv1 >>  0) & 31), // HP
            (byte)((iv1 >>  5) & 31), // Atk
            (byte)((iv1 >> 10) & 31), // Def
            (byte)((iv2 >>  5) & 31), // SpA
            (byte)((iv2 >> 10) & 31), // SpD
            (byte)((iv2 >>  0) & 31), // Spe
        ];
    }

    public static (uint pid, byte[] iv) GetPIDIV(ref uint seed, bool buggedRoamer, Method method = Method.Method1)
    {
        var pid = GetPID(ref seed, method);
        if (method.IsMethod2()) _ = LCRNG.Next16(ref seed); // AB_DE
        var iv = GetIVs(ref seed, buggedRoamer, method);
        return (pid, iv);
    }

    public static (uint pid, byte[] iv) GetPIDIV(ref uint seed, uint nature, Method method = Method.MethodH1)
    {
        uint pid;
        do
        {
            pid = GetPID(ref seed, method);
        } while (method.IsMethodH() && (pid.Nature != nature /* || CuteCharm */));

        if (method.IsMethod2()) _ = LCRNG.Next16(ref seed); // AB_DE

        var iv = GetIVs(ref seed, false, method);
        return (pid, iv);
    }   

    public static (uint pid, byte[] iv) GetUnownPIDIV(ref uint seed, byte letter, Method method = Method.MethodH1)
    {
        uint pid;
        do
        {
            pid = GetPID(ref seed, method);
        } while (pid.UnownLetter != letter);

        if (method.IsMethod2()) _ = LCRNG.Next16(ref seed); // AB_DE

        var iv = GetIVs(ref seed, false, method);
        return (pid, iv);
    }

    extension (uint pid)
    {
        internal byte UnownLetter => (byte)((((pid & 0x3000000) >> 18) | ((pid & 0x30000) >> 12) | ((pid & 0x300) >> 6) | (pid & 0x3)) % 0x1C);
        internal byte Nature => (byte)(pid % 25);
        internal byte Ability => (byte)(pid & 1);
        internal byte GenderVal => (byte)(pid & 0xFF);
    }
}
