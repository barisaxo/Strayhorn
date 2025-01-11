namespace Strayhorn.Menus;

public class MainMenu : IMenu
{
    public IMenuItem Selection { get; set; } = Test1;
    public IMenuItem[] MenuItems { get; } = [Test1, Test2, Test3, Test4];
    readonly static MenuItem Test1 = new("Notes", () => new MenuState(new NotesMenu()));
    readonly static MenuItem Test2 = new("Steps", () => new MenuState(new StepsMenu()));
    readonly static MenuItem Test3 = new("Scales", () => new MenuState(new ScalesMenu()));
    readonly static MenuItem Test4 = new("Quit", () => new QuitState());
}
