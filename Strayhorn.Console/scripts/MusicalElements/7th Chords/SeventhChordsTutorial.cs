using Strayhorn.Systems.Display;
using Strayhorn.Utility;
namespace Strayhorn.Tutorials;

public class SeventhChordsTutorial : ITutorial
{
    public IDisplay[] Displays => [P1, P2];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("A 7th chord is an extension of a triad by adding another 3rd onto the stack.");
        Console.WriteLine("With the additional note there are many more tonalities of 7th chords than there are with triads. ");
        Console.WriteLine("All contain some kind of Root, 3rd, 5th, and 7th.");
        Console.WriteLine("This chapter will also include 6th chords, as they are very similar.");

    });


    static TutorialPageDisplay P2 => new(() =>
    {
        Console.WriteLine();
        "╔══════════════╦══════════════╦═════════════╦════════════╗".WriteLineCentered();
        "║   Tonality   ║ Chord Symbol ║ Chord Tones ║    Notes   ║".WriteLineCentered();
        "╠══════════════╩══════════════╩═════════════╩════════════╣".WriteLineCentered();
        "║              :       Major tonality       :            ║".WriteLineCentered();
        "╠──────────────┬──────────────┬─────────────┬────────────╣".WriteLineCentered();
        "║ Major 7      │ C∆7          │ R 3 5 7     │ C E G B    ║".WriteLineCentered();
        "╠──────────────┼──────────────┼─────────────┼────────────╣".WriteLineCentered();
        "║ Major 6      │ C6           │ R 3 5 6     │ C E G A    ║".WriteLineCentered();
        "╠──────────────┼──────────────┼─────────────┼────────────╣".WriteLineCentered();
        "║ Minor 7      │ D-7          │ R b3 5 b7   │ D F A C    ║".WriteLineCentered();
        "╠──────────────┼──────────────┼─────────────┼────────────╣".WriteLineCentered();
        "║ Dominant 7   │ G7           │ R 3 5 b7    │ G B D F    ║".WriteLineCentered();
        "╠──────────────┼──────────────┼─────────────┼────────────╣".WriteLineCentered();
        "║ 7sus         │ G7(sus)      │ R 4 5 b7    │ G B C F    ║".WriteLineCentered();
        "╠──────────────┴──────────────┴─────────────┴────────────╣".WriteLineCentered();
        "║              :       Minor tonality       :            ║".WriteLineCentered();
        "╠──────────────┬──────────────┬─────────────┬────────────╣".WriteLineCentered();
        "║ Minor 6      │ A-6          │ R b3 5 6    │ A C E F#   ║".WriteLineCentered();
        "╠──────────────┼──────────────┼─────────────┼────────────╣".WriteLineCentered();
        "║ Tonic Minor 7│ A-∆7         │ R b3 5 7    │ A C E G#   ║".WriteLineCentered();
        "╠──────────────┼──────────────┼─────────────┼────────────╣".WriteLineCentered();
        "║ Minor7(b5)   │ B-7(b5) / Bø │ R b3 b5 b7  │ B D F A    ║".WriteLineCentered();
        "╠──────────────┼──────────────┼─────────────┼────────────╣".WriteLineCentered();
        "║*Altered Dom7 │ E7+ / E7(alt)│ R 3 #5 b7   │ E G# B# D  ║".WriteLineCentered();
        "╠──────────────┴──────────────┴─────────────┴────────────╣".WriteLineCentered();
        "║              :   Passing Chord Dominants  :            ║".WriteLineCentered();
        "╠──────────────┬──────────────┬─────────────┬────────────╣".WriteLineCentered();
        "║ Diminished 7 │ C#º7         │ R b3 b5 º7  │ C# E G Bb  ║".WriteLineCentered();
        "╠──────────────┼──────────────┼─────────────┼────────────╣".WriteLineCentered();
        "║ Seven#11     │ Db7(#11)     │ R 3 #4 b7   │ Db F G# Cb ║".WriteLineCentered();
        "╚══════════════╩══════════════╩═════════════╩════════════╝".WriteLineCentered();


        Console.WriteLine("\nThe above chords are arranged by the tonality they are commonly used in - more on that later.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("*(There are a slew of altered dominant chords, above is just one example).");
        Console.ResetColor();
    });

}
/*
 ┐ ┌  ┘ └ ─ │ ┴ ┬ ├ ┼ ┤
 ┌─┬─┐
 │ │ │
 ├─┼─┤
 │ │ │
 └─┴─┘
 
*/