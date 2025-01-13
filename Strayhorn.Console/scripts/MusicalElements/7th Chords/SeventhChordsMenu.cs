using Strayhorn.Practice;
using Strayhorn.Tutorials;
using MusicTheory.Chords;
using Strayhorn.Utility;

namespace Strayhorn.Menus;

public class SeventhChordsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;

    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public SeventhChordsMenu()
    {
        Tutorial = new("7th Chords Tutorial", () => new TutorialState(new SeventhChordsTutorial(), () => new MenuState(this)));
        Selection = Tutorial;

        MenuItems = [Tutorial,
            new MenuItem("7th Chord Theory practice: Major Tonality", () => new PracticeState(() => new SeventhChordPuzzle(PuzzleType.Theory, I7Chord.MajorTonality().GetRandom()), () => new MenuState(this))),
            new MenuItem("7th Chord Theory practice: Minor Tonality", () => new PracticeState(() => new SeventhChordPuzzle(PuzzleType.Theory,I7Chord.MinorTonality().GetRandom()), () => new MenuState(this))),
            new MenuItem("7th Chord Theory practice: Passing Chord Dominants", () => new PracticeState(() => new SeventhChordPuzzle(PuzzleType.Theory,I7Chord.PassingChordDominant().GetRandom()), () => new MenuState(this))),
            new MenuItem("7th Chord Theory practice: All 7th Chords", () => new PracticeState(() => new SeventhChordPuzzle(PuzzleType.Theory,I7Chord.GetAll().GetRandom()), () => new MenuState(this))),

            new MenuItem("7th Chord Aural practice: Major Tonality", () => new PracticeState(() => new SeventhChordPuzzle(PuzzleType.Aural, I7Chord.MajorTonality().GetRandom()), () => new MenuState(this))),
            new MenuItem("7th Chord Aural practice: Minor Tonality", () => new PracticeState(() => new SeventhChordPuzzle(PuzzleType.Aural, I7Chord.MinorTonality().GetRandom()), () => new MenuState(this))),
            new MenuItem("7th Chord Aural practice: Passing Chord Dominants", () => new PracticeState(() => new SeventhChordPuzzle(PuzzleType.Aural, I7Chord.PassingChordDominant().GetRandom()), () => new MenuState(this))),
            new MenuItem("7th Chord Aural practice: All 7th Chords", () => new PracticeState(() => new SeventhChordPuzzle(PuzzleType.Aural, I7Chord.GetAll().GetRandom()), () => new MenuState(this))),
            Back];
    }

}
