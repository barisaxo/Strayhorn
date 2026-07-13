using Strayhorn.Utility;
using Strayhorn.Systems.Display;

namespace Strayhorn.Tutorials;

public class ModesTutorial : ITutorial
{
    public IDisplay[] Displays => [P1, P2, P3, P4, P5, P6, P7, P8, P9];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Modes are essentially inverted scales.");
        Console.WriteLine("You can think a mode as 'relative' to the parent scale.");
        Console.WriteLine("However, it is best practice to treat a mode as its own scale.");
        Console.WriteLine("Each with unique stepwise makeup and intervalic relationships,");
        Console.WriteLine("starting from their respective scale degree 1 (parallel).");
        Console.WriteLine("Major modes are also known as 'Gregorian modes' or 'Church modes'.\n");

        "╔═════════════╦══════╦═════════════════╦═══════════════╦══════════════════════╗".WriteLineCentered();
        "║ Church Mode ║ Mode ║    Relative     ║   Stepwise    ║      Parallel        ║".WriteLineCentered();
        "║             ║      ║    Intervals    ║               ║      Intervals       ║".WriteLineCentered();
        "╠═════════════╬══════╬═════════════════╬═══════════════╬══════════════════════╣".WriteLineCentered();
        "║ Ionian      │ 1st  │ 1 2 3 4 5 6 7 1 │ W W H W W W H │ 1 2 3 4 5 6 7 1      ║".WriteLineCentered();
        "╠─────────────┼──────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Dorian      │ 2nd  │ 2 3 4 5 6 7 1 2 │ W H W W W H W │ 1 2 b3 4 5 6 b7 1    ║".WriteLineCentered();
        "╠─────────────┼──────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Phrygian    │ 3rd  │ 3 4 5 6 7 1 2 3 │ H W W W H W W │ 1 b2 b3 4 5 b6 b7 1  ║".WriteLineCentered();
        "╠─────────────┼──────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Lydian      │ 4th  │ 4 5 6 7 1 2 3 4 │ W W W H W W H │ 1 2 3 #4 5 6 7 1     ║".WriteLineCentered();
        "╠─────────────┼──────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Mixolydian  │ 5th  │ 5 6 7 1 2 3 4 5 │ W W H W W H W │ 1 2 3 4 5 6 b7 1     ║".WriteLineCentered();
        "╠─────────────┼──────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Aeolian     │ 6th  │ 6 7 1 2 3 4 5 6 │ W H W W H W W │ 1 2 b3 4 5 b6 b7 1   ║".WriteLineCentered();
        "╠─────────────┼──────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Locrian     │ 7th  │ 7 1 2 3 4 5 6 7 │ H W W H W W W │ 1 b2 b3 4 b5 b6 b7 1 ║".WriteLineCentered();
        "╚═════════════╩══════╩═════════════════╩═══════════════╩══════════════════════╝".WriteLineCentered();
    });

    static TutorialPageDisplay P2 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Modes of the Pentatonic Scale\n");

        "╔══════════════════╦══════╦═══════════════╦═════════════════╗".WriteLineCentered();
        "║ Name             ║ Mode ║   Stepwise    ║    Intervals    ║".WriteLineCentered();
        "╠══════════════════╬══════╬═══════════════╬═════════════════╣".WriteLineCentered();
        "║ Pentatonic       │ 1st  │   W W S W S   │ 1 2 3 5 6 1     ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼─────────────────╣".WriteLineCentered();
        "║ Pentatonic II    │ 2nd  │   W S W S W   │ 1 2 4 5 b7 1    ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼─────────────────╣".WriteLineCentered();
        "║ Pentatonic III   │ 3rd  │   S W S W W   │ 1 b3 4 b6 b7 1  ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼─────────────────╣".WriteLineCentered();
        "║ Pentatonic IV    │ 4th  │   W S W W S   │ 1 2 4 5 6 1     ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼─────────────────╣".WriteLineCentered();
        "║ Pentatonic Minor │ 5th  │   S W W S W   │ 1 b3 4 5 b7 1   ║".WriteLineCentered();
        "╚══════════════════╩══════╩═══════════════╩═════════════════╝".WriteLineCentered();
    });

    static TutorialPageDisplay P3 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Common modes of the Blues Scale");
        Console.WriteLine("The b5 in the Blues Minor and the b3 in the Blues Major are often referred to as the 'blue note'.\n");

        "╔═══════════════╦══════╦═══════════════╦════════════════════╗".WriteLineCentered();
        "║ Name          ║ Mode ║   Stepwise    ║      Intervals     ║".WriteLineCentered();
        "╠═══════════════╬══════╬═══════════════╬════════════════════╣".WriteLineCentered();
        "║ Blues (Minor) │ 1st  │  S W H H W S  │ 1 b3 4 b5 5 b7 1   ║".WriteLineCentered();
        "╠───────────────┼──────┼───────────────┼────────────────────╣".WriteLineCentered();
        "║ Blues Major   │ 2nd  │  W H H W S S  │ 1 2 b3 3 5 6 1     ║".WriteLineCentered();
        "╚═══════════════╩══════╩═══════════════╩════════════════════╝".WriteLineCentered();
    });

    static TutorialPageDisplay P4 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Modes of the Jazz Minor Scale");
        Console.WriteLine("Note: modes of the Jazz Minor scale have inconsistent naming conventions.\n");

        "╔══════════════════╦══════╦═══════════════╦══════════════════════╗".WriteLineCentered();
        "║ Name             ║ Mode ║   Stepwise    ║      Intervals       ║".WriteLineCentered();
        "╠══════════════════╬══════╬═══════════════╬══════════════════════╣".WriteLineCentered();
        "║ Jazz Minor       │ 1st  │ W H W W W W H │ 1 2 b3 4 5 6 7 1     ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Phrygian ♮6      │ 2nd  │ H W W W W H W │ 1 b2 b3 4 b5 6 b7 1  ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Lydian ♯5        │ 3rd  │ W W W W H W H │ 1 2 3 #4 #5 6 7 1    ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Lydian Dominant  │ 4th  │ W W W H W H W │ 1 2 3 #4 5 6 b7 1    ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Mixolydian ♭6    │ 5th  │ W W H W H W W │ 1 2 3 4 5 b6 b7 1    ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Locrian ♮9       │ 6th  │ W H W H W W W │ 1 2 b3 4 b5 b6 b7 1  ║".WriteLineCentered();
        "╠──────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Altered Dominant │ 7th  │ H W H W W W W │ 1 b2 #2 3 b5 #5 b7 1 ║".WriteLineCentered();
        "╚══════════════════╩══════╩═══════════════╩══════════════════════╝".WriteLineCentered();
    });

    static TutorialPageDisplay P5 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Modes of the Harmonic Minor Scale");
        Console.WriteLine("Note: modes of the Harmonic Minor scale have inconsistent naming conventions.\n");

        "╔═══════════════════╦══════╦═══════════════╦══════════════════════╗".WriteLineCentered();
        "║ Name              ║ Mode ║   Stepwise    ║      Intervals       ║".WriteLineCentered();
        "╠═══════════════════╬══════╬═══════════════╬══════════════════════╣".WriteLineCentered();
        "║ Harmonic Minor    │ 1st  │ W H W W H S H │ 1 2 b3 4 5 b6 7 1    ║".WriteLineCentered();
        "╠───────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Locrian ♮6        │ 2nd  │ H W W H S H W │ 1 b2 b3 4 b5 6 b7 1  ║".WriteLineCentered();
        "╠───────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Ionian #5         │ 3rd  │ W W H S H W H │ 1 2 3 4 #5 6 7 1     ║".WriteLineCentered();
        "╠───────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Dorian #11        │ 4th  │ W H S H W H W │ 1 2 b3 #4 5 6 b7 1   ║".WriteLineCentered();
        "╠───────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Phrygian Dominant │ 5th  │ H S H W H W W │ 1 b2 3 4 5 b6 b7 1   ║".WriteLineCentered();
        "╠───────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Lydian #9         │ 6th  │ S H W H W W H │ 1 #2 3 #4 5 6 7 1    ║".WriteLineCentered();
        "╠───────────────────┼──────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Ultra Locrian     │ 7th  │ H W H W W H S │ 1 b2 b3 3 b5 b6 º7 1 ║".WriteLineCentered();
        "╚═══════════════════╩══════╩═══════════════╩══════════════════════╝".WriteLineCentered();
    });


    static TutorialPageDisplay P6 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Modes of the Barry Harris Diminished 6th Scale");
        Console.WriteLine("Although there are technically more than two modes of the Diminished 6th scale," +
         " there are only two chords built from it:\nMajor 6th and Diminished 7th (alternating, with inversions).");
        Console.WriteLine("For this reason, only two modes of the Diminished 6th scale are included in this tutorial.\n");

        "╔═══════════════════╦══════╦═════════════════╦══════════════════════╗".WriteLineCentered();
        "║ Name              ║ Mode ║   Stepwise      ║      Intervals       ║".WriteLineCentered();
        "╠═══════════════════╬══════╬═════════════════╬══════════════════════╣".WriteLineCentered();
        "║ Diminished 6th    │ 1st  │ W W H W H H W H │ 1 2 3 4 5 b6 6 7 1   ║".WriteLineCentered();
        "╠───────────────────┼──────┼─────────────────┼──────────────────────╣".WriteLineCentered();
        "║ Diminished 6th II │ 2nd  │ W H W H H W H W │ 1 2 b3 4 b5 5 6 b7 1 ║".WriteLineCentered();
        "╚═══════════════════╩══════╩═════════════════╩══════════════════════╝".WriteLineCentered();
    });

    static TutorialPageDisplay P7 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Modes of the Diminished Scale");
        Console.WriteLine("There are only two modes of the Diminished Scale named Whole-Half Diminished and Half-Whole Diminished," +
         "\ndescribing their starting intervals.\n");

        "╔═════════════╦══════╦═════════════════╦═════════════════════════╗".WriteLineCentered();
        "║ Name        ║ Mode ║ Stepwise        ║        Intervals        ║".WriteLineCentered();
        "╠═════════════╬══════╬═════════════════╬═════════════════════════╣".WriteLineCentered();
        "║ Whole-Half  │ 1st  │ W H W H W H W H │ 1 2 b3 4 b5 b6 º7 7 1   ║".WriteLineCentered();
        "╠─────────────┼──────┼─────────────────┼─────────────────────────╣".WriteLineCentered();
        "║ Half-Whole  │ 2nd  │ H W H W H W H W │ 1 b2 b3 3 b5 5 6 b7 1   ║".WriteLineCentered();
        "╚═════════════╩══════╩═════════════════╩═════════════════════════╝".WriteLineCentered();
    });

    static TutorialPageDisplay P8 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Modes of the Whole Tone Scale");
        Console.WriteLine("Being composed of all whole steps, this scale is symmetrical. There are no other modes.\n");

        "╔═════════════╦══════╦═════════════╦═══════════════════╗".WriteLineCentered();
        "║ Name        ║ Mode ║ Stepwise    ║     Intervals     ║".WriteLineCentered();
        "╠═════════════╬══════╬═════════════╬═══════════════════╣".WriteLineCentered();
        "║ Whole Tone  │ 1st  │ W W W W W W │ 1 2 3 #4 #5 b7 1  ║".WriteLineCentered();
        "╚═════════════╩══════╩═════════════╩═══════════════════╝".WriteLineCentered();
    });

    static TutorialPageDisplay P9 => new(() =>
      {
          Console.WriteLine("\nMODES\n");
          Console.WriteLine("Modes of the Chromatic Scale");
          Console.WriteLine("Being composed of all half steps, this scale is symmetrical. There are no other modes.\n");

          "╔═════════════╦══════╦══════════════╦════════════════════════════════╗".WriteLineCentered();
          "║ Name        ║ Mode ║ Stepwise     ║           Intervals            ║".WriteLineCentered();
          "╠═════════════╬══════╬══════════════╬════════════════════════════════╣".WriteLineCentered();
          "║ Chromatic   │ 1st  │ HHHHHHHHHHHH │ 1 b2 2 b3 3 4 b5 5 b6 6 b7 7 1 ║".WriteLineCentered();
          "╚═════════════╩══════╩══════════════╩════════════════════════════════╝".WriteLineCentered();
      });


}
