using Strayhorn.Systems.Display;
using Strayhorn.Utility;
namespace Strayhorn.Tutorials;

public class IntervalTutorial : ITutorial
{
    public IDisplay[] Displays => [P1, P2, P3, P4];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("\nINTERVALS:");
        Console.WriteLine("An interval is the distance between two notes.\n");
        Console.WriteLine("Intervals have two elements:");
        Console.WriteLine("\n    • QUANTITY: The diatonic (letter to letter) distance:");
        Console.WriteLine("          - Unison (1sts)");
        Console.WriteLine("          - 2nds");
        Console.WriteLine("          - 3rds");
        Console.WriteLine("          - 4ths");
        Console.WriteLine("          - 5ths");
        Console.WriteLine("          - 6ths");
        Console.WriteLine("          - 7ths");
        Console.WriteLine("          - Octaves (8ths)");
        Console.WriteLine("\n    • QUALITY: The overall chromatic distance, in combination with the Quantity:");
        Console.WriteLine("          - Major");
        Console.WriteLine("          - Minor");
        Console.WriteLine("          - Augmented");
        Console.WriteLine("          - Diminished");
        Console.WriteLine("          - Perfect");
    });

    static TutorialPageDisplay P2 => new(() =>
   {
       Console.WriteLine("\nHere are a few intervallic caveats:");
       Console.WriteLine("\n    • 2nds, 3rds, 6ths, and 7ths cannot be perfect.");
       Console.WriteLine("    • Unisons and Octaves should only be perfect.");
       Console.WriteLine("    • 4ths and 5ths cannot be major or minor.");
       Console.WriteLine("    • 5ths and 7ths are the common diminished intervals.");
       Console.WriteLine("    • 2nds, 4ths, and 5ths are the common augmented intervals.");
   });

    static TutorialPageDisplay P3 => new(() =>
    {
        Console.WriteLine();
        "╔══════════╦════════╦═══════════╦═══════════╦═════════╦══════════╗".WriteLineCentered();
        "║ Interval ║ Symbol ║ Notes     ║ Chromatic ║ Quality ║ Quantity ║".WriteLineCentered();
        "╠══════════╬════════╬═══════════╬═══════════╬═════════╬══════════╣".WriteLineCentered();
        "║ Unison   │ 1      │ C : C     │ 0         │ Perfect │ 1st      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ mi2      │ ♭2     │ C : D♭    │ 1         │ Minor   │ 2nd      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ M2       │ 2      │ C : D     │ 2         │ Major   │ 2nd      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ mi3      │ ♭3     │ C : E♭    │ 3         │ Minor   │ 3rd      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ M3       │ 3      │ C : E     │ 4         │ Major   │ 3rd      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ P4       │ 4      │ C : F     │ 5         │ Perfect │ 4th      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ Tritone  │ ♯4/♭5  │ C : F♯/G♭ │ 6         │ Aug/Dim │ 4th/5th  ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ P5       │ 5      │ C : G     │ 7         │ Perfect │ 5th      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ mi6      │ ♭6     │ C : A♭    │ 8         │ Minor   │ 6th      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ M6       │ 6      │ C : A     │ 9         │ Major   │ 6th      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ mi7      │ ♭7     │ C : B♭    │ 10        │ Minor   │ 7th      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ M7       │ 7      │ C : B     │ 11        │ Major   │ 7th      ║".WriteLineCentered();
        "╠──────────┼────────┼───────────┼───────────┼─────────┼──────────╣".WriteLineCentered();
        "║ Octave   │ 8      │ C : C     │ 12        │ Perfect │ 8th      ║".WriteLineCentered();
        "╚══════════╩════════╩═══════════╩═══════════╩═════════╩══════════╝".WriteLineCentered();
    });

    static TutorialPageDisplay P4 => new(() =>
    {
        Console.WriteLine("\nEnharmonic and octave equivalents:");
        Console.WriteLine("    • 2 : 9 ");
        Console.WriteLine("    • ♭2 : ♭9 ");
        Console.WriteLine("    • 2 : 9 : 3 ");
        Console.WriteLine("    • 4 : 11 ");
        Console.WriteLine("    • ♯4 : ♯11 : ♭5 ");
        Console.WriteLine("    • 6 : 13 ");
        Console.WriteLine("    • 6 : 13 : 5 ");
        Console.WriteLine("    • 𝄫7 (aka º7) : 6 ");
    });
}

/*
╔  ╗  ║  ╚  ╝  ╦  ╩  ╠  ╣  ╬
 ┌─┬─┐
 │ │ │
 ╠─┼─╣
 │ │ │
 └─┴─┘
*/