namespace Strayhorn.Menus;
using Strayhorn.Utility;

public interface IMenu
{
    public IMenuItem[] MenuItems { get; }
    // public IMenu NextMenu(MenuItem[] menuItems);
}

public interface IMenuItem// : IMenuItem
{
    public string ID { get; }
    public string Desc { get; }
    public Action Execute { get; }
    public IMenu NextMenu { get; }
}

public static class MenuSystems
{
    const char TL = '╔';
    const char TR = '╗';
    const char BL = '╚';
    const char BR = '╝';
    const char H = '═';
    const char V = '║';

    // public static void ActivateMenu(this IMenu menu)
    // {
    //     if (arg == null)
    //     {
    //         menu.MenuItems.PrintMenu();
    //         ActivateMenu(menu, Console.ReadLine());
    //         return;
    //     }

    //     MenuItem? item = null;

    //     try
    //     {
    //         item = menu.MenuItems.Single(i => i.ID == arg);
    //     }
    //     catch
    //     {
    //         menu.MenuItems.PrintMenu();
    //         Console.WriteLine("You have selected: " + arg);
    //         Console.WriteLine("Please select a valid option");
    //         ActivateMenu(menu, Console.ReadLine());
    //         return;
    //     }

    //     item.Execute();
    // }

    public static void PrintCommands(this IMenuItem[] items)
    {
        Console.Clear();
        string select = "Select a topic:";
        int padding = 6;
        int max = items.Max(i => i.Desc.Length) + 3;
        int width = (max > select.Length ? max : select.Length) + padding;

        string top = TL + "".PadRight(width, H) + TR;
        string space = V + "".PadRight(width) + V;
        string bottom = BL + "".PadRight(width, H) + BR;

        Console.WriteLine("");
        Utils.WriteLineCentered(top);
        Utils.WriteLineCentered(space);
        Utils.WriteLineCentered($"{V} {select}".PadRight(width + 1) + V);
        Utils.WriteLineCentered(space);

        foreach (var item in items)
        {
            if (item.ID == "X" || item.ID == "x") Utils.WriteLineCentered(space);
            Utils.WriteLineCentered($"{V}  {item.ID}: {item.Desc}".PadRight(width + 1) + V);
            if (item.ID == "0") Utils.WriteLineCentered(space);
        }

        Utils.WriteLineCentered(space);
        Utils.WriteLineCentered(bottom);
        Console.WriteLine("");
    }

    static void TestInput()
    {
        string? input;
        do
        {
            if ((input = Console.ReadLine()) == null) continue;
            if (input.Contains("-q"))
            {
                Console.WriteLine("(goodbye)");
                return;
            }
            if (input.Contains("-h")) Console.WriteLine("(Help dialog)");
        } while (true);
    }

}