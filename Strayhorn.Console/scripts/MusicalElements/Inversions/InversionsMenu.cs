using Strayhorn.Tutorials;
using Strayhorn.Practice;

namespace Strayhorn.Menus;

public class InversionsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem Level1;
    // readonly MenuItem Level2;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public InversionsMenu()
    {
        About = new("About Inversions", () => new TutorialState(new InversionTutorial(), () => new MenuState(this)));
        Level1 = new("Interval Inversion Practice", () => new PracticeState(() => new InversionPractice1(), () => new MenuState(this)));
        // Level2 = new("All Inversions", () => new PracticeState(() => new InversionPractice2(), () => new MenuState(this)));
        Selection = About;
        MenuItems = [About, Level1, Back];
    }
}