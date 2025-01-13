using Strayhorn.Practice;
using Strayhorn.Tutorials;
using Strayhorn.Utility;
using MusicTheory.Scales;
// using MusicTheory.Modes;

namespace Strayhorn.Menus;

public class ModesMenu : IMenu
{
    public IMenuItem Selection { get; set; }
    public IMenuItem[] MenuItems { get; }

    readonly MenuItem Tutorial;
    readonly MenuItem Back = new("Main Menu", () => new MenuState(new MainMenu()));

    public ModesMenu()
    {
        Tutorial = new("About Modes", () => new TutorialState(new ModesTutorial(), () => new MenuState(this)));
        Selection = Tutorial;

        MenuItems = [Tutorial,
            new MenuItem("Modes Theory practice: Major Modes", () => new PracticeState( () => new ModePuzzle(PuzzleType.Theory,new Major().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Theory practice: Pentatonic Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Theory,new Pentatonic().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Theory practice: Blues Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Theory,new Blues().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Theory practice: Jazz Minor Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Theory,new JazzMinor().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Theory practice: Harmonic Minor Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Theory,new HarmonicMinor().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Theory practice: Sixth-Diminished Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Theory,new SixthDiminished().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Theory practice: Diminished Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Theory,new Diminished().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Theory practice: All Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Theory,IScale.GetAllModal().GetRandom().Modes.GetRandom()), () => new MenuState(this))),

            new MenuItem("Modes Aural practice: Major Modes", () => new PracticeState( () => new ModePuzzle(PuzzleType.Aural, new Major().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Aural practice: Pentatonic Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Aural, new Pentatonic().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Aural practice: Blues Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Aural, new Blues().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Aural practice: Jazz Minor Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Aural, new JazzMinor().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Aural practice: Harmonic Minor Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Aural, new HarmonicMinor().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Aural practice: Sixth-Diminished Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Aural, new SixthDiminished().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Aural practice: Diminished Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Aural, new Diminished().Modes.GetRandom()), () => new MenuState(this))),
            new MenuItem("Modes Aural practice: All Modes", () => new PracticeState(() => new ModePuzzle(PuzzleType.Aural, IScale.GetAllModal().GetRandom().Modes.GetRandom()), () => new MenuState(this))),
            Back];
    }

}
