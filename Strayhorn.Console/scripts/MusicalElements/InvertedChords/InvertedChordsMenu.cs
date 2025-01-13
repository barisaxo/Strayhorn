using Strayhorn.Practice;
using Strayhorn.Tutorials;
using MusicTheory.Chords;
using Strayhorn.Utility;

namespace Strayhorn.Menus;

public class InvertedChordsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;

    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public InvertedChordsMenu()
    {
        Tutorial = new("InvertedChords Tutorial", () => new TutorialState(new InvertedChordsTutorial(), () => new MenuState(this)));
        Selection = Tutorial;

        MenuItems = [Tutorial,
            new MenuItem("InvertedChord Theory practice: Inverted Triads", () => new PracticeState(() => new ChordInversionPuzzle(PuzzleType.Theory, ITriad.GetAll().GetRandom()), () => new MenuState(this))),
            new MenuItem("InvertedChord Theory practice: Inverted 7th Chords", () => new PracticeState( () => new ChordInversionPuzzle(PuzzleType.Theory, I7Chord.GetAll().GetRandom()), () => new MenuState(this))),

            new MenuItem("InvertedChord Aural practice: Inverted Triads", () => new PracticeState(() => new ChordInversionPuzzle(PuzzleType.Aural, ITriad.GetAll().GetRandom()), () => new MenuState(this))),
            new MenuItem("InvertedChord Aural practice: Inverted 7th Chords", () => new PracticeState(  () => new ChordInversionPuzzle(PuzzleType.Aural, I7Chord.GetAll().GetRandom()), () => new MenuState(this))),
            Back];
    }

}
