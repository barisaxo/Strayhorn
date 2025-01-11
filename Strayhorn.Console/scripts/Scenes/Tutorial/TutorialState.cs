using Strayhorn.Menus;
using Strayhorn.Systems.State;
using Strayhorn.Systems.Display;

namespace Strayhorn;

public class TutorialState : IState
{
    public ITutorial Tutorial;
    readonly Func<IState> GetState;

    public TutorialState(ITutorial tutorial, Func<IState> getState)
    {
        Tutorial = tutorial;
        GetState = getState;
    }

    static void PrintCommands()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nuse ← → keys to navigate pages, press 'space' to return to menu");
        Console.ResetColor();
    }

    public IState Engage()
    {
        Tutorial.Display.ExecuteDisplay();
        PrintCommands();

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.LeftArrow:
                Tutorial = Tutorial.PrevPage() ?? Tutorial;
                break;

            case ConsoleKey.RightArrow:
                Tutorial = Tutorial.NextPage() ?? Tutorial;
                break;

            case ConsoleKey.Spacebar:
                return GetState();
        }

        return this;
    }
}
