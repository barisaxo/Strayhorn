using Strayhorn.Puzzles;
using Strayhorn.Tutorials;

namespace Strayhorn.Menus;

public class ScalesMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem About;
    readonly MenuItem MoreScales;

    readonly MenuItem Level1;
    readonly MenuItem Level2;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public ScalesMenu()
    {
        About = new("About Scales", () => new TutorialState(new ScalesTutorialP1(), () => new MenuState(this)));
        MoreScales = new("More Common Scales", () => new TutorialState(new MoreScalesTutorialP1(), () => new MenuState(this)));
        Level1 = new("Scale puzzle level 1: Major Scales", () => new PuzzleState(() => new ScalePuzzle1(), () => new MenuState(this)));
        Level2 = new("Scale puzzle level 2: All Scales", () => new PuzzleState(() => new ScalePuzzle2(), () => new MenuState(this)));
        Selection = About;
        MenuItems = [About, MoreScales, Level1, Level2, Back];
    }

}
