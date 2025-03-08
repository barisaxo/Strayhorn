using Strayhorn.Systems.Display;

namespace Strayhorn.Tutorials;

public class StepsTutorial : ITutorial
{
    public IDisplay[] Displays => [P1, P2];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine();
        PianoScroll.DrawTwoOctavePiano();
        Console.WriteLine();

        Console.WriteLine("A Step is a type of interval for adjacent letters and/or scale degrees.");
        Console.WriteLine("Stepwise motion is defined as moving melodically up or down the scale.");
        Console.WriteLine("The type of step is determined by the chromatic distance of the two notes");
        Console.WriteLine();
        Console.WriteLine("There are three types of steps: ");
        Console.WriteLine("Half-Step (+1),");
        Console.WriteLine("Whole-Step (+2),");
        Console.WriteLine("Skip-Step (+3).");
        Console.WriteLine();
        Console.WriteLine("To abbreviate, we'll use 'H', 'W', and 'S' - respectively.");
        Console.WriteLine();
    });


    static TutorialPageDisplay P2 => new(() =>
    {
        Console.WriteLine();
        PianoScroll.DrawTwoOctavePiano();
        Console.WriteLine();

        Console.WriteLine("The letters 'B & C', and 'E & F' make Half-Steps.");
        Console.WriteLine("You should remember from the Notes lesson that 'B & C', and 'E & F' are not separated by black keys.");
        Console.WriteLine("All other adjacent letters make Whole-Steps.");
        Console.WriteLine();
        Console.WriteLine("Steps are used in succession to make up scales like this:");
        Console.WriteLine("W W H W W W H (the major scale)");
        Console.WriteLine();
        Console.WriteLine("Skips are used with Pentatonic scales, and some other scales like Harmonic Minor.");
        Console.WriteLine();
    });

}
