using Strayhorn.Menus;
using Strayhorn.Puzzles.Notes;
// using Strayhorn.Puzzles.Steps;
using Strayhorn.Systems.Commands;
using Strayhorn.Utility;

namespace Strayhorn.Menus;

public class MainMenu : ICommand
{
    public bool DisplayInput { get; set; } = true;
    public ICommand[] Commands { get; }
    public TriggerType TriggerType { get; } = TriggerType.ReadLine;
    public string Desc { get; set; }
    public string TriggerString { get; set; }
    public ConsoleKey TriggerKey { get; set; }

    public MainMenu(string desc = "", string trigger = "", ConsoleKey key = ConsoleKey.None)
    {
        Desc = desc;
        TriggerString = trigger;
        TriggerKey = key;

        Commands =
        [
            new NotesMenu(this, desc: "Notes", triggerString: "1"),
            new Command(()=>{}, [], desc: "Quit", triggerString: "-q")
        ];
    }

    public void Execute() => CommandCenter.PrintCommands(Commands);
}

// public static void Menu(string? arg)
// {
//     PrintMenu();

//     arg ??= Console.ReadLine();
//     switch (arg)
//     {
//         case "1":
//             Puzzles.Notes.NotesPuzzle.Menu(null);
//             break;
//         case "2":
//             Puzzles.Steps.StepsPuzzle.StepsMenu(null);
//             break;
//         case "3":
//             Scales();
//             break;
//         case "4":
//             Intervals();
//             break;
//         case "5":
//             Chords();
//             break;

//         case "T" or "t":
//             PianoScroll.DrawGuitarBox();
//             PianoScroll.DrawGuitarOneOctave();
//             PianoScroll.DrawTwoOctavePiano();
//             PianoScroll.DrawStaves();
//             break;

//         case "x" or "X":
// Console.Clear();
// Console.WriteLine("Goodbye!");
// Console.WriteLine("");
// foreach (string line in Logo) Console.WriteLine(line);
// return;
//         default:
//             PrintMenu();
//             Console.WriteLine("Please select a valid option");
//             Menu(Console.ReadLine());
//             break;
//     }
// }

// public static void Scales()
// {
//     Console.WriteLine("Not yet implemented");
//     Console.WriteLine("");
//     Console.WriteLine("(press any key to continue...)");
//     Console.ReadKey(true);
//     Menu(null);
// }

// public static void Intervals()
// {
//     Console.WriteLine("Not yet implemented");
//     Console.WriteLine("");
//     Console.WriteLine("(press any key to continue...)");
//     Console.ReadKey(true);
//     Menu(null);
// }

// public static void Chords()
// {
//     Console.WriteLine("Not yet implemented");
//     Console.WriteLine("");
//     Console.WriteLine("(press any key to continue...)");
//     Console.ReadKey(true);
//     Menu(null);
// }

// static void PrintMenu()
// {
//     Console.Clear();

//     Console.WriteLine("╔═════════════════╗");
//     Console.WriteLine("║ Select a topic: ║");
//     Console.WriteLine("║                 ║");
//     Console.WriteLine("║  1: Notes       ║");
//     Console.WriteLine("║  2: Steps       ║");
//     Console.WriteLine("║  3: Scales      ║");
//     Console.WriteLine("║  4: Intervals   ║");
//     Console.WriteLine("║  5: Triads      ║");
//     Console.WriteLine("║                 ║");
//     Console.WriteLine("║  x: Exit        ║");
//     Console.WriteLine("╚═════════════════╝");
// }
