using Strayhorn.Tutorials;
using Strayhorn.Practice;
using MusicTheory.Intervals;
using Strayhorn.Utility;

namespace Strayhorn.Menus;

public class IntervalsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public IntervalsMenu()
    {
        About = new("About Intervals", () => new TutorialState(new IntervalTutorial(), () => new MenuState(this)));
        Selection = About;

        MenuItems = [About,
            new MenuItem("Interval Theory Practice: Common Intervals", () => new PracticeState(() => new IntervalPuzzle(PuzzleType.Theory,IInterval.GetCommonNoP1().GetRandom()), () => new MenuState(this))),
            new MenuItem("Interval Theory Practice: All Intervals", () => new PracticeState(() => new IntervalPuzzle(PuzzleType.Theory,IInterval.GetAllNoP1().GetRandom()), () => new MenuState(this))),

            new MenuItem("Interval Aural Practice: All Intervals", () => new PracticeState(() => new IntervalPuzzle(PuzzleType.Aural, IInterval.GetCommonNoP1().GetRandom()), () => new MenuState(this))),
            Back];
    }
}