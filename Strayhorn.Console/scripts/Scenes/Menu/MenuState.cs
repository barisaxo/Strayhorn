namespace Strayhorn.Menus;
using Strayhorn.Systems.State;

public class MenuState(IMenu menu) : IState
{
    const char TL = '╔';
    const char TR = '╗';
    const char BL = '╚';
    const char BR = '╝';
    const char H = '═';
    const char V = '║';

    readonly IMenu Menu = menu;

    public IState Engage()
    {
        PrintCommands();
        Logos.PrintScrollWithUD();

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                Menu.ScrollDown();

                break;

            case ConsoleKey.DownArrow:
                Menu.ScrollUp();

                break;

            case ConsoleKey.Enter:

                return Menu.Selection.GetState() ?? this;
        }

        return this;
    }

    void PrintCommands()
    {
        Console.Clear();

        string select = "Select an option:";
        int padding = 6;
        int max = Menu.MenuItems.Max(i => i.Desc.Length) + 3;
        int width = (max > select.Length ? max : select.Length) + padding;
        int windowWidth = Console.WindowWidth;
        int leftMargin = (windowWidth - width) / 2;
        string top = TL + "".PadRight(width, H) + TR;
        string space = V + "".PadRight(width) + V;
        string bottom = BL + "".PadRight(width, H) + BR;
        string leftPad = "".PadLeft(leftMargin);

        Console.WriteLine();
        Console.WriteLine(leftPad + top);
        Console.WriteLine(leftPad + space);
        Console.WriteLine(leftPad + $"{V} {select}".PadRight(width + 1) + V);
        Console.WriteLine(leftPad + space);

        foreach (var item in Menu.MenuItems)
        {
            Console.Write(leftPad + $"{V}");
            if (item == Menu.Selection)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write($" {item.Desc}".PadRight(width));
            Console.ResetColor();
            Console.Write($"{V}\n");
        }

        Console.WriteLine(leftPad + space);
        Console.WriteLine(leftPad + bottom);
        Console.WriteLine();
    }
}

