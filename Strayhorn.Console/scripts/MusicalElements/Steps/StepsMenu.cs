using Strayhorn.Tutorials;
using Strayhorn.Puzzles;

namespace Strayhorn.Menus;

public class StepsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Level3;
    // readonly MenuItem Level4;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public StepsMenu()
    {
        About = new("About Steps", () => new TutorialState(new StepsTutorialP1(), () => new MenuState(this)));
        Level1 = new("Step puzzle level 1: H & W, White Keys", () => new PuzzleState(() => new StepPuzzle1(), () => new MenuState(this)));
        Level2 = new("Step puzzle level 2: H & W, All Keys", () => new PuzzleState(() => new StepPuzzle2(), () => new MenuState(this)));
        Level3 = new("Step puzzle level 3: H, W, & S, All Keys", () => new PuzzleState(() => new StepPuzzle3(), () => new MenuState(this)));
        Selection = About;
        MenuItems = [About, Level1, Level2, Level3, Back];
    }

}