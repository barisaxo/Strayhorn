using Strayhorn.Practice;
using Strayhorn.Tutorials;

namespace Strayhorn.Menus;

public class ScalesMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem MoreScales;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public ScalesMenu()
    {
        Tutorial = new("About Scales", () => new TutorialState(new ScalesTutorial(), () => new MenuState(this)));
        MoreScales = new("More Common Scales", () => new TutorialState(new MoreScalesTutorial(), () => new MenuState(this)));
        Level1 = new("Scale practice: Major Scales", () => new Practicetate(() => new ScalePractice1(), () => new MenuState(this)));
        Level2 = new("Scale practice: All Scales", () => new Practicetate(() => new ScalePractice2(), () => new MenuState(this)));
        Selection = Tutorial;
        MenuItems = [Tutorial, MoreScales, Level1, Level2, Back];
    }

}
