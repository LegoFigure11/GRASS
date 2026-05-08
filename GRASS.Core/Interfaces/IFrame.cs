using GRASS.Core.Enums;
using GRASS.Core.RNG;
using PKHeX.Core;

namespace GRASS.Core.Interfaces;

internal interface IAdvancesFrame
{
    string Advances { get; }
}

public interface ISeedFrame
{
    string Seed { get; }
}

public interface IPIDFrame
{
    string PID { get; }
}

public interface IIVFrame
{
    byte HP { get; }
    byte Atk { get; }
    byte Def { get; }
    byte SpA { get; }
    byte SpD { get; }
    byte Spe { get; }
}

public interface IShinyFrame
{
    string Shiny { get; }
}

public interface ILocations
{
    string Locations { get; }
}

public interface IHiddenPowerFrame
{
    string Hidden { get; }
    int Power { get; }
}

public class SIDFrame : IAdvancesFrame, ISeedFrame
{
    internal uint _advances { get; set; } = 0;
    internal uint _seed { get; set; } = 0;
    internal ushort _sid { get; set; } = 0;

    public string Advances => $"{_advances:N0}";
    public string Seed => $"{_seed:X8}";
    public string SID => $"{_sid:00000}";
}

public class StaticFrame : IAdvancesFrame, ISeedFrame, IIVFrame, IShinyFrame, IHiddenPowerFrame, IPIDFrame
{
    internal uint _advances { get; set; } = 0;
    internal uint _seed { get; set; } = 0;
    internal uint _pid { get; set; } = 0;
    internal byte[] _ivs { get; set; } = [];
    internal byte _nature => _pid.Nature;
    internal ushort _shinyXor { get; set; } = 0;

    public string Advances => $"{_advances:N0}";
    public string PID => $"{_pid:X8}";

    public string Shiny => $"{(_shinyXor == 0 ? "Square" : (_shinyXor < 8 ? $"Star ({_shinyXor})" : "No"))}";

    public string Ability { get; set; } = string.Empty;
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

public class WildFrame : IAdvancesFrame, ISeedFrame, IIVFrame, IShinyFrame, IHiddenPowerFrame, IPIDFrame
{
    internal uint _advances { get; set; } = 0;
    internal uint _seed { get; set; } = 0;
    internal uint _pid { get; set; } = 0;
    internal byte[] _ivs { get; set; } = [];
    internal byte _nature => _pid.Nature;
    internal ushort _shinyXor { get; set; } = 0;
    internal byte _slotIndex { get; set; } = 0;
    internal ushort _species { get; set; } = 0;

    public string Advances => $"{_advances:N0}";
    public string Species => $"[{_slotIndex:00}] {SpeciesName.GetSpeciesName(_species, 2)}";
    public byte Level { get; set; } = 0;
    public string PID => $"{_pid:X8}";

    public uint Rerolls { get; set; } = 0;
    public string Shiny => $"{(_shinyXor == 0 ? "Square" : (_shinyXor < 8 ? $"Star ({_shinyXor})" : "No"))}";

    public string Ability { get; set; } = string.Empty;
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

public class FinderFrame : IIVFrame, ISeedFrame, IHiddenPowerFrame, IShinyFrame, ILocations, IPIDFrame
{
    internal uint _seed { get; set; } = 0;
    internal uint _pid { get; set; } = 0;
    internal byte[] _ivs { get; set; } = [];
    internal byte _nature => _pid.Nature;
    internal ushort _shinyXor { get; set; } = 0;
    internal ushort _species { get; set; } = 0;
    internal Method _method { get; set; } = Enums.Method.Method1;
    public string Method => _method.ToString();
    public string Locations { get; set; } = string.Empty;

    public string Species => $"{SpeciesName.GetSpeciesName(_species, 2)}";

    public string PID => $"{_pid:X8}";

    public uint Rerolls { get; set; } = 0;
    public string Shiny => $"{(_shinyXor == 0 ? "Square" : (_shinyXor < 8 ? $"Star ({_shinyXor})" : "No"))}";

    public string Ability { get; set; } = string.Empty;
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

public class PIDtoIVsFrame : ISeedFrame, IIVFrame, IHiddenPowerFrame
{
    internal uint _seed { get; set; } = 0;
    internal Method _method { get; set; } = Enums.Method.Method1;
    internal byte[] _ivs { get; set; } = [];

    public string Seed => $"{_seed:X8}";
    public string Method => _method.ToString();
    public byte HP => _ivs[0];
    public byte Atk => _ivs[1];
    public byte Def => _ivs[2];
    public byte SpA => _ivs[3];
    public byte SpD => _ivs[4];
    public byte Spe => _ivs[5];

    private int _HPBitValType => ((HP & 1) >> 0) | ((Atk & 1) << 1) | ((Def & 1) << 2) | ((Spe & 1) << 3) | ((SpA & 1) << 4) | ((SpD & 1) << 5);
    private int _HPBitValPower => ((HP & 2) >> 1) | ((Atk & 2) >> 0) | ((Def & 2) << 1) | ((Spe & 2) << 2) | ((SpA & 2) << 3) | ((SpD & 2) << 4);
    public string Hidden => $"{Validator.Types[(15 * _HPBitValType / 63) + 1]}";
    public int Power => ((40 * _HPBitValPower) / 63) + 30;
}

public class IVsToPIDFrame : ISeedFrame, IPIDFrame
{
    internal uint _seed { get; set; } = 0;
    internal Method _method { get; set; } = Enums.Method.Method1;
    internal uint _pid { get; set; } = 0;

    public string Seed => $"{_seed:X8}";
    public string Method => _method.ToString();

    public string PID => $"{_pid:X8}";

    internal byte _nature => _pid.Nature;
    public string Nature => Validator.Natures[_nature];
    public int Ability => _pid.Ability;
    internal byte GenderVal => _pid.GenderVal;

    public char _18th => GenderVal <= 30 ? 'F' : 'M';
    public char _14th => GenderVal <= 63 ? 'F' : 'M';
    public char _12th => GenderVal <= 126 ? 'F' : 'M';
    public char _34th => GenderVal <= 190 ? 'F' : 'M';
}

public class NaturePairFrame : IPIDFrame
{
    internal uint _pid { get; set; } = 0;
    internal byte _nature => _pid.Nature;

    public string PID => $"{_pid:X8}";
    public string Nature => Validator.Natures[_nature];
}

