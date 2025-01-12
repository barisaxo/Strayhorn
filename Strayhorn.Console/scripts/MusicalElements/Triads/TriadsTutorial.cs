using Strayhorn.Systems.Display;
using Strayhorn.Utility;
namespace Strayhorn.Tutorials;

public class TriadsTutorial : ITutorial
{
    public IDisplay[] Displays => [P1];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("A triad is a stack of 3 notes in various arrangements of 3rds.");
        Console.WriteLine("Triads consist of a Root, a 3rd, and a 5th.");
        Console.WriteLine("There are four tonalities of triads (examples with C root):");
        Console.WriteLine();
        "╔════════════╦══════════════╦═════════════╦═════════════╦══════════╗".WriteLineCentered();
        "║  Tonality  ║ Chord Symbol ║ Intervallic ║ Chord Tones ║   Notes  ║".WriteLineCentered();
        "╠════════════╬══════════════╬═════════════╬═════════════╬══════════╣".WriteLineCentered();
        "║ Major      │ C            │ M3 + mi3    │ R 3 5       │ C E G    ║".WriteLineCentered();
        "╠────────────┼──────────────┼─────────────┼─────────────┼──────────╣".WriteLineCentered();
        "║ Minor      │ C-           │ mi3 + M3    │ R b3 5      │ C Eb G   ║".WriteLineCentered();
        "╠────────────┼──────────────┼─────────────┼─────────────┼──────────╣".WriteLineCentered();
        "║ Augmented  │ C+           │ M3 + M3     │ R 3 #5      │ C E G#   ║".WriteLineCentered();
        "╠────────────┼──────────────┼─────────────┼─────────────┼──────────╣".WriteLineCentered();
        "║ Diminished │ Cº           │ mi3 + mi3   │ R b3 b5     │ C Eb Gb  ║".WriteLineCentered();
        "╚════════════╩══════════════╩═════════════╩═════════════╩══════════╝".WriteLineCentered();
    });


    // static TutorialPageDisplay P2 => new(() =>
    // {

    // });

}
