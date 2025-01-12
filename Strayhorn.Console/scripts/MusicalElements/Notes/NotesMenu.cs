using Strayhorn.Tutorials;
using Strayhorn.Practice;

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
        About = new("Notes Tutorial", () => new TutorialState(new NotesTutorial(), () => new MenuState(this)));
        Level1 = new("Note practice: White Keys", () => new Practicetate(() => new NotePractice1(), () => new MenuState(this)));
        Level2 = new("Note practice: Black Keys", () => new Practicetate(() => new NotePractice2(), () => new MenuState(this)));
        Level3 = new("Note practice: Enharmonic White Keys", () => new Practicetate(() => new NotePractice3(), () => new MenuState(this)));
        Level4 = new("Note practice: All Keys", () => new Practicetate(() => new NotePractice4(), () => new MenuState(this)));
        Selection = About;
        MenuItems = [About, Level1, Level2, Level3, Level4, Back];
    }
}