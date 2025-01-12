using Strayhorn.Systems.Display;
using Strayhorn.Utility;
namespace Strayhorn.Tutorials;


public class InvertedChordsTutorial : ITutorial
{
    public IDisplay[] Displays => [P1];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("Chords can be inverted by placing another chord tone in the bottom of the stack.");
        Console.WriteLine("     • Root in the bottom = Root position.");
        Console.WriteLine("     • 3rd in the bottom = 1st inversion.");
        Console.WriteLine("     • 5th in the bottom = 2nd inversion. ");
        Console.WriteLine("     • 7th in the bottom = 3rd inversion.");

    });
}