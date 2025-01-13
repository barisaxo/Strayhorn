using Strayhorn.Practice;
using Strayhorn.Tutorials;
using MusicTheory.Scales;
using Strayhorn.Utility;

namespace Strayhorn.Menus;

public class ScalesMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem MoreScales;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public ScalesMenu()
    {
        Tutorial = new("About Scales", () => new TutorialState(new ScalesTutorial(), () => new MenuState(this)));
        MoreScales = new("More Common Scales", () => new TutorialState(new MoreScalesTutorial(), () => new MenuState(this)));
        Selection = Tutorial;

        MenuItems = [Tutorial, MoreScales,
            new MenuItem("Scale Theory practice: Major Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, new Major()), () => new MenuState(this))),
            new MenuItem("Scale Theory practice: Pentatonic Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, new Pentatonic()), () => new MenuState(this))),
            new MenuItem("Scale Theory practice: Blues Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, new Blues()), () => new MenuState(this))),
            new MenuItem("Scale Theory practice: Jazz Minor Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, new JazzMinor()), () => new MenuState(this))),
            new MenuItem("Scale Theory practice: HarmonicMinor Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, new HarmonicMinor()), () => new MenuState(this))),
            new MenuItem("Scale Theory practice: Sixth-Diminished Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, new SixthDiminished()), () => new MenuState(this))),
            new MenuItem("Scale Theory practice: Whole Tone Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, new WholeTone()), () => new MenuState(this))),
            new MenuItem("Scale Theory practice: Diminished Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, new Diminished()), () => new MenuState(this))),
            new MenuItem("Scale Theory practice: All Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Theory, IScale.GetAll().GetRandom()), () => new MenuState(this))),

            new MenuItem("Scale Aural practice: All Scales", () => new PracticeState(() => new ScalePuzzle(PuzzleType.Aural, IScale.GetAll().GetRandom()), () => new MenuState(this))),
            Back];
    }

}
