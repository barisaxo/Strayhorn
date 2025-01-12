using Strayhorn.Practice;
using Strayhorn.Tutorials;

namespace Strayhorn.Menus;

public class InvertedChordsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public InvertedChordsMenu()
    {
        Tutorial = new("InvertedChords Tutorial", () => new TutorialState(new InvertedChordsTutorial(), () => new MenuState(this)));
        Level1 = new("InvertedChord practice: Inverted Triads", () => new PracticeState(() => new InvertedChordPractice1(), () => new MenuState(this)));
        Level2 = new("InvertedChord practice: Inverted 7th Chords", () => new PracticeState(() => new InvertedChordPractice2(), () => new MenuState(this)));
        Selection = Tutorial;
        MenuItems = [Tutorial, Level1, Level2, Back];
    }

}
