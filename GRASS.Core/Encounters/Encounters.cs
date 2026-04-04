using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using GRASS.Core.Enums;
using GRASS.Core.Interfaces;
using PKHeX.Core;

namespace GRASS.Core;

public static class Encounters
{
    private static readonly StaticEncounter[]? FR_Static;
    private static readonly StaticEncounter[]? LG_Static;   
    static Encounters()
    {
        FR_Static = JsonSerializer.Deserialize<StaticEncounter[]>(Utils.GetStringResource("fr_static.json") ?? "{}");
        LG_Static = JsonSerializer.Deserialize<StaticEncounter[]>(Utils.GetStringResource("lg_static.json") ?? "{}");
    }

    public static List<string> GetStaticEncounterSpeciesList(Game game) => game switch
    {
        Game.FireRed   => GetStaticSpeciesList(FR_Static),
        Game.LeafGreen => GetStaticSpeciesList(LG_Static),
        _              => throw new ArgumentOutOfRangeException(nameof(game), game, null)
    };

    private static List<string> GetStaticSpeciesList(StaticEncounter[]? enc)
    {
        List<string> ret = [];
        if (enc is not null)
        {
            foreach (var encounter in enc)
            {
                if (encounter is StaticEncounter e) ret.Add(e.Name);
            }
        }
        return ret;
    }

    private static StaticEncounter[]? GetStaticEncounters(Game game) => game switch
    {
        Game.FireRed   => FR_Static,
        Game.LeafGreen => LG_Static,
        _              => throw new ArgumentOutOfRangeException(nameof(game), game, null)
    };

    public static StaticEncounter GetStaticEncounterFromSpecies(string name, Game game)
    {
        var encs = GetStaticEncounters(game);
        return encs!.First(e => e.Name == name);
    }
}
