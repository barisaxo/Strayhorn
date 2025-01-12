using Strayhorn.Tutorials;
using Strayhorn.Puzzles;

namespace Strayhorn.Menus;

public class StepsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Level3;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public StepsMenu()
    {
        Tutorial = new("About Steps", () => new TutorialState(new StepsTutorial(), () => new MenuState(this)));
        Level1 = new("Step practice: H & W, White Keys", () => new PuzzleState(() => new StepPuzzle1(), () => new MenuState(this)));
        Level2 = new("Step practice: H & W, All Keys", () => new PuzzleState(() => new StepPuzzle2(), () => new MenuState(this)));
        Level3 = new("Step practice: H, W, & S, All Keys", () => new PuzzleState(() => new StepPuzzle3(), () => new MenuState(this)));
        Selection = Tutorial;
        MenuItems = [Tutorial, Level1, Level2, Level3, Back];
    }

}
