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

    public static bool CheckHeight(uint height, ScaleType target) => target switch
    {
        ScaleType.XXXS     => height == 0,
        ScaleType.XXS      => height is >= 1 and <= 24,
        ScaleType.XS       => height is >= 25 and <= 59,
        ScaleType.S        => height is >= 60 and <= 99,
        ScaleType.M        => height is >= 100 and <= 155,
        ScaleType.L        => height is >= 156 and <= 195,
        ScaleType.XL       => height is >= 196 and <= 230,
        ScaleType.XXL      => height is >= 231 and <= 254,
        ScaleType.XXXL     => height == 255,
        ScaleType.MinOrMax => height is 0 or 255,
        _                  => true,
    };

}
