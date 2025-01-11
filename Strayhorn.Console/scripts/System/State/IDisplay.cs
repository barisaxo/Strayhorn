namespace Strayhorn.Systems.Display;

public interface IDisplay
{
    public void DisplayPage();
}

/// <summary>
/// Do not call Console.Clear() in tutorial page display. Tutorial state will handle that.
/// </summary>
public class TutorialPageDisplay(Action display) : IDisplay
{
    public void DisplayPage() => display();
}
