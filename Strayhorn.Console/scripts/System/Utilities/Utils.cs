namespace Strayhorn.Utility;

public static class Utils
{
    public static void WriteLineCentered(this string text)
    {
        int windowWidth = Console.WindowWidth;

        int leftMargin = (windowWidth - text.Length) / 2;
        string leftPad = "".PadLeft(leftMargin < 0 ? 0 : leftMargin);
        int remaining = windowWidth - leftPad.Length - text.Length;
        string rightPad = "".PadRight(remaining < 0 ? 0 : remaining);

        Console.WriteLine(leftPad + text + rightPad);
    }

    /// <summary>
    /// 1 => 1st, 22 => 22nd, 113 => 113th, etc
    /// </summary>
    public static string ToOrdinal(this int i)
    {
        if (i > 10 && i.ToString()[^2] == '1') return i.ToString() + "th";

        return i.ToString() + i.ToString()[^1] switch
        {
            '1' => "st",
            '2' => "nd",
            '3' => "rd",
            _ => "th"
        };
    }

    /// <summary>
    /// _thisIsSentenceCase => This is sentence case
    /// </summary>
    public static string SentenceCase(this string s)
    {
        bool firstCharCapped = false;
        string temp = "";

        for (int i = 0; i < s.Length; i++)
        {
            if (!firstCharCapped)
            {
                if (s[i] == '_') temp += string.Empty;
                else
                {
                    temp += s[i].ToString().ToUpper();
                    firstCharCapped = true;
                }
            }

            else if (char.IsUpper(s[i]))
                temp += ' ' + s[i].ToString().ToLower();

            else if (s[i] == '_') temp += ' ';

            else temp += s[i];
        }

        return temp;
    }


    /// <summary>
    /// _thisIsStartCase => This Is Start Case
    /// </summary>
    public static string StartCase(this string s)
    {
        string temp = s[0] == '_' ? string.Empty : s[0].ToString().ToUpper();

        for (int i = 1; i < s.Length; i++)
        {
            if (char.IsUpper(s[i]) && s[i - 1] != ' ') temp += " " + s[i];
            else if (s[i] == '_') temp += " ";
            else temp += s[i];
        }

        return temp;
    }

}