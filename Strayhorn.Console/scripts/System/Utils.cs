namespace Strayhorn.Utility;

public static class Utils
{
    public static void WriteLineCentered(this string text)
    {
        // Get the width of the console window
        int windowWidth = Console.WindowWidth;

        // Calculate the starting position (left margin) to center the text
        int leftMargin = (windowWidth - text.Length) / 2;

        // Set the cursor position and print the text
        Console.SetCursorPosition(leftMargin, Console.CursorTop);
        Console.WriteLine(text);
    }
}