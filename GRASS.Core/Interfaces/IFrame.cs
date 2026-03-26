namespace GRASS.Core.Interfaces;

internal interface IBasicFrame
{
    string Advances { get; }
    string Seed { get; }
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

