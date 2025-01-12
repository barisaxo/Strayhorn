using Strayhorn.Systems.Display;
using Strayhorn.Utility;
namespace Strayhorn.Tutorials;

public class InversionTutorial : ITutorial
{
    public IDisplay[] Displays => [P1, P2];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("\nINVERSIONS:");
        Console.WriteLine("To invert means to go inside-out, or upside-down.");
        Console.WriteLine("Simply said, you move another note to the bottom of the stack.\n");
        Console.WriteLine("You can invert an interval by swapping the quality and quantity:");
        Console.WriteLine("\n    • Quantity:");
        Console.WriteLine("          - Unison <──> Octave");
        Console.WriteLine("          - 2nd <──> 7th ");
        Console.WriteLine("          - 3rd <──> 6th");
        Console.WriteLine("          - 4th <──> 5th");
        Console.WriteLine("\n    • Quality:");
        Console.WriteLine("          - Major <──> Minor ");
        Console.WriteLine("          - Augmented <──> Diminished");
        Console.WriteLine("          - Perfect <──> Perfect");
    });

    static TutorialPageDisplay P2 => new(() =>
    {
        Console.WriteLine();
        "╔══════════╦═══════════╦════════╦═══════════╦══════════╗".WriteLineCentered();
        "║ Interval ║   Notes   ║ Invert ║   Notes   ║ Interval ║".WriteLineCentered();
        "╠══════════╬═══════════╬════════╬═══════════╬══════════╣".WriteLineCentered();
        "║ Unison   │ C : C     │  <──>  │ C : C     │ Octave   ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ mi2      │ C : D♭    │  <──>  │ D♭ : C    │ M7       ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ M2       │ C : D     │  <──>  │ D : C     │ mi7      ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ mi3      │ C : E♭    │  <──>  │ E♭ : C    │ M6       ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ M3       │ C : E     │  <──>  │ E : C     │ mi6      ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ P4       │ C : F     │  <──>  │ F : C     │ P5       ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ Tritone  │ C : F♯/G♭ │  <──>  │ F♯/G♭ : C │ Tritone  ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ P5       │ C : G     │  <──>  │ G : C     │ P4       ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ mi6      │ C : A♭    │  <──>  │ A♭ : C    │ M3       ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ M6       │ C : A     │  <──>  │ A : C     │ mi3      ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ mi7      │ C : B♭    │  <──>  │ B♭ : C    │ M2       ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ M7       │ C : B     │  <──>  │ B : C     │ mi2      ║".WriteLineCentered();
        "╠──────────┼───────────┼────────┼───────────┼──────────╣".WriteLineCentered();
        "║ Octave   │ C : C     │  <──>  │ C : C     │ Unison   ║".WriteLineCentered();
        "╚══════════╩═══════════╩════════╩═══════════╩══════════╝".WriteLineCentered();
    });

}