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

    public static (List<uint> AB, List<uint> A_C) GetPIDSeeds(uint pid)
    {
        List<uint> AB = [];
        List<uint> A_C = [];

        uint targetLow = pid & 0xFFFF;
        uint targetHigh = pid >> 16;

        for (ushort i = 0; i < 0xFFFF; i++)
        {
            var seed = (targetLow << 16) | i; // A
            var B = LCRNG.Next16(ref seed);
            if (B == targetHigh)
            {
                AB.Add(LCRNG.Prev((targetLow << 16) | i));
            }
            var _C = LCRNG.Next16(ref seed);
            if (_C == targetHigh)
            {
                A_C.Add(LCRNG.Prev((targetLow << 16) | i));
            }
        }

        return (AB, A_C);
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

    public static (uint pid, byte[] iv, uint rerolls) GetPIDIV(ref uint seed, uint nature, Method method = Method.MethodH1)
    {
        uint pid, rerolls = 0;
        do
        {
            pid = GetPID(ref seed, method);
            rerolls++;
        } while (method.IsMethodH() && (pid.Nature != nature /* || CuteCharm */));

        if (method.IsMethod2()) _ = LCRNG.Next16(ref seed); // AB_DE

        var iv = GetIVs(ref seed, false, method);
        return (pid, iv, --rerolls);
    }   

    public static (uint pid, byte[] iv, uint rerolls) GetUnownPIDIV(ref uint seed, byte letter, Method method = Method.MethodH1)
    {
        uint pid, rerolls = 0;
        do
        {
            pid = GetPID(ref seed, method);
            rerolls++;
        } while (pid.UnownLetter != letter);

        if (method.IsMethod2()) _ = LCRNG.Next16(ref seed); // AB_DE

        var iv = GetIVs(ref seed, false, method);
        return (pid, iv, --rerolls);
    }

    extension (uint pid)
    {
        internal byte UnownLetter => (byte)((((pid & 0x3000000) >> 18) | ((pid & 0x30000) >> 12) | ((pid & 0x300) >> 6) | (pid & 0x3)) % 0x1C);
        internal byte Nature => (byte)(pid % 25);
        internal byte Ability => (byte)(pid & 1);
        internal byte GenderVal => (byte)(pid & 0xFF);
    }
}
