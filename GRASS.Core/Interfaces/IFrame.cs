using GRASS.Core.RNG;
using PKHeX.Core;

namespace GRASS.Core.Interfaces;

internal interface IBasicFrame
{
    string Advances { get; }
    string Seed { get; }
}

internal interface IIVFrame
{
    byte HP { get; }
    byte Atk { get; }
    byte Def { get; }
    byte SpA { get; }
    byte SpD { get; }
    byte Spe { get; }
}

public class SIDFrame : IBasicFrame
{
    internal uint _advances { get; set; } = 0;
    internal uint _seed { get; set; } = 0;
    internal ushort _sid { get; set; } = 0;

    public string Advances => $"{_advances:N0}";
    public string Seed => $"{_seed:X8}";
    public string SID => $"{_sid:00000}";
}

public class StaticFrame : IBasicFrame, IIVFrame
{
    internal uint _advances { get; set; } = 0;
    internal uint _seed { get; set; } = 0;
    internal uint _pid { get; set; } = 0;
    internal byte[] _ivs { get; set; } = [];
    internal byte _nature => _pid.Nature;
    internal ushort _shinyXor { get; set; } = 0;

    public string Advances => $"{_advances:N0}";
    public string PID => $"{_pid:X8}";

    public string Shiny => $"{(_shinyXor == 0 ? "Square" : (_shinyXor < 8 ? "Star" : "No"))}";

    public byte Ability => _pid.Ability;
    public string Nature => Validator.Natures[_nature];

    public byte HP => _ivs[0];
    public byte Atk => _ivs[1];
    public byte Def => _ivs[2];
    public byte SpA => _ivs[3];
    public byte SpD => _ivs[4];
    public byte Spe => _ivs[5];

    public char Gender { get; set; } = '-';

    private int _HPBitValType => ((HP & 1) >> 0) | ((Atk & 1) << 1) | ((Def & 1) << 2) | ((Spe & 1) << 3) | ((SpA & 1) << 4) | ((SpD & 1) << 5);
    private int _HPBitValPower => ((HP & 2) >> 1) | ((Atk & 2) >> 0) | ((Def & 2) << 1) | ((Spe & 2) << 2) | ((SpA & 2) << 3) | ((SpD & 2) << 4);
    public string Hidden => $"{Validator.Types[(15 * _HPBitValType / 63) + 1]}";
    public int Power => ((40 * _HPBitValPower) / 63) + 30;

    public string Seed => $"{_seed:X8}";
}   

