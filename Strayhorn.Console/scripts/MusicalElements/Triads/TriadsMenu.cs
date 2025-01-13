using Strayhorn.Practice;
using Strayhorn.Tutorials;
using MusicTheory.Chords;
using Strayhorn.Utility;

namespace Strayhorn.Menus;

public class TriadsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public TriadsMenu()
    {
        Tutorial = new("Triads Tutorial", () => new TutorialState(new TriadsTutorial(), () => new MenuState(this)));
        Selection = Tutorial;

        MenuItems = [Tutorial,
            new MenuItem("Triad Theory practice: Common Triads", () => new PracticeState(() => new TriadPuzzle(PuzzleType.Theory, ITriad.GetCommon().GetRandom()), () => new MenuState(this))),
            new MenuItem("Triad Theory practice: Theoretical Triads", () => new PracticeState(() => new TriadPuzzle(PuzzleType.Theory, ITriad.GetTheoretical().GetRandom()), () => new MenuState(this))),
            new MenuItem("Triad Theory practice: All Triads", () => new PracticeState(() => new TriadPuzzle(PuzzleType.Theory, ITriad.GetAll().GetRandom()), () => new MenuState(this))),

            new MenuItem("Triad Aural practice: Common Triads", () => new PracticeState(() => new TriadPuzzle(PuzzleType.Aural, ITriad.GetCommon().GetRandom()), () => new MenuState(this))),
            new MenuItem("Triad Aural practice: Theoretical Triads", () => new PracticeState(() => new TriadPuzzle(PuzzleType.Aural, ITriad.GetTheoretical().GetRandom()), () => new MenuState(this))),
            new MenuItem("Triad Aural practice: All Triads", () => new PracticeState(() => new TriadPuzzle(PuzzleType.Aural, ITriad.GetAll().GetRandom()), () => new MenuState(this))),

            Back];
    }

}


