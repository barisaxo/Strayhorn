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

}