using Strayhorn.Practice;
using Strayhorn.Tutorials;

namespace Strayhorn.Menus;

public class ModesMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public ModesMenu()
    {
        Tutorial = new("About Modes", () => new TutorialState(new ModesTutorial(), () => new MenuState(this)));
        Level1 = new("Mode practice: Major Modes", () => new PracticeState(() => new ModePractice1(), () => new MenuState(this)));
        Level2 = new("Mode practice: All Modes", () => new PracticeState(() => new ModePractice2(), () => new MenuState(this)));
        Selection = Tutorial;
        MenuItems = [Tutorial, Level1, Level2, Back];
    }

}
