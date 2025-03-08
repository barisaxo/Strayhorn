using Strayhorn.Systems.State;

namespace Strayhorn;

public class TutorialState(ITutorial tutorial, Func<IState> getState) : IState
{
    public ITutorial Tutorial = tutorial;
    readonly Func<IState> GetState = getState;
    int index = 0;
    int Length => Tutorial.Displays.Length;

    static void PrintCommands()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nuse ← → keys to navigate pages\npress 'space' to return to menu");
        Console.ResetColor();
    }

    void PrintPageNo()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"(page {index + 1} of {Length})");
        Console.ResetColor();
    }

    public IState Engage()
    {
        Console.Clear();
        PrintPageNo();
        Tutorial.Displays[index].DisplayPage();
        PrintCommands();

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.LeftArrow:
                index -= index == 0 ? 0 : 1;
                break;

            case ConsoleKey.RightArrow:
                index += index + 1 == Length ? 0 : 1;
                break;

            case ConsoleKey.Spacebar:
                return GetState();
        }

        return this;
    }
}
