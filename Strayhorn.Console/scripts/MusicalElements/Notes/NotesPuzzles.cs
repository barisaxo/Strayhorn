using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory;

namespace Strayhorn.Practice;

public class NotePuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();

    public PuzzleType PuzzleType { get; }
    public int NumOfNotes => 1;
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch[] PuzzleNotes { get; }

    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        SelectedNotes.Sort();
        foreach (var n in SelectedNotes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in PuzzleNotes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }

    public string Desc => $"Identify the{(PuzzleType is PuzzleType.Theory ? " " + Note.PitchClass.Name + " " : " ")}note";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    public string Hint => "D is always between the group with two black keys." +
                        "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B" +
                        "\nSharp (#) = +1.   Flat (b) = -1.";

    public bool CheckAnswer()
    {
        return SelectedNotes[0].Chromatic == Note.Chromatic;
    }

    public NotePuzzle(PuzzleType puzzleType, IPitchClass pitchClass)
    {
        PuzzleType = puzzleType;
        int octave;
        if (pitchClass.Letter is MusicTheory.Letters.C && pitchClass.Accidental is Flat or DoubleFlat) octave = 4;
        else if (pitchClass.Letter is MusicTheory.Letters.B && pitchClass.Accidental is Sharp or DoubleSharp) octave = 3;
        else octave = new Random().Next(3, 5);
        Gamut = new Pitch(pitchClass: pitchClass, octave);
        PuzzleNotes = [Note];
    }
}

// public class NotePractice1 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();
//     public int NumOfNotes => 1;
//     public List<Pitch> SelectedNotes { get; set; } = [];
//     public Pitch BottomNote { get; }
//     public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         SelectedNotes.Sort();
//         foreach (var n in SelectedNotes) notes.Add(([n], 750, .7f));
//         return [.. notes];
//     }
//     public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         foreach (var n in PuzzleNotes) notes.Add(([n], 750, .7f));
//         return [.. notes];
//     }
//     public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
//     public Pitch[]? ActiveNotes { get; set; } = null;
//     public Pitch[] PuzzleNotes { get; }
//     public string Desc => $"Identify the {Note.PitchClass.Name} note";
//     public string Answer => Note.PitchClass.Name;
//     public bool ShouldHintDisplay { get; set; }
//     public bool PuzzleIsComplete { get; set; }
//     public string Hint =>
//         "D is always between the group with two black keys." +
//         "\nThe notes of the keyboard: C‾D‾EF‾G‾A‾BC‾D‾EF‾G‾A‾B";// +

//     public NotePractice1()
//     {
//         Random random = new();

//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = new Natural();

//         IPitchClass pitchClass = IPitchClass.Get(letter, accidental);
//         int octave = random.Next(3, 5);

//         Pitch newPitch = new(pitchClass, octave);

//         Gamut = newPitch;
//         PuzzleNotes = [newPitch];
//     }

//     public void DrawQuestion()
//     {
//         PianoScroll.DrawTwoOctavePianoQuestionWithCarat(BottomNote, [.. SelectedNotes], Caret, ActiveNotes);
//     }

//     public bool CheckAnswer()
//     {
//         return SelectedNotes[0].Chromatic == Note.Chromatic;
//     }
// }


// public class NotePractice2 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();
//     public int NumOfNotes => 1;
//     public List<Pitch> SelectedNotes { get; set; } = [];
//     public Pitch BottomNote { get; }
//     public Pitch[]? ActiveNotes { get; set; } = null;
//     public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
//     public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         SelectedNotes.Sort();
//         foreach (var n in SelectedNotes) notes.Add(([n], 750, .7f));
//         return [.. notes];
//     }
//     public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         foreach (var n in PuzzleNotes) notes.Add(([n], 750, .7f));
//         return [.. notes];
//     }

//     public Pitch[] PuzzleNotes { get; }
//     public string Desc => $"Identify the {Note.PitchClass.Name} note";
//     public string Answer => Note.PitchClass.Name;
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     public string Hint =>
//         "D is always between the group with two black keys." +
//         "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B" +
//         "\nSharp (#) = +1.   Flat (b) = -1.";

//     public NotePractice2()
//     {
//         Random random = new();

//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = random.Next(0, 2) switch { 0 => new Flat(), _ => new Sharp() };

//         if (letter is MusicTheory.Letters.C or MusicTheory.Letters.F) accidental = new Sharp();
//         else if (letter is MusicTheory.Letters.B or MusicTheory.Letters.E) accidental = new Flat();
//         int octave = random.Next(3, 5);

//         IPitchClass pitchClass = IPitchClass.Get(letter, accidental);

//         PuzzleNotes = [new Pitch(pitchClass: pitchClass, octave)];
//         Gamut = PuzzleNotes[0];
//     }

//     public void DrawQuestion()
//     {
//         PianoScroll.DrawTwoOctavePianoQuestionWithCarat(BottomNote, [.. SelectedNotes], Caret, ActiveNotes);
//     }

//     public bool CheckAnswer()
//     {
//         return SelectedNotes[0].Chromatic == Note.Chromatic;
//     }
// }


// public class NotePractice3 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();
//     public int NumOfNotes => 1;
//     public List<Pitch> SelectedNotes { get; set; } = [];
//     public Pitch BottomNote { get; }
//     public Pitch[]? ActiveNotes { get; set; }
//     public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         SelectedNotes.Sort();
//         foreach (var n in SelectedNotes) notes.Add(([n], 750, .7f));
//         return [.. notes];
//     }
//     public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         foreach (var n in PuzzleNotes) notes.Add(([n], 750, .7f));
//         return [.. notes];
//     }

//     public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
//     public Pitch[] PuzzleNotes { get; }
//     public string Desc => $"Identify the {Note.PitchClass.Name} note";
//     public string Answer => Note.PitchClass.Name;
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     public string Hint =>
//         "D is always between the group with two black keys." +
//         "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B" +
//         "\nSharp (#) = +1.   Flat (b) = -1.";

//     public NotePractice3()
//     {
//         Random random = new();

//         ILetter letter = random.Next(0, 5) switch
//         {
//             0 => new MusicTheory.Letters.C(),
//             1 => new MusicTheory.Letters.B(),
//             2 => new MusicTheory.Letters.E(),
//             _ => new MusicTheory.Letters.F(),
//         };
//         IAccidental accidental = letter is MusicTheory.Letters.C or MusicTheory.Letters.F ? new Flat() : new Sharp();
//         int octave = letter is MusicTheory.Letters.C ? 4 : letter is MusicTheory.Letters.B ? 3 : random.Next(3, 5);
//         IPitchClass pitchClass = IPitchClass.Get(letter, accidental);

//         PuzzleNotes = [new Pitch(pitchClass: pitchClass, octave)];
//         Gamut = PuzzleNotes[0];
//     }

//     public void DrawQuestion()
//     {
//         PianoScroll.DrawTwoOctavePianoQuestionWithCarat(BottomNote, [.. SelectedNotes], Caret, ActiveNotes);
//     }

//     public bool CheckAnswer()
//     {
//         return SelectedNotes[0].Chromatic == Note.Chromatic;
//     }
// }

