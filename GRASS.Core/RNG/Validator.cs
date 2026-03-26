using GRASS.Core.Enums;
using GRASS.Core.Interfaces;
using PKHeX.Core;

namespace GRASS.Core.RNG;
internal static class Validator
{
    public static bool CheckSID(uint sid, SIDConfig config) => config.SearchMode switch
    {
        SIDSearchMode.FromPID => CheckIsShiny(RNGUtil.GetShinyXOR(config.PID, RNGUtil.GetShinyValue(config.TID, sid)), ShinyType.Either),
        _                     => sid == config.SID,
    };

    public static bool CheckIsShiny(uint xor, ShinyType target) => target switch
    {
        ShinyType.Square => xor == 0,
        ShinyType.Star   => xor is > 0 and < 8,
        ShinyType.Either => xor < 8,
        ShinyType.None   => xor >= 8,
        _                => true,
    };


    public static bool CheckEC(uint ec, bool rare) => !rare || (rare && ec % 100 == 0);

    public static bool CheckNature(string nature, Nature target) => nature == "Sync" || target == Nature.Random || nature == Util.Natures[(int)target];
}
