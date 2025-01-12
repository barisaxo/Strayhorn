namespace Strayhorn.Menus;

public class MainMenu : IMenu
{
    public IMenuItem Selection { get; set; } = Item1;
    public IMenuItem[] MenuItems { get; } = [Item1, Item2, Item3, Item4, Item5, Item6, ItemX];
    readonly static MenuItem Item1 = new("Notes", () => new MenuState(new NotesMenu()));
    readonly static MenuItem Item2 = new("Steps", () => new MenuState(new StepsMenu()));
    readonly static MenuItem Item3 = new("Scales", () => new MenuState(new ScalesMenu()));
    readonly static MenuItem Item4 = new("Intervals", () => new MenuState(new IntervalsMenu()));
    readonly static MenuItem Item5 = new("Triads", () => new MenuState(new TriadsMenu()));
    readonly static MenuItem Item6 = new("7th Chords", () => new MenuState(new SeventhChordsMenu()));
    readonly static MenuItem ItemX = new("Quit", () => new QuitState());
}
