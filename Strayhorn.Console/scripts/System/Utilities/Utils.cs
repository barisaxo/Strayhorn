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

    public static string ToOrdinal(this int i)
    {
        var temp = i.ToString();
        int dig = i > 9 ? i : i / 10 % 10;
        if (dig == 1) return temp + "th";
        return temp + (i % 10) switch
        {
            1 => "st",
            2 => "nd",
            3 => "rd",
            _ => "th"
        };

    }
}