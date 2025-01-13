using Strayhorn.Tutorials;
using Strayhorn.Practice;
using MusicTheory.Notes;
using Strayhorn.Utility;

namespace Strayhorn.Menus;

public class NotesMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public NotesMenu()
    {
        About = new("Notes Tutorial", () => new TutorialState(new NotesTutorial(), () => new MenuState(this)));
        Selection = About;

        MenuItems = [About,
            new MenuItem("Note Theory practice: Natural Notes", () => new PracticeState( () => new NotePuzzle(PuzzleType.Theory, IPitchClass.GetNatural().GetRandom()), () => new MenuState(this))),
            new MenuItem("Note Theory practice: Black Keys", () => new PracticeState(() => new NotePuzzle(PuzzleType.Theory, IPitchClass.GetBlack().GetRandom()), () => new MenuState(this))),
            new MenuItem("Note Theory practice: Enharmonic White Keys", () => new PracticeState(() => new NotePuzzle(PuzzleType.Theory, IPitchClass.GetEnharmonicWhite().GetRandom()), () => new MenuState(this))),
            new MenuItem("Note Theory practice: Double Accidentals (x & bb)", () => new PracticeState(() => new NotePuzzle(PuzzleType.Theory, IPitchClass.GetDoubles().GetRandom()), () => new MenuState(this))),
            new MenuItem("Note Theory practice: All Keys (no enharmonic)", () => new PracticeState(() => new NotePuzzle(PuzzleType.Theory, IPitchClass.GetAllNoEnharmonic().GetRandom()), () => new MenuState(this))),
            new MenuItem("Note Theory practice: All Keys (w/ doubles)", () => new PracticeState(() => new NotePuzzle(PuzzleType.Theory, IPitchClass.GetAll().GetRandom()), () => new MenuState(this))),

            new MenuItem("Note Aural practice: All Keys", () => new PracticeState( () => new NotePuzzle(PuzzleType.Aural, IPitchClass.GetAllNoEnharmonic().GetRandom()), () => new MenuState(this))),
            Back];
    }
}