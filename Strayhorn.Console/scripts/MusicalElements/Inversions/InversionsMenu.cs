using Strayhorn.Tutorials;
using Strayhorn.Practice;
using MusicTheory.Intervals;
using Strayhorn.Utility;
namespace Strayhorn.Menus;

public class InversionsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public InversionsMenu()
    {
        About = new("About Inversions", () => new TutorialState(new InversionTutorial(), () => new MenuState(this)));
        Selection = About;

        MenuItems = [About,
            new MenuItem("Interval Inversion Practice", () => new PracticeState(() => new InversionPuzzle(PuzzleType.Theory, IInterval.GetAllNoP1().GetRandom()), () => new MenuState(this))),
            Back];
    }
}