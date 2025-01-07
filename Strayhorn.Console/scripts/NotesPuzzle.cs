using MusicTheory.Intervals;
using MusicTheory.Notes;
using MusicTheory.Letters;
using Strayhorn.Menus;
using Strayhorn.Systems.Commands;
using MusicTheory;

namespace Strayhorn.Puzzles.Notes;

public class NotesMenu : ICommand
{
    public bool DisplayInput { get; set; } = true;
    public void Execute() => CommandCenter.PrintCommands(Commands);
    public ICommand[] Commands { get; }
    public TriggerType TriggerType => TriggerType.ReadLine;
    public string Desc { get; set; }
    public string TriggerString { get; set; }
    public ConsoleKey TriggerKey { get; set; }
    readonly ICommand Finish;

    public NotesMenu(
        ICommand prev,
        string desc = "",
        string triggerString = "",
        ConsoleKey triggerKey = ConsoleKey.None)
    {
        Finish = prev;
        Finish.TriggerString = "x";
        Finish.Desc = "Back";

        Commands =
        [
            new NotesPuzzleTutorialP1(Finish, prev: this, desc: "About Notes", triggerString: "0"),
            // new Puzzle1(this),
            // new(id:"0", "About Notes", new NotesPuzzle().AboutNotesP1, prevMenu),
            // new(id:"1", "Natural Notes - no Accidentals", () => new NotesPuzzle().EasyNotes(), prevMenu),
            // new(id:"2", "Accidentals - Sharps and Flats", () => new NotesPuzzle().MediumNotes(null, null), prevMenu),
            // new("3", "Double Sharps and Flats", HardNotes),
            // new("4", "Natural and Accidentals", HardNotes),
            // new Command(Finish, "x", null, "Back")
            Finish
        ];

        Desc = desc;
        TriggerString = triggerString;
        TriggerKey = triggerKey;
    }



}


public class NotesPuzzleTutorialP1 : ICommand
{
    public bool DisplayInput { get; set; } = false;
    public ICommand[] Commands { get; }
    public TriggerType TriggerType => TriggerType.ReadKey;
    public string Desc { get; set; }
    public string TriggerString { get; set; }
    public ConsoleKey TriggerKey { get; set; }
    readonly ICommand Finish;

    public NotesPuzzleTutorialP1(
        ICommand finish,
        ICommand prev,
        string desc = "",
        string triggerString = "",
        ConsoleKey triggerKey = ConsoleKey.None)
    {
        Finish = finish;
        prev.TriggerKey = ConsoleKey.LeftArrow;
        Commands = [
            prev,
            new NotesPuzzleTutorialP2(Finish, this, "", "", ConsoleKey.RightArrow)
        ];

        Desc = desc;
        TriggerString = triggerString;
        TriggerKey = triggerKey;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("(p1 of 4)\n");
        PianoScroll.DrawTwoOctavePiano();

        Console.WriteLine("\nNOTES:");
        Console.WriteLine("There are 7 'white keys' or natural notes: A B C D E F G. ");
        Console.WriteLine("There are 5 'black keys', which repeat in groups of two and three.");

        Console.WriteLine("\nThe letters 'B & C', and 'E & F' don't have black keys between them.");
        Console.WriteLine("In between the group of the two black keys is always the note D.");

        Console.WriteLine("\n\n(use ← → keys to navigate)\n");
    }
}

public class NotesPuzzleTutorialP2 : ICommand
{
    const string b = "♭";
    const string s = "♯";
    const string x = "𝄪";
    const string n = "♮";
    const string d = "𝄫";


    public bool DisplayInput { get; set; } = false;
    public ICommand[] Commands { get; }
    public TriggerType TriggerType => TriggerType.ReadKey;
    public string Desc { get; set; }
    public string TriggerString { get; set; }
    public ConsoleKey TriggerKey { get; set; }
    readonly ICommand Finish;

    public NotesPuzzleTutorialP2(
       ICommand finish,
       ICommand prev,
       string desc = "",
       string triggerString = "",
       ConsoleKey triggerKey = ConsoleKey.None)
    {
        Finish = finish;
        prev.TriggerKey = ConsoleKey.LeftArrow;
        Commands = [
            prev,
            new NotesPuzzleTutorialP3(Finish, this, "", "", ConsoleKey.RightArrow)
        ];

        Desc = desc;
        TriggerString = triggerString;
        TriggerKey = triggerKey;
    }

    public void Execute()
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
        Console.WriteLine("\n\n(use ← → keys to navigate)\n");
    }
}



public class NotesPuzzleTutorialP3 : ICommand
{
    const string b = "♭";
    const string s = "♯";

    public bool DisplayInput { get; set; } = false;
    public ICommand[] Commands { get; }
    public TriggerType TriggerType => TriggerType.ReadKey;
    public string Desc { get; set; }
    public string TriggerString { get; set; }
    public ConsoleKey TriggerKey { get; set; }
    readonly ICommand Finish;

    public NotesPuzzleTutorialP3(
        ICommand finish,
        ICommand prev,
        string desc = "",
        string triggerString = "",
        ConsoleKey triggerKey = ConsoleKey.None)
    {
        Finish = finish;
        prev.TriggerKey = ConsoleKey.LeftArrow;

        Commands = [
            prev,
            new NotesPuzzleTutorialP4(Finish, this, "", "", ConsoleKey.RightArrow)
        ];

        Desc = desc;
        TriggerString = triggerString;
        TriggerKey = triggerKey;
    }

    public void Execute()
    {
        Console.Clear();

        Console.WriteLine("(p3 of 4)");
        Console.WriteLine("\nENHARMONIC EQUIVALENCE: (Overlap in note names)");
        PianoScroll.Draw(PianoScroll.OneOctaveWithEnharmonicBlack);
        Console.WriteLine($"Black keys are always {s} or {b}:");
        Console.WriteLine($"\nC{s} = D{b}, D{s} = E{b}, F{s} = G{b}, G{s} = A{b}, A{s} = B{b} ");

        Console.WriteLine("\n\n(use ← → keys to navigate)\n");
    }
}


public class NotesPuzzleTutorialP4 : ICommand
{
    const string b = "♭";
    const string s = "♯";

    public bool DisplayInput { get; set; } = false;
    public ICommand[] Commands { get; }
    public TriggerType TriggerType => TriggerType.ReadKey;
    public string Desc { get; set; }
    public string TriggerString { get; set; }
    public ConsoleKey TriggerKey { get; set; }
    readonly ICommand Finish;

    public NotesPuzzleTutorialP4(
        ICommand finish,
        ICommand prev,
        string desc = "",
        string triggerString = "",
        ConsoleKey triggerKey = ConsoleKey.None)
    {
        Finish = finish;
        Finish.TriggerKey = ConsoleKey.RightArrow;
        prev.TriggerKey = ConsoleKey.LeftArrow;

        Commands = [
            prev,
            Finish
        ];

        Desc = desc;
        TriggerString = triggerString;
        TriggerKey = triggerKey;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("(p4 of 4)\n");
        PianoScroll.Draw(PianoScroll.OneOctaveWithEnharmonicWhite);
        Console.WriteLine("\nSome white keys can also be {s} or b.");
        Console.WriteLine("\nThis is because the keys B & C, and E & F are adjacent,");
        Console.WriteLine("there are no black keys separating them.");
        Console.WriteLine($"\nB{s} = C, C{b} = B, E{s} = F, F{b} = E");
        Console.WriteLine("\n\n(use ← → keys to navigate)\n");
    }
}

public class NotePuzzle1 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();

    public int NumOfNotes => 1;
    public Pitch[] Notes { get; }

    public string Desc => "Identify the note in question...\n" +
        "(Answer with single uppercase letter A, B, C, D, E, F, G)";
    public string PuzzleGamut => "Note";
    public string Question => Note.PitchClass.Name;
    public string Hint =>
        "\n\nD is always between the group with two black keys." +
        "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_BC" +
        "\nSharp (#) = +1.   Flat (b) = -1.";

    public string Arg { get; set; } = "";
    public string ValidationError { get; } = "Invalid answer. Please enter a single uppercase letter: A, B, C, D, E, F, G.";

    public NotePuzzle1()
    {
        Random random = new();

        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = new Natural();

        IPitchClass pitchClass = IPitchClass.Get(letter, accidental);
        int octave = random.Next(3, 5);

        Pitch newPitch = new(pitchClass, octave);

        Gamut = newPitch;
        Notes = new Pitch[NumOfNotes];
        Notes[0] = newPitch;
    }

    public void PrintQuestion()
    {
        Console.Clear();
        Console.WriteLine(Desc);
        Console.WriteLine();
        PianoScroll.DrawTwoOctaveQuestion(Notes);
        Console.WriteLine();
    }

    public bool ValidateArg()
    {
        try
        {
            _ = ILetter.GetAll().Single(l => l.Name == Arg);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool CheckAnswer()
    {
        return Arg == Notes[0].PitchClass.Letter.Name;
    }

}

public class NotesPuzzle
{

    const string b = "♭";
    const string s = "♯";
    const string x = "𝄪";
    const string n = "♮";
    const string d = "𝄫";



    // public void AboutNotesP1()
    // {
    //     Console.Clear();
    //     Console.WriteLine("(p1 of 4)");
    //     PianoScroll.DrawTwoOctavePiano();

    //     Console.WriteLine("\nNOTES:");
    //     Console.WriteLine("There are 7 'white keys' or natural notes: A B C D E F G. ");
    //     Console.WriteLine("There are 5 'black keys', which repeat in groups of two and three.");

    //     Console.WriteLine("\nThe letters 'B & C', and 'E & F' don't have black keys between them.");
    //     Console.WriteLine("In between the group of the two black keys is always the note D.");

    //     Console.WriteLine("\n(use ← → keys to navigate)\n");
    // }

    // void AboutNotesP2()
    // {
    //     Console.Clear();
    //     Console.WriteLine("(p2 of 4)");
    //     Console.WriteLine("");
    //     Console.WriteLine("ACCIDENTALS:");
    //     Console.WriteLine($"{s} = Sharp = +1");
    //     Console.WriteLine($"{b} = Flat = -1");
    //     Console.WriteLine($"{n} = Natural = White Key (cancels out any sharps or flats)");
    //     Console.WriteLine("");

    //     Console.WriteLine("Double accidentals also exist, but they are not extremely common.");
    //     Console.WriteLine($"{x} = Double Sharp = +2");
    //     Console.WriteLine($"{d} = Double Flat = -2");
    //     Console.WriteLine("");

    //     Console.WriteLine("");
    //     Console.WriteLine("(use ← → keys to navigate)");
    //     Console.WriteLine("");

    //     switch (Console.ReadKey().Key)
    //     {
    //         case ConsoleKey.RightArrow:
    //             AboutNotesP3();
    //             break;
    //         case ConsoleKey.LeftArrow:
    //             AboutNotesP1();
    //             break;
    //         default:
    //             AboutNotesP2();
    //             break;
    //     }
    // }

    // void AboutNotesP3()
    // {
    //     Console.Clear();
    //     Console.WriteLine("(p3 of 4)");
    //     Console.WriteLine("");
    //     Console.WriteLine("ENHARMONIC EQUIVALENCE: (Overlap in note names)");
    //     PianoScroll.Draw(PianoScroll.OneOctaveWithEnharmonicBlack);
    //     Console.WriteLine($"Black keys are always {s} or {b}:");
    //     Console.WriteLine("");
    //     Console.WriteLine($"C{s} = D{b}, D{s} = E{b}, F{s} = G{b}, G{s} = A{b}, A{s} = B{b} ");

    //     Console.WriteLine("");
    //     Console.WriteLine("");
    //     Console.WriteLine("(use ← → keys to navigate)");
    //     Console.WriteLine("");

    //     switch (Console.ReadKey().Key)
    //     {
    //         case ConsoleKey.RightArrow:
    //             AboutNotesP4();
    //             break;
    //         case ConsoleKey.LeftArrow:
    //             AboutNotesP2();
    //             break;
    //         default:
    //             AboutNotesP3();
    //             break;
    //     }
    // }

    // void AboutNotesP4()
    // {
    //     Console.Clear();
    //     Console.WriteLine("(p4 of 4)");
    //     Console.WriteLine("");
    //     PianoScroll.Draw(PianoScroll.OneOctaveWithEnharmonicWhite);
    //     Console.WriteLine("Some white keys can also be {s} or b.");
    //     Console.WriteLine("");
    //     Console.WriteLine("This is because the keys B & C, and E & F are adjacent,");
    //     Console.WriteLine("there are no black keys separating them.");
    //     Console.WriteLine("");
    //     Console.WriteLine($"B{s} = C, C{b} = B, E{s} = F, F{b} = E");
    //     Console.WriteLine("");

    //     Console.WriteLine("");
    //     Console.WriteLine("(use ← → keys to navigate)");
    //     Console.WriteLine("");

    //     switch (Console.ReadKey().Key)
    //     {
    //         case ConsoleKey.RightArrow:
    //             MenuSystems.ActivateMenu(this, null);
    //             break;
    //         case ConsoleKey.LeftArrow:
    //             AboutNotesP3();
    //             break;
    //         default:
    //             AboutNotesP4();
    //             break;
    //     }
    // }

    public void EasyNotes(Pitch[]? notes = null, string? answer = null)
    {
        //Generate new question
        if (notes == null)
        {
            Random random = new();

            var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
            IAccidental accidental = new Natural();
            IPitchClass pitchClass = IPitchClass.Get(letter, accidental);
            int octave = random.Next(3, 5);

            notes = [new Pitch(pitchClass: pitchClass, octave)];
        }


        //Print the question & get user answer
        PrintQuestion(notes);
        if (answer == null)
        {
            //Recursion here for cleaner presentation
            EasyNotes(notes, Console.ReadLine());
            return;
        }
        Console.WriteLine($"You answered: {answer}");


        //Validate answer format
        try
        {
            _ = ILetter.GetAll().Single(l => l.Name == answer);
        }
        catch
        {
            Console.WriteLine("Invalid answer. Please enter a single uppercase letter: A, B, C, D, E, F, G.");
            EasyNotes(notes, Console.ReadLine());
            return;
        }


        //Check if the answer is correct and finish
        if (answer == notes[0].PitchClass.Letter.Name) Console.WriteLine("That is correct!");
        else Console.WriteLine($"That is incorrect. The answer is {notes?[0].PitchClass.Letter.Name}");
        FinishPuzzle();
        return;


        static void PrintQuestion(Pitch[] notes)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Identify the note in question...");
            Console.WriteLine("(Answer with single uppercase letter A, B, C, D, E, F, G)");
            PianoScroll.DrawTwoOctaveQuestion(notes);
            Console.WriteLine("");
        }
    }

    public void MediumNotes(Pitch[]? notes, string? answer)
    {
        //Generate new question
        if (notes == null)
        {
            Random random = new();

            var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
            var accidental = IAccidental.GetAll().ToList()[random.Next(1, IAccidental.GetAll().Count() - 1)];
            int octave = 3;

            if (letter is MusicTheory.Letters.C && accidental is Flat) octave = 4;
            else if (letter is MusicTheory.Letters.B && accidental is Sharp) octave = 3;
            else octave = random.Next(3, 5);

            IPitchClass pitchClass = IPitchClass.Get(letter, accidental);

            notes = [new Pitch(pitchClass: pitchClass, octave)];
        }


        //Print the question & get user answer
        PrintQuestion(notes);
        if (answer == null)
        {
            //Recursion here for cleaner presentation
            MediumNotes(notes, Console.ReadLine());
            return;
        }
        Console.WriteLine($"You answered: {answer}");


        //Validate answer format
        try
        {
            _ = ILetter.GetAll().Single(l => l.Name == answer[0].ToString());
            if (answer.Length > 2 || (answer.Length > 1 && answer[1] != 'b' && answer[1] != '#'))
                throw new System.Exception();
        }
        catch
        {
            Console.WriteLine("Invalid answer. Please format your answer as: C, Db, F#, etc...");
            MediumNotes(notes, Console.ReadLine());
            return;
        }


        //Parse answer
        var answerLetter = ILetter.GetAll().Single(s => s.Name == answer[0].ToString());
        IAccidental answerAccidental = answer.Length == 1 ? new Natural() :
        IAccidental.GetAll().Single(s => s.Ascii == answer[1].ToString());
        IPitchClass pcAnswer = IPitchClass.Get(answerLetter, answerAccidental);

        //Check if the answer is correct and finish
        if (pcAnswer.Chromatic.Value == notes[0].Chromatic.Value) Console.WriteLine("That is correct!");
        else Console.WriteLine($"That is incorrect. The answer is {notes?[0].PitchClass.Name}");
        FinishPuzzle();
        return;

        static void PrintQuestion(Pitch[] notes)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Identify the note in question:");
            Console.WriteLine("(Format your answer as: C, Db, F#, etc...)");
            PianoScroll.DrawTwoOctaveQuestion(notes);
            Console.WriteLine("");
        }
    }

    void FinishPuzzle()
    {
        Console.WriteLine("");
        Console.WriteLine("(press any key to continue...)");
        Console.ReadKey(true);
        // MenuSystems.ActivateMenu(this, null);
    }

    // public static void HardNotes()
    // {
    //     Console.WriteLine("");
    //     Console.WriteLine("Not Yet Implemented (press any key to continue...)");
    //     Console.ReadKey(true);
    //     MenuSystems.ActivateMenu(MenuItems, null);
    // }


}

// public class NotesPuzzle1 //: ICommand
// {
//     //Func<string?, Action> ICommand.Do => throw new NotImplementedException();

//     public void Puzzle(Pitch[]? notes = null, string? answer = null)
//     {
//         //Generate new question
//         if (notes == null)
//         {
//             Random random = new();

//             var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//             IAccidental accidental = new Natural();
//             IPitchClass pitchClass = IPitchClass.Get(letter, accidental);
//             int octave = random.Next(3, 5);

//             notes = [new Pitch(pitchClass: pitchClass, octave)];
//         }


//         //Print the question & get user answer
//         PrintQuestion(notes);
//         if (answer == null)
//         {
//             //Recursion here for cleaner presentation
//             EasyNotes(notes, Console.ReadLine());
//             return;
//         }
//         Console.WriteLine($"You answered: {answer}");


//         //Validate answer format
//         try
//         {
//             _ = ILetter.GetAll().Single(l => l.Name == answer);
//         }
//         catch
//         {
//             Console.WriteLine("Invalid answer. Please enter a single uppercase letter: A, B, C, D, E, F, G.");
//             EasyNotes(notes, Console.ReadLine());
//             return;
//         }


//         //Check if the answer is correct and finish
//         if (answer == notes[0].PitchClass.Letter.Name) Console.WriteLine("That is correct!");
//         else Console.WriteLine($"That is incorrect. The answer is {notes?[0].PitchClass.Letter.Name}");
//         FinishPuzzle();
//         return;


//         static void PrintQuestion(Pitch[] notes)
//         {
//             Console.Clear();
//             Console.WriteLine("");
//             Console.WriteLine("Identify the note in question...");
//             Console.WriteLine("(Answer with single uppercase letter A, B, C, D, E, F, G)");
//             PianoScroll.DrawTwoOctaveQuestion(notes);
//             Console.WriteLine("");
//         }
//     }



// }  // class TutorialStartCommand(ICommandConsole prev, string? trigger, ConsoleKey? key, string? desc, ICommandConsole finish) : ICommand
// {
//     public ICommandConsole NextConsole { get; } = new NotesPuzzleTutorialP1(prev);
//     public string? TriggerString => trigger;
//     public ConsoleKey? TriggerKey => key;
//     public string Desc => desc ?? "";
// }

// class Puzzle1(ICommandConsole prev) : ICommand
// {
//     public string? TriggerString => "0";
//     public ConsoleKey? TriggerKey => throw new NotImplementedException();
//     public ICommandConsole Next { get; } = new NotesPuzzleTutorialP1(prev);
//     public void Execute() { }
// }
// class Command(ICommandConsole console, string? trigger, ConsoleKey? key, string? desc) : ICommand
// {
//     public ICommandConsole NextConsole => console;
//     public string? TriggerString => trigger;
//     public ConsoleKey? TriggerKey => key;
//     public string Desc => desc ?? "";
// }

// class NextCommand(ICommandConsole next) : ICommand
// {
//     public string? TriggerString => throw new NotImplementedException();
//     public ConsoleKey? TriggerKey => ConsoleKey.RightArrow;
//     public ICommandConsole NextConsole => next;
//     public void Execute() { }
// }