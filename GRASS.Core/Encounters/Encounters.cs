using System.Text.Json;
using GRASS.Core.Enums;
using GRASS.Core.Interfaces;
using PKHeX.Core;

namespace GRASS.Core;

public static class Encounters
{
    private static readonly StaticEncounter[]? FR_Static;
    private static readonly StaticEncounter[]? LG_Static;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? FR_GrassCave;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? LG_GrassCave;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? FR_Surf;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? LG_Surf;
    static Encounters()
    {
        FR_Static = JsonSerializer.Deserialize<StaticEncounter[]>(Utils.GetStringResource("fr_static.json") ?? "{}");
        LG_Static = JsonSerializer.Deserialize<StaticEncounter[]>(Utils.GetStringResource("lg_static.json") ?? "{}");

        FR_GrassCave = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("fr_grasscave.json") ?? "{}");
        LG_GrassCave = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("lg_grasscave.json") ?? "{}");

        FR_Surf = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("fr_surf.json") ?? "{}");
        LG_Surf = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("lg_surf.json") ?? "{}");
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

    public static List<string> GetEncounterAreas(Game game, EncounterTableType type) => type switch
    {
        EncounterTableType.GrassCave => [.. (game == Game.FireRed ? FR_GrassCave! : LG_GrassCave!).Keys],
        EncounterTableType.Surf      => [.. (game == Game.FireRed ? FR_Surf! : LG_Surf!).Keys],
        _ => throw new ArgumentOutOfRangeException(nameof(game), game, null)
    };

    public static EncounterSlotEncounter[] GetEncounterSlotEncounters(Game game, EncounterTableType type, int index) => type switch
    {
        EncounterTableType.GrassCave => (game == Game.FireRed ? FR_GrassCave! : LG_GrassCave!).Values.ElementAt(index),
        EncounterTableType.Surf      => (game == Game.FireRed ? FR_Surf! : LG_Surf!).Values.ElementAt(index),
        _ => throw new ArgumentOutOfRangeException(nameof(game), game, null)
    };

    public static List<string> GetEncounterAreaSpecies(Game game, EncounterTableType type, int index) =>
        [.. GetEncounterSlotEncounters(game, type, index).Select(e => e.Name).Distinct()];

    public static int GetEncounterSlotIndex(int rand, EncounterTableType table) => table switch {
        EncounterTableType.Surf      => GetEncounterTableIndexSurf(rand),
        EncounterTableType.RockSmash => GetEncounterTableIndexRockSmash(rand),
        EncounterTableType.OldRod    => GetEncounterTableIndexOldRod(rand),
        EncounterTableType.GoodRod   => GetEncounterTableIndexGoodRod(rand),
        EncounterTableType.SuperRod  => GetEncounterTableIndexSuperRod(rand),
        _                            => GetEncounterTableIndexGrassCave(rand)
    };

    private static int GetEncounterTableIndexGrassCave(int rand) => rand switch {
        >= 99 => 11,
        >= 98 => 10,
        >= 94 =>  9,
        >= 90 =>  8,
        >= 85 =>  7,
        >= 80 =>  6,
        >= 70 =>  5,
        >= 60 =>  4,
        >= 50 =>  3,
        >= 40 =>  2,
        >= 20 =>  1,
        _     =>  0,
    };

    private static int GetEncounterTableIndexSurf(int rand) => rand switch
    {
        >= 99 => 4,
        >= 95 => 3,
        >= 90 => 2,
        >= 60 => 1,
        _     => 0,
    };

    private static int GetEncounterTableIndexRockSmash(int rand) => rand >= 80 ? 1 : 0;

    private static int GetEncounterTableIndexOldRod(int rand) => rand >= 70 ? 1 : 0;

    private static int GetEncounterTableIndexGoodRod(int rand) => rand switch
    {
        >= 80 => 2,
        >= 60 => 1,
        _     => 0,
    };

    private static int GetEncounterTableIndexSuperRod(int rand) => rand switch
    {
        >= 99 => 4, 
        >= 95 => 3,
        >= 80 => 2,
        >= 40 => 1,
        _     => 0,
    };
}
