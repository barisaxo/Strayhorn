using Strayhorn.Practice;
using Strayhorn.Tutorials;

namespace Strayhorn.Menus;

public class SeventhChordsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Level3;
    readonly MenuItem Level4;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public SeventhChordsMenu()
    {
        Tutorial = new("SeventhChords Tutorial", () => new TutorialState(new SeventhChordsTutorial(), () => new MenuState(this)));
        Level1 = new("SeventhChord practice: Major Tonality", () => new PracticeState(() => new SeventhChordPractice1(), () => new MenuState(this)));
        Level2 = new("SeventhChord practice: Minor Tonality", () => new PracticeState(() => new SeventhChordPractice2(), () => new MenuState(this)));
        Level3 = new("SeventhChord practice: Passing Chord Dominants", () => new PracticeState(() => new SeventhChordPractice2(), () => new MenuState(this)));
        Level4 = new("SeventhChord practice: All SeventhChords", () => new PracticeState(() => new SeventhChordPractice3(), () => new MenuState(this)));
        Selection = Tutorial;
        MenuItems = [Tutorial, Level1, Level2, Level3, Level4, Back];
    }

}
