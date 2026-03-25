using PKHeX.Core;

namespace GRASS.Core.KeyboardEntry;

internal static class Keyboards
{
    private static readonly string[] EN_Upper = [
        "ABCDEF .",
        "GHIJKL ,",
        "MNOPQRS ",
        "TUVWXYZ ",
    ];
    private static readonly string[] EN_Lower = [
        "abcdef .",
        "ghijkl ,",
        "mnopqrs ",
        "tuvwxyz ",
    ];
    private static readonly string[] EN_Other = [
        "01234 ",
        "56789 ",
        "!?♂♀/-",
        "…“”‘’ ",
    ];

    private static readonly string[] FR_Upper = [
        "ABCDEFGH.",
        "IJKLMNOP,",
        "QRSTUVWX ",
        "YZ  -    "
    ];

    private static readonly string[] FR_Lower = [
        "abcdefgh.",
        "ijklmnop,",
        "qrstuvwx ",
        "yz  -    ",
    ];

    private static readonly string[] FR_Other = [
        "01234 ",
        "56789 ",
        "!?♂♀/ ",
        "…«»‘’ ",
    ];

    private static readonly string[] DE_Upper = [
        "ABCDEFGH.",
        "IJKLMNOP,",
        "QRSTUVWX ",
        "YZ  ÄÖÜ  "
    ];

    private static readonly string[] DE_Lower = [
        "abcdefgh.",
        "ijklmnop,",
        "qrstuvwx ",
        "yz  äöü  ",
    ];

    private static readonly string[] DE_Other = [
        "01234 ",
        "56789 ",
        "!?♂♀/-",
        "…“”‘’ ",
    ];

    private static readonly string[] IT_Upper = EN_Upper;
    private static readonly string[] IT_Lower = EN_Lower;
    private static readonly string[] IT_Other = EN_Other;

    private static readonly string[] ES_Upper = EN_Upper;
    private static readonly string[] ES_Lower = EN_Lower;
    private static readonly string[] ES_Other = EN_Other;

    private static readonly string[] JP_Hiragana = [
        "あいうえお なにぬねの やゆよ！？  ",
        "かきくけこ はひふへほ わをん \u3099\u309A ",
        "さしすせそ まみむめも ゃゅょっー  ",
        "たちつてと らりるれろ ぁぃぅぇぉ  ",
    ];

    private static readonly string[] JP_Katakana = [
        "アイウエオ ナニヌネノ ヤユヨ！？  ",
        "カキクケコ ハヒフヘホ ワヲン \u3099\u309A ",
        "サシスセソ マミムメモ ャュョッー  ",
        "タチツテト ラリルレロ ァィゥェォ  "
    ];

    private static readonly string[] JP_Latin = [
        "ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳ",
        "ＴＵＶＷＸＹＺ ０１２３４５６７８９ ",
        "ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓ",
        "ｔｕｖｗｘｙｚ 。・⋯『』「」／♂♀ "
    ];



    public static string[][] GetKeyboard(LanguageID lang = LanguageID.English) => lang switch
    {
        LanguageID.Japanese => [JP_Hiragana, JP_Katakana, JP_Latin],
        LanguageID.English => [EN_Upper, EN_Lower, EN_Other],
        LanguageID.French => [FR_Upper, FR_Lower, FR_Other],
        LanguageID.Italian => [IT_Upper, IT_Lower, IT_Other],
        LanguageID.German => [DE_Upper, DE_Lower, DE_Other],
        LanguageID.Spanish => [ES_Upper, ES_Lower, ES_Other],
        _ => throw new NotImplementedException(),
    };
}
