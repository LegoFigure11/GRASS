using PKHeX.Core;
using System.Text.Json.Serialization;

namespace GRASS.Core.Interfaces;

public interface IBaseEncounter
{
    ushort _species { get; set; }
    byte Level { get; set; }
    string Location { get; set; }
}

internal interface IDerivedEncounterData
{
    PersonalInfo3 Personal { get; }
    string Name { get; }
}

public class StaticEncounter : IBaseEncounter, IDerivedEncounterData
{
    public ushort _species { get; set; } = 1;
    public byte Level { get; set; } = 5;
    public string Location { get; set; } = string.Empty;

    [JsonIgnore] public string Name => SpeciesName.GetSpeciesName(_species, 2);
    [JsonIgnore] public PersonalInfo3 Personal => PersonalTable.FR[_species];
}
