using Strayhorn.Practice;
using Strayhorn.Tutorials;

namespace Strayhorn.Menus;

public class TriadsMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Level3;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public TriadsMenu()
    {
        Tutorial = new("Triads Tutorial", () => new TutorialState(new TriadsTutorial(), () => new MenuState(this)));
        Level1 = new("Triad practice: Major and Minor Triads", () => new Practicetate(() => new TriadPractice1(), () => new MenuState(this)));
        Level2 = new("Triad practice: Augmented and Diminished Triads", () => new Practicetate(() => new TriadPractice2(), () => new MenuState(this)));
        Level3 = new("Triad practice: All Triads", () => new Practicetate(() => new TriadPractice3(), () => new MenuState(this)));
        Selection = Tutorial;
        MenuItems = [Tutorial, Level1, Level2, Level3, Back];
    }

}
