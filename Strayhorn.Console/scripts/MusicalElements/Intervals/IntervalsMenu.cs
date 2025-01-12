using Strayhorn.Tutorials;
using Strayhorn.Puzzles;

namespace Strayhorn.Menus;

public class IntervalsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public IntervalsMenu()
    {
        About = new("About Intervals", () => new TutorialState(new IntervalTutorial(), () => new MenuState(this)));
        Level1 = new("Common Intervals", () => new PuzzleState(() => new IntervalPuzzle1(), () => new MenuState(this)));
        Level2 = new("All Intervals", () => new PuzzleState(() => new IntervalPuzzle2(), () => new MenuState(this)));
        Selection = About;
        MenuItems = [About, Level1, Level2, Back];
    }
}