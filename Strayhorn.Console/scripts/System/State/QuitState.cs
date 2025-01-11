using Strayhorn.Systems.State;

namespace Strayhorn.Menus;

public class QuitState : IState
{
    public IState Engage()
    {
        Logos.PrintOutroCredits();
        Environment.Exit(0);
        return this;
    }
}