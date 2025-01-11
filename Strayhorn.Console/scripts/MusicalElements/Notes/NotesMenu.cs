using Strayhorn.Tutorials;
using Strayhorn.Puzzles;

namespace Strayhorn.Menus;

public class NotesMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Level3;
    readonly MenuItem Level4;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public NotesMenu()
    {
        About = new("About Notes", () => new TutorialState(new NotesTutorialP1(), () => new MenuState(this)));
        Level1 = new("Note ID puzzle level 1: White Keys", () => new PuzzleState(() => new NotePuzzle1(), () => new MenuState(this)));
        Level2 = new("Note ID puzzle level 2: Black Keys", () => new PuzzleState(() => new NotePuzzle2(), () => new MenuState(this)));
        Level3 = new("Note ID puzzle level 3: Enharmonic White Keys", () => new PuzzleState(() => new NotePuzzle3(), () => new MenuState(this)));
        Level4 = new("Note ID puzzle level 4: All Keys", () => new PuzzleState(() => new NotePuzzle4(), () => new MenuState(this)));
        Selection = About;
        MenuItems = [About, Level1, Level2, Level3, Level4, Back];
    }
}