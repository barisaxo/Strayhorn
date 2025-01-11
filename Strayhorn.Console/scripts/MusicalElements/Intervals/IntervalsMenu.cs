using Strayhorn.Tutorials;
using Strayhorn.Puzzles;

namespace Strayhorn.Menus;

public class IntervalsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem Level1;
    // readonly MenuItem Level2;
    // readonly MenuItem Level3;
    // readonly MenuItem Level4;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public IntervalsMenu()
    {
        About = new("About Intervals", () => new TutorialState(new IntervalTutorial(), () => new MenuState(this)));
        Level1 = new("Interval puzzle level 1: White Keys", () => new PuzzleState(() => new IntervalPuzzle1(), () => new MenuState(this)));
        // Level2 = new("Interval puzzle level 2: Black Keys", () => new PuzzleState(() => new IntervalPuzzle2(), () => new MenuState(this)));
        // Level3 = new("Interval puzzle level 3: Enharmonic White Keys", () => new PuzzleState(() => new IntervalPuzzle3(), () => new MenuState(this)));
        // Level4 = new("Interval puzzle level 4: All Keys", () => new PuzzleState(() => new IntervalPuzzle4(), () => new MenuState(this)));
        Selection = About;
        MenuItems = [About, Level1, /*Level2, Level3, Level4,*/ Back];
    }
}