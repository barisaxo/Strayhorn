using Strayhorn.Utility;
using Strayhorn.Systems.Display;

namespace Strayhorn.Tutorials;

public class ModesTutorial : ITutorial
{
    public IDisplay[] Displays => [P1];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("\nMODES\n");
        Console.WriteLine("Modes are essentially inverted scales.");
        Console.WriteLine("You can think a mode as relative to its parent scale.");
        Console.WriteLine("However, it is generally better to treat each as their own scale with a unique stepwise makeup");
        Console.WriteLine("starting from their respective scale degree 1 (parallel).");
        Console.WriteLine("Below are the modes of the major scale.");
        Console.WriteLine("Major modes are also known as 'Gregorian modes' or 'Church modes'.");
        Console.WriteLine("Modes of other scales do not have unique Greek naming conventions.\n");

        "╔═════════════╦════════╦═════════════════╦═══════════════╦══════════════════════╗".WriteLineCentered();
        "║ Church Mode ║ Mode # ║    Relative     ║   Stepwise    ║      Parallel        ║".WriteLineCentered();
        "╠═════════════╬════════╬═════════════════╬═══════════════╬══════════════════════╣".WriteLineCentered();
        "║ Ionian      │ Prime  │ 1 2 3 4 5 6 7 1 │ W W H W W W H │ 1 2 3 4 5 6 7 1      ║".WriteLineCentered();
        "╠─────────────┼────────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Dorian      │ 2nd    │ 2 3 4 5 6 7 1 2 │ W H W W W H W │ 1 2 b3 4 5 6 b7 1    ║".WriteLineCentered();
        "╠─────────────┼────────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Phrygian    │ 3rd    │ 3 4 5 6 7 1 2 3 │ H W W W H W W │ 1 b2 b3 4 5 b6 b7 1  ║".WriteLineCentered();
        "╠─────────────┼────────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Lydian      │ 4th    │ 4 5 6 7 1 2 3 4 │ W W W H W W H │ 1 2 3 #4 5 6 7 1     ║".WriteLineCentered();
        "╠─────────────┼────────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Mixolydian  │ 5th    │ 5 6 7 1 2 3 4 5 │ W W H W W H W │ 1 2 3 4 5 6 b7 1     ║".WriteLineCentered();
        "╠─────────────┼────────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Aeolian     │ 6th    │ 6 7 1 2 3 4 5 6 │ W H W W H W W │ 1 2 b3 4 5 b6 b7 1   ║".WriteLineCentered();
        "╠─────────────┼────────┼─────────────────┼───────────────┼──────────────────────╣".WriteLineCentered();
        "║ Locrian     │ 7th    │ 7 1 2 3 4 5 6 7 │ H W W H W W W │ 1 b2 b3 4 b5 b6 b7 1 ║".WriteLineCentered();
        "╚═════════════╩════════╩═════════════════╩═══════════════╩══════════════════════╝".WriteLineCentered();
    });

}
