using System.Text.Json;
using GRASS.Core.Enums;
using GRASS.Core.Interfaces;

namespace GRASS.Core;

public static class Encounters
{
    private static readonly StaticEncounter[]? FR_Static;
    private static readonly StaticEncounter[]? LG_Static;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? FR_GrassCave;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? LG_GrassCave;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? FR_Surf;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? LG_Surf;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? FR_Smash;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? LG_Smash;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? FR_OldRod;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? LG_OldRod;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? FR_GoodRod;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? LG_GoodRod;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? FR_SuperRod;
    private static readonly Dictionary<string, EncounterSlotEncounter[]>? LG_SuperRod;

    static Encounters()
    {
        FR_Static = JsonSerializer.Deserialize<StaticEncounter[]>(Utils.GetStringResource("fr_static.json") ?? "{}");
        LG_Static = JsonSerializer.Deserialize<StaticEncounter[]>(Utils.GetStringResource("lg_static.json") ?? "{}");

        FR_GrassCave = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("fr_grasscave.json") ?? "{}");
        LG_GrassCave = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("lg_grasscave.json") ?? "{}");

        FR_Surf = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("fr_surf.json") ?? "{}");
        LG_Surf = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("lg_surf.json") ?? "{}");

        FR_Smash = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("fr_rocksmash.json") ?? "{}");
        LG_Smash = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("lg_rocksmash.json") ?? "{}");

        FR_OldRod = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("fr_oldrod.json") ?? "{}");
        LG_OldRod = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("lg_oldrod.json") ?? "{}");

        FR_GoodRod = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("fr_goodrod.json") ?? "{}");
        LG_GoodRod = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("lg_goodrod.json") ?? "{}");

        FR_SuperRod = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("fr_superrod.json") ?? "{}");
        LG_SuperRod = JsonSerializer.Deserialize<Dictionary<string, EncounterSlotEncounter[]>>(Utils.GetStringResource("lg_superrod.json") ?? "{}");
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
        EncounterTableType.RockSmash => [.. (game == Game.FireRed ? FR_Smash! : LG_Smash!).Keys],
        EncounterTableType.OldRod    => [.. (game == Game.FireRed ? FR_OldRod! : LG_OldRod!).Keys],
        EncounterTableType.GoodRod   => [.. (game == Game.FireRed ? FR_GoodRod! : LG_GoodRod!).Keys],
        EncounterTableType.SuperRod  => [.. (game == Game.FireRed ? FR_SuperRod! : LG_SuperRod!).Keys],
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

    public static EncounterSlotEncounter[] GetEncounterSlotEncounters(Game game, EncounterTableType type, int index) => type switch
    {
        EncounterTableType.GrassCave => (game == Game.FireRed ? FR_GrassCave! : LG_GrassCave!).Values.ElementAt(index),
        EncounterTableType.Surf      => (game == Game.FireRed ? FR_Surf! : LG_Surf!).Values.ElementAt(index),
        EncounterTableType.RockSmash => (game == Game.FireRed ? FR_Smash! : LG_Smash!).Values.ElementAt(index),
        EncounterTableType.OldRod    => (game == Game.FireRed ? FR_OldRod! : LG_OldRod!).Values.ElementAt(index),
        EncounterTableType.GoodRod   => (game == Game.FireRed ? FR_GoodRod! : LG_GoodRod!).Values.ElementAt(index),
        EncounterTableType.SuperRod  => (game == Game.FireRed ? FR_SuperRod! : LG_SuperRod!).Values.ElementAt(index),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

    public static List<string> GetEncounterAreaSpecies(Game game, EncounterTableType type, int index) =>
        [.. GetEncounterSlotEncounters(game, type, index).Select(e => e.Name).Distinct()];

    public static int GetEncounterSlotIndex(uint rand, EncounterTableType table) => table switch {
        EncounterTableType.Surf      => GetEncounterTableIndexSurf(rand),
        EncounterTableType.RockSmash => GetEncounterTableIndexRockSmash(rand),
        EncounterTableType.OldRod    => GetEncounterTableIndexOldRod(rand),
        EncounterTableType.GoodRod   => GetEncounterTableIndexGoodRod(rand),
        EncounterTableType.SuperRod  => GetEncounterTableIndexSuperRod(rand),
        _                            => GetEncounterTableIndexGrassCave(rand)
    };

    private static int GetEncounterTableIndexGrassCave(uint rand) => rand switch {
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

    private static int GetEncounterTableIndexSurf(uint rand) => rand switch
    {
        >= 99 => 4,
        >= 95 => 3,
        >= 90 => 2,
        >= 60 => 1,
        _     => 0,
    };

    private static int GetEncounterTableIndexRockSmash(uint rand) => rand >= 80 ? 1 : 0;

    private static int GetEncounterTableIndexOldRod(uint rand) => rand >= 70 ? 1 : 0;

    private static int GetEncounterTableIndexGoodRod(uint rand) => rand switch
    {
        >= 80 => 2,
        >= 60 => 1,
        _     => 0,
    };

    private static int GetEncounterTableIndexSuperRod(uint rand) => rand switch
    {
        >= 99 => 4, 
        >= 95 => 3,
        >= 80 => 2,
        >= 40 => 1,
        _     => 0,
    };
}
