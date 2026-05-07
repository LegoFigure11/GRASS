using GRASS.Core.Enums;
using GRASS.Core.RNG;
using PKHeX.Core;

namespace GRASS.Core.Interfaces;

internal interface IGeneratorConfig
{
    public bool UseDelay { get; set; }
    public uint Delay { get; set; }

    public bool FiltersEnabled { get; set; }
}

public interface IIVGeneratorConfig
{
    uint[] TargetMinIVs { get; }
    uint[] TargetMaxIVs { get; }
    IVSearchType[] SearchTypes { get; }

}

public class SIDConfig : IGeneratorConfig
{
    public bool UseDelay { get; set; } = true;
    public uint Delay { get; set; } = 0;

    public bool FiltersEnabled { get; set; } = true;
        
    public ushort TID { get; set; } = 0;
    public ushort SID { get; set; } = 0;
    public uint PID { get; set; } = 0;

    public SIDSearchMode SearchMode { get; set; } = SIDSearchMode.SpecificSID;
}

public class StaticConfig : IGeneratorConfig, IIVGeneratorConfig
{
    public Method Method { get; set; } = Method.Method1;

    public bool UseDelay { get; set; } = true;
    public uint Delay { get; set; } = 0;

    public bool FiltersEnabled { get; set; } = true;

    public ushort TID { get; set; } = 0;
    public ushort SID { get; set; } = 0;

    public ushort TSV => (ushort)RNGUtil.GetShinyValue(TID, SID);

    public bool BuggedRoamer { get; set; } = false;

    public ShinyType TargetShiny { get; set; } = ShinyType.Any;
    public Nature TargetNature { get; set; } = Nature.Random;

    public uint[] TargetMinIVs { get; set; } = [0, 0, 0, 0, 0, 0];
    public uint[] TargetMaxIVs { get; set; } = [31, 31, 31, 31, 31, 31];
    public IVSearchType[] SearchTypes { get; set; } = [IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range];

    public StaticEncounter Encounter { get; set; } = new();
}

public class WildConfig : IGeneratorConfig, IIVGeneratorConfig
{
    public Method Method { get; set; } = Method.MethodH1;

    public bool UseDelay { get; set; } = true;
    public uint Delay { get; set; } = 0;

    public bool FiltersEnabled { get; set; } = true;

    public ushort TID { get; set; } = 0;
    public ushort SID { get; set; } = 0;

    public ushort TSV => (ushort)RNGUtil.GetShinyValue(TID, SID);

    public EncounterTableType Type { get; set; } = EncounterTableType.GrassCave;

    public EncounterSlotEncounter[] Table { get; set; } = [];

    public ShinyType TargetShiny { get; set; } = ShinyType.Any;
    public Nature TargetNature { get; set; } = Nature.Random;

    public bool FilterBySpecies { get; set; } = false;
    public ushort TargetSpecies { get; set; } = 0;

    public uint[] TargetMinIVs { get; set; } = [0, 0, 0, 0, 0, 0];
    public uint[] TargetMaxIVs { get; set; } = [31, 31, 31, 31, 31, 31];
    public IVSearchType[] SearchTypes { get; set; } = [IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range];

    public bool RarePID { get; set; } = false;
}


public class FinderConfig : IIVGeneratorConfig
{
    public List<Method> Methods { get; set; } = [Method.MethodH1];
    public Game Game { get; set; } = Game.FireRed;
    public SortedList<uint, HashSet<EncounterTableType>> AcceptableEncounterSlots { get; set; } = [];

    public ushort TID { get; set; } = 0;
    public ushort SID { get; set; } = 0;

    public ushort TSV => (ushort)RNGUtil.GetShinyValue(TID, SID);

    public EncounterTableType Type { get; set; } = EncounterTableType.GrassCave;

    public EncounterSlotEncounter[] Table { get; set; } = [];

    public ShinyType TargetShiny { get; set; } = ShinyType.Any;
    public Nature TargetNature { get; set; } = Nature.Random;

    public bool FilterBySpecies { get; set; } = false;
    public ushort TargetSpecies { get; set; } = 0;

    public uint[] TargetMinIVs { get; set; } = [0, 0, 0, 0, 0, 0];
    public uint[] TargetMaxIVs { get; set; } = [31, 31, 31, 31, 31, 31];
    public IVSearchType[] SearchTypes { get; set; } = [IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range, IVSearchType.Range];

    public bool BuggedRoamer { get; set; } = false;
    public bool RarePID { get; set; } = false;

    public StaticEncounter Encounter { get; set; } = new();
}
