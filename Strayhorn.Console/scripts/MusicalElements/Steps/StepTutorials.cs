using Strayhorn.Systems.Display;

namespace Strayhorn.Tutorials;

public class StepsTutorialP1 : ITutorial
{
    public ITutorial? PrevPage() => null;
    public ITutorial? NextPage() => new StepsTutorialP2();
    public IDisplay Display { get; }

    public StepsTutorialP1()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine("(p1 of 2)");
        Console.WriteLine();
        PianoScroll.DrawTwoOctavePiano();
        Console.WriteLine();

        Console.WriteLine("A Step is a type of interval for adjacent letters.");
        Console.WriteLine("Stepwise motion is defined as moving melodically up or down by letter.");
        Console.WriteLine("The type of step is determined by the distance of the two notes");
        Console.WriteLine();
        Console.WriteLine("There are three types of steps: ");
        Console.WriteLine("Half-Step (+1),");
        Console.WriteLine("Whole-Step (+2),");
        Console.WriteLine("Skip-Step (+3).");
        Console.WriteLine();
        Console.WriteLine("To abbreviate, we use 'H', 'W', and 'S' - respectively.");
        Console.WriteLine();
    }
}
public class StepsTutorialP2 : ITutorial
{
    public ITutorial? PrevPage() => new StepsTutorialP1();
    public ITutorial? NextPage() => null;
    public IDisplay Display { get; }

    public StepsTutorialP2()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine("(p2 of 2)");

        Console.WriteLine();
        PianoScroll.DrawTwoOctavePiano();
        Console.WriteLine();

        Console.WriteLine("The letters 'B & C', and 'E & F' make Half-Steps.");
        Console.WriteLine("You should remember from the Notes lesson that 'B & C', and 'E & F' are not separated by keys.");
        Console.WriteLine("All other adjacent letters make Whole-Steps.");
        Console.WriteLine();
        Console.WriteLine("Steps are used in succession to make up scales like this:");
        Console.WriteLine("W W H W W W H (the major scale)");
        Console.WriteLine();
        Console.WriteLine("Skips are used with Pentatonic scales, and some other scales like Harmonic Minor.");
        Console.WriteLine();
    }
}