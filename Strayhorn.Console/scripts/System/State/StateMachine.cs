namespace Strayhorn.Systems.State;
using Strayhorn.Systems.Display;
using System.Threading;

public interface IState
{
    // public IUpdate InputHandler { get; }
    // public IDisplay Display { get; }
    public IState Engage();
}

public class StateMachine(IState state)
{
    private bool Running = false;
    private static bool _blockInput;
    public static bool BlockInput
    {
        get => _blockInput;
        set
        {
            _blockInput = value;
            if (_blockInput)
            {
                new Thread(
                    () =>
                    {
                        while (_blockInput)
                            while (Console.KeyAvailable) Console.ReadKey(true);
                    }).Start();
            }
        }
    }

    public void Initialize()
    {
        if (Running) throw new SystemException(
            "State Machine is already initialized. " +
            "Creating an additional loop will cause breaking behaviour.");

        Running = true;
        Loop();
    }

    public void Loop()
    {
        if (!Running) return;
        state = state.Engage();
        Loop();
    }

}