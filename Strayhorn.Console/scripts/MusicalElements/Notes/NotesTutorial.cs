using Strayhorn.Systems.Display;

namespace Strayhorn.Tutorials;

public class NotesTutorialP1 : ITutorial
{
    public ITutorial? PrevPage() => null;
    public ITutorial? NextPage() => new NotesTutorialP2();
    public IDisplay Display { get; }

    public NotesTutorialP1()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine("(p1 of 4)\n");
        PianoScroll.DrawTwoOctavePiano();

        Console.WriteLine("\nNOTES:");
        Console.WriteLine("There are 7 'white keys' or natural notes: A B C D E F G. ");
        Console.WriteLine("There are 5 'black keys', which repeat in groups of two and three.");

        Console.WriteLine("\nThe letters 'B & C', and 'E & F' don't have black keys between them.");
        Console.WriteLine("In between the group of the two black keys is always the note D.");
    }
}

public class NotesTutorialP2 : ITutorial
{
    const string b = "♭";
    const string s = "♯";
    const string x = "𝄪";
    const string n = "♮";
    const string d = "𝄫";

    public ITutorial? PrevPage() => new NotesTutorialP1();
    public ITutorial? NextPage() => new NotesTutorialP3();
    public IDisplay Display { get; }

    public NotesTutorialP2()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine("(p2 of 4)");
        Console.WriteLine("\nACCIDENTALS:");
        Console.WriteLine($"{s} = Sharp = +1");
        Console.WriteLine($"{b} = Flat = -1");
        Console.WriteLine($"{n} = Natural = White Key (cancels out any sharps or flats)");

        Console.WriteLine("\nDouble accidentals also exist, but they are not extremely common.");
        Console.WriteLine($"{x} = Double Sharp = +2");
        Console.WriteLine($"{d} = Double Flat = -2");
    }
}

public class NotesTutorialP3 : ITutorial
{
    const string b = "♭";
    const string s = "♯";
    const string x = "𝄪";
    const string n = "♮";
    const string d = "𝄫";

    public ITutorial? PrevPage() => new NotesTutorialP2();
    public ITutorial? NextPage() => new NotesTutorialP4();
    public IDisplay Display { get; }

    public NotesTutorialP3()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();

        Console.WriteLine("(p3 of 4)");
        Console.WriteLine("\nENHARMONIC EQUIVALENCE: (Overlap in note names)");
        PianoScroll.Draw(PianoScroll.OneOctaveWithEnharmonicBlack);
        Console.WriteLine($"Black keys are always {s} or {b}:");
        Console.WriteLine($"\nC{s} = D{b}, D{s} = E{b}, F{s} = G{b}, G{s} = A{b}, A{s} = B{b} ");
    }
}

public class NotesTutorialP4 : ITutorial
{
    const string b = "♭";
    const string s = "♯";
    const string x = "𝄪";
    const string n = "♮";
    const string d = "𝄫";

    public ITutorial? PrevPage() => new NotesTutorialP3();
    public ITutorial? NextPage() => null;
    public IDisplay Display { get; }

    public NotesTutorialP4()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine("(p4 of 4)\n");
        PianoScroll.Draw(PianoScroll.OneOctaveWithEnharmonicWhite);
        Console.WriteLine("\nSome white keys can also be {s} or b.");
        Console.WriteLine("\nThis is because the keys B & C, and E & F are adjacent,");
        Console.WriteLine("there are no black keys separating them.");
        Console.WriteLine($"\nB{s} = C, C{b} = B, E{s} = F, F{b} = E");
    }
}
