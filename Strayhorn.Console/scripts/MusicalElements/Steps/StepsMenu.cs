using Strayhorn.Tutorials;
using Strayhorn.Practice;
using Strayhorn.Utility;
using MusicTheory.Intervals;

namespace Strayhorn.Menus;

public class StepsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public StepsMenu()
    {
        Tutorial = new("About Steps", () => new TutorialState(new StepsTutorial(), () => new MenuState(this)));
        Selection = Tutorial;

        MenuItems = [
            Tutorial,
            new MenuItem("Step Theory practice: Half", () => new PracticeState(() => new StepPuzzle(PuzzleType.Theory, new H()), () => new MenuState(this))),
            new MenuItem("Step Theory practice: Whole", () => new PracticeState(() => new StepPuzzle(PuzzleType.Theory, new W()), () => new MenuState(this))),
            new MenuItem("Step Theory practice: Half & Whole", () => new PracticeState(() => new StepPuzzle(PuzzleType.Theory, IStep.GetHW().GetRandom()), () => new MenuState(this))),
            new MenuItem("Step Theory practice: Skip", () => new PracticeState(() => new StepPuzzle(PuzzleType.Theory, new S()), () => new MenuState(this))),
            new MenuItem("Step Theory practice: Half, Whole, & Skip", () => new PracticeState(() => new StepPuzzle(PuzzleType.Theory, IStep.GetAll().GetRandom()), () => new MenuState(this))),

            new MenuItem("Step Aural practice: Half & Whole", () => new PracticeState(() => new StepPuzzle(PuzzleType.Aural, IStep.GetHW().GetRandom()), () => new MenuState(this))),
            new MenuItem("Step Aural practice: Half, Whole, & Skip", () => new PracticeState(() => new StepPuzzle(PuzzleType.Aural, IStep.GetAll().GetRandom()), () => new MenuState(this))),
            Back
            ];
    }

}
