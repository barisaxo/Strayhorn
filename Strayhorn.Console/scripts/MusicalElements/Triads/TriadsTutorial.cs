using Strayhorn.Systems.Display;
using Strayhorn.Utility;
namespace Strayhorn.Tutorials;

public class TriadsTutorial : ITutorial
{
    public IDisplay[] Displays => [P1];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("\nTRIADS\n");
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


    static TutorialPageDisplay P2 => new(() =>
    {
        Console.WriteLine("\nTRIADS\n");
        Console.WriteLine("There are a few other 'theoretical' chords that should be mentioned.");
        Console.WriteLine("While these are not true triads, it's still important to be aware of them.");
        Console.WriteLine("Sus2 & Sus4 chords are made by replacing the 3rd with either a M2 or P4.");
        Console.WriteLine("\nAnd finally the 'power' chord, or '5' chord.");
        Console.WriteLine("Not containing any third at all, they are just R 5, or R 5 8");
        Console.WriteLine("\n None of these 'theoretical' chords have any real 'tonality'.");
        Console.WriteLine("These chords are not inherently major, minor, augmented, or diminished,");
        Console.WriteLine("however context can often superimpose tonality unto the chords.\n");
        "╔════════════╦══════════════╦═════════════╦═════════════╦══════════╗".WriteLineCentered();
        "║  Tonality  ║ Chord Symbol ║ Intervallic ║ Chord Tones ║   Notes  ║".WriteLineCentered();
        "╠════════════╬══════════════╬═════════════╬═════════════╬══════════╣".WriteLineCentered();
        "║ n/a        │ CSus2        │ M2 + P4     │ R 2 5       │ C D G    ║".WriteLineCentered();
        "╠────────────┼──────────────┼─────────────┼─────────────┼──────────╣".WriteLineCentered();
        "║ n/a        │ CSus4        │ P4 + M2     │ R 4 5       │ C F G    ║".WriteLineCentered();
        "╠────────────┼──────────────┼─────────────┼─────────────┼──────────╣".WriteLineCentered();
        "║ n/a        │ C5           │ P5 + P4     │ R 5 8       │ C G C    ║".WriteLineCentered();
        "╚════════════╩══════════════╩═════════════╩═════════════╩══════════╝".WriteLineCentered();
    });
}
