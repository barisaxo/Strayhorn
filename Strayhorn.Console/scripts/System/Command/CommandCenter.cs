namespace Strayhorn.Systems.Commands;
using Strayhorn.Utility;

public interface ICommand
{
    public void Execute();
    public bool DisplayInput { get; set; }
    public ICommand[] Commands { get; }
    public TriggerType TriggerType { get; }
    public string Desc { get; set; }
    public string TriggerString { get; set; }
    public ConsoleKey TriggerKey { get; set; }
}

public class Command(
    Action action,
    ICommand[] commands,
    TriggerType triggerType = TriggerType.ReadLine,
    string desc = "",
    string triggerString = "",
    ConsoleKey triggerKey = ConsoleKey.None) : ICommand
{
    public bool DisplayInput { get; set; } = false;
    public ICommand[] Commands { get; set; } = commands;
    public TriggerType TriggerType { get; set; } = triggerType;
    public string Desc { get; set; } = desc;
    public string TriggerString { get; set; } = triggerString;
    public ConsoleKey TriggerKey { get; set; } = triggerKey;

    readonly Action Action = action;
    public void Execute() => Action();
}

// public interface ICommandConsole
// {
//     public void Execute();//string? arg
// public ICommand[] Commands { get; }
//     public TriggerType TriggerType { get; }

// }

// public class EmptyCommandConsole : ICommandConsole
// {
//     public void Execute() { }
//     public ICommand[] Commands { get; } = [];
//     public TriggerType TriggerType { get; } = TriggerType.ReadLine;
// }

public enum TriggerType { ReadKey, ReadLine };

// public abstract class PuzzleCommand : ICommand
// {
//     // public Func<string?, Action> Do => throw new NotImplementedException();
//     public abstract void Execute();

//     public abstract string? TriggerString { get; }
//     public abstract ConsoleKey? TriggerKey { get; }
//     public abstract ICommandConsole Next { get; }
// }

// public abstract class MenuCommand : ICommand
// {
//     // public Func<string?, Action> Do => throw new NotImplementedException();
//     public abstract void Execute();
//     public abstract string? TriggerString { get; }
//     public abstract ConsoleKey? TriggerKey { get; }
//     public ICommandConsole Next { get; }
//     public ICommandConsole Prev { get; }
// }

// public class EmptyCommand : ICommand
// {
//     public string Desc { get; set; }
//     public string TriggerString { get; set; }
//     public ConsoleKey TriggerKey { get; set; }
//     public TriggerType TriggerType { get; }
//     public ICommand[] Commands { get; }
//     public void Execute() { }

//     public EmptyCommand()
//     {
//         Desc = string.Empty;
//         TriggerType = TriggerType.ReadLine;
//         TriggerString = string.Empty;
//         TriggerKey = ConsoleKey.None;
//         Commands = [];
//     }
// }

public class CommandCenter
{
    private bool Running = false;
    private readonly QuitCommand Quit;

    public CommandCenter()
    {
        Quit = new QuitCommand(this);
    }

    public class QuitCommand(CommandCenter cc) : ICommand
    {
        readonly CommandCenter CC = cc;
        public void Execute()
        {
            Program.OutroCredits();
            CC.Running = false;
        }
        public bool DisplayInput { get; set; } = false;
        public string Desc { get; set; } = "Quit";
        public TriggerType TriggerType => TriggerType.ReadLine;
        public string TriggerString { get; set; } = "-q";
        public ConsoleKey TriggerKey { get; set; } = ConsoleKey.None;
        public ICommand[] Commands { get; } = [];
    }

    public void Initialize(ICommand command)
    {
        if (Running) throw new SystemException(
            "Command Center is already initialized. " +
            "Creating an additional loop will cause state breaking behaviour.");

        Running = true;
        Loop(command);
    }

    void Loop(ICommand command, string? arg = null, bool invalidArg = false)
    {
        command.Execute();

        if (command.DisplayInput)
        {
            if (arg != null) Console.WriteLine($"\nYou entered: '{arg}'");

            if (invalidArg)
            {
                Console.WriteLine("\nPlease select a valid option, or type -q to quit\n");
                invalidArg = false;
            }
        }

        if (Running)
        {
            switch (command.TriggerType)
            {
                case TriggerType.ReadKey:

                    var key = Console.ReadKey().Key;

                    foreach (var c in command.Commands)
                        if (c.TriggerKey != ConsoleKey.None && c.TriggerKey == key)
                        {
                            command = c;
                            break;
                        }

                    break;

                case TriggerType.ReadLine:

                    arg = Console.ReadLine();
                    if (arg == null) break;
                    if (arg.Contains(Quit.TriggerString))
                    {
                        command = Quit;
                        break;
                    }

                    bool exit = false;
                    foreach (var c in command.Commands)
                    {
                        if (command.TriggerString != null && c.TriggerString == arg.Trim())
                        {
                            exit = true;
                            command = c;
                            break;
                        }
                    }
                    if (exit) break;

                    invalidArg = true;
                    break;
            }

            Loop(command, arg, invalidArg);
        }

    }

    public static void PrintCommands(ICommand[] Commands)
    {
        const char TL = '╔';
        const char TR = '╗';
        const char BL = '╚';
        const char BR = '╝';
        const char H = '═';
        const char V = '║';

        Console.Clear();
        string select = "Select a topic:";
        int padding = 6;
        int max = Commands.Max(i => i.Desc.Length) + 3;
        int width = (max > select.Length ? max : select.Length) + padding;

        string top = TL + "".PadRight(width, H) + TR;
        string space = V + "".PadRight(width) + V;
        string bottom = BL + "".PadRight(width, H) + BR;

        Console.WriteLine("");
        Utils.WriteLineCentered(top);
        Utils.WriteLineCentered(space);
        Utils.WriteLineCentered($"{V} {select}".PadRight(width + 1) + V);
        Utils.WriteLineCentered(space);

        foreach (var item in Commands)
        {
            if (item.TriggerString == "X" || item.TriggerString == "x") Utils.WriteLineCentered(space);
            Utils.WriteLineCentered($"{V}  {item.TriggerString}: {item.Desc}".PadRight(width + 1) + V);
            if (item.TriggerString == "0") Utils.WriteLineCentered(space);
        }

        Utils.WriteLineCentered(space);
        Utils.WriteLineCentered(bottom);
        Console.WriteLine("");
    }

}