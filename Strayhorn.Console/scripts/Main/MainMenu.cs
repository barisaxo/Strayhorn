namespace Strayhorn.Menus;

public class MainMenu : IMenu
{
    public IMenuItem Selection { get; set; } = I1;
    public IMenuItem[] MenuItems { get; } = [I1, I2, I3, I4, I5, I6, I7, I8, IX];

    readonly static MenuItem I1 = new("Notes", () => new MenuState(new NotesMenu()));
    readonly static MenuItem I2 = new("Steps", () => new MenuState(new StepsMenu()));
    readonly static MenuItem I3 = new("Scales", () => new MenuState(new ScalesMenu()));
    readonly static MenuItem I4 = new("Intervals", () => new MenuState(new IntervalsMenu()));
    readonly static MenuItem I5 = new("Triads", () => new MenuState(new TriadsMenu()));
    readonly static MenuItem I6 = new("7th Chords", () => new MenuState(new SeventhChordsMenu()));
    readonly static MenuItem I7 = new("Inversions", () => new MenuState(new InversionsMenu()));
    readonly static MenuItem I8 = new("Modes", () => new MenuState(new ModesMenu()));
    readonly static MenuItem IX = new("Quit", () => new QuitState());
}
