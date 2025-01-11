namespace Strayhorn.Systems.Display;

public interface IDisplay
{
    public void ExecuteDisplay();
}

public class Display(Action display) : IDisplay
{
    public void ExecuteDisplay() => display();
}
