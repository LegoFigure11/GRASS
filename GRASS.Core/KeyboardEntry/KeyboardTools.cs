using System.Text;
using PKHeX.Core;
using SysBot.Base;
using static GRASS.Core.KeyboardEntry.Keyboards;

namespace GRASS.Core.KeyboardEntry;

public static class KeyboardTools
{
    private static LanguageID _lang = LanguageID.English;
    private static string[][] _keyboard = GetKeyboard(_lang);
    public static void SetKeyboard(LanguageID lang)
    {
        _keyboard = GetKeyboard(lang);
        _lang = lang;
    }

    private static bool CheckKeyExists(char k) => _keyboard.Any(kbd => kbd.Any(m => m.Contains(k)));
    private static bool CheckKeyExistsOnKeyboard(char k, int mode)
    {
        return _keyboard[mode].Any(row => row.Contains(k));
    }

    private static int GetKeyRow(char c, int kbd, int first = 0)
    {
        var k = _keyboard[kbd];

        if (k[first].Contains(c)) return first;

        var i = 0;
        for (; i < k.Length; i++)
        {
            if (k[i].Contains(c)) break;
        }

        return i;
    }

    private static (int col, int row) GetKeyColRow(char c, int kbd, int row, int first = 0)
    {
        var k = _keyboard[kbd];

        var check = row;
        var forward = 0;
        var backward = 0;
        var found = false;
        for (var i = 0; i < k.Length; i++)
        {
            if (k[check][first] == c) {
                forward = check;
                found = true;
                break;
            }
            check = (check + 1) % k.Length;
        }

        check = row;
        for (var i = k.Length - 1; i > 0; i--)
        {
            if (k[check][first] == c)
            {
                backward = check;
                found = true;
                break;
            }
            check = ((check - 1 + k.Length) % k.Length);
        }

        if (found) return (Math.Abs(row - forward) < Math.Abs(row - backward)) ? (first, forward) : (first, backward); 

        return (k[row].IndexOf(c), row);

    }

    private static bool CheckLength(string text) => _lang switch
    {
        LanguageID.Japanese => text.Length <= 5,
        _                   => text.Length <= 7,
    };

    public static string NormalizeInput(string text)
    {
        // Seperate out Dakuten/Handakuten
        text = text.Normalize(NormalizationForm.FormD);

        // Convert halfwidth to ｆｕｌｌｗｉｄｔｈ
        string ret = string.Empty;
        foreach (char c in text)
        {
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')) ret += c.ToFullWidth();
            else ret += c;
        }
        return ret;
    }

    internal static char ToFullWidth(this char c) => (char)(c + 0xFEE0); 

    public static List<SwitchButton> GetInputsForName(string text)
    {
        if (!CheckLength(text)) throw new ArgumentException($"Name {text} is too long for the connected game language!");

        // JPN-only text conversions
        if (_lang == LanguageID.Japanese) text = NormalizeInput(text);

        if (string.IsNullOrEmpty(text)) throw new ArgumentException($"No OT Name provided!");

        // start at 0, 0 on Upper
        var kbdindex = 0;
        var row = 0;
        var col = 0;

        List<SwitchButton> inputs = [];

        foreach (var c in text)
        {
            if (!CheckKeyExists(c)) throw new ArgumentException($"Character: {c} does not exist in the specified keyboard set!");

            var i = 0;
            while (!CheckKeyExistsOnKeyboard(c, kbdindex))
            {
                kbdindex = (kbdindex + 1) % _keyboard.Length;
                i++;

                // If switching through a keyboard with less cols, set to the max col
                col = Math.Min(col, _keyboard[kbdindex][row].Length - 1);
            }

            for (var j = 0; j < i; j++)
            {
                inputs.Add(SwitchButton.MINUS);
            }

            // Now on the correct keyboard
            var tmpRow = GetKeyRow(c, kbdindex, row);
            var (keyCol, keyRow) = GetKeyColRow(c, kbdindex, tmpRow, col);

            var rowDir = keyRow >= row ? SwitchButton.DDOWN : SwitchButton.DUP;
            var colDir = keyCol >= col ? SwitchButton.DRIGHT : SwitchButton.DLEFT;

            var rowDiff = Math.Abs(keyRow - row);
            var colDiff = Math.Abs(keyCol - col);

            if (rowDiff > _keyboard[kbdindex].Length / 2)
            {
                rowDiff = _keyboard[kbdindex].Length - rowDiff;
                rowDir = rowDir == SwitchButton.DDOWN ? SwitchButton.DUP : SwitchButton.DDOWN;
            }

            var extra = false;
            var extraDir = SwitchButton.DRIGHT;
            if (colDiff > (_keyboard[kbdindex][row].Length / 2) + 1)
            {
                colDiff = _keyboard[kbdindex][row].Length - colDiff;
                colDir = colDir == SwitchButton.DRIGHT ? SwitchButton.DLEFT : SwitchButton.DRIGHT;
                extra = true;
                extraDir = colDir;
            }


            for (var x = 0; x < rowDiff; x++)
            {
                inputs.Add(rowDir);
            }

            for (var y = 0; y < colDiff; y++)
            {
                inputs.Add(colDir);
            }

            if (extra) inputs.Add(extraDir);

            row = keyRow;
            col = keyCol;

            inputs.Add(SwitchButton.A);
        }

        inputs.Add(SwitchButton.PLUS);
        inputs.Add(SwitchButton.A);

        return inputs;
    }
}
