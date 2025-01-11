using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory;

namespace Strayhorn.Puzzles;

public class NotePuzzle1 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();

    public int NumOfNotes => 1;
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .7f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }

    public Pitch Carat { get; set; } = new(new MusicTheory.Notes.C(), 4);
    public Pitch[]? Playing { get; set; } = null;
    public Pitch[] Notes { get; }
    public string Desc => $"Identify the {Note.PitchClass.Name} note";
    public string Answer => Note.PitchClass.Name;
    public bool HintFlag { get; set; }
    public bool PuzzleComplete { get; set; }
    public string Hint =>
        "D is always between the group with two black keys." +
        "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B";// +

    public NotePuzzle1()
    {
        Random random = new();

        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = new Natural();

        IPitchClass pitchClass = IPitchClass.Get(letter, accidental);
        int octave = random.Next(3, 5);

        Pitch newPitch = new(pitchClass, octave);

        Gamut = newPitch;
        Notes = [newPitch];
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Carat, Playing);
    }

    public bool CheckAnswer()
    {
        if (Selected.Count == 1) return Selected[0].Chromatic == Note.Chromatic;
        return Carat.Chromatic == Note.Chromatic;
    }
}


public class NotePuzzle2 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();
    public int NumOfNotes => 1;
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; } = null;
    public Pitch Carat { get; set; } = new(new MusicTheory.Notes.C(), 4);
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .7f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }

    public Pitch[] Notes { get; }
    public string Desc => $"Identify the {Note.PitchClass.Name} note";
    public string Answer => Note.PitchClass.Name;
    public bool PuzzleComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint =>
        "D is always between the group with two black keys." +
        "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B" +
        "\nSharp (#) = +1.   Flat (b) = -1.";

    public NotePuzzle2()
    {
        Random random = new();

        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = random.Next(0, 2) switch { 0 => new Flat(), _ => new Sharp() };

        if (letter is MusicTheory.Letters.C or MusicTheory.Letters.F) accidental = new Sharp();
        else if (letter is MusicTheory.Letters.B or MusicTheory.Letters.E) accidental = new Flat();
        int octave = random.Next(3, 5);

        IPitchClass pitchClass = IPitchClass.Get(letter, accidental);

        Notes = [new Pitch(pitchClass: pitchClass, octave)];
        Gamut = Notes[0];
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Carat, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[0].Chromatic == Note.Chromatic;
    }
}

public class NotePuzzle3 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();
    public int NumOfNotes => 1;
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .7f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }

    public Pitch Carat { get; set; } = new(new MusicTheory.Notes.C(), 4);
    public Pitch[] Notes { get; }
    public string Desc => $"Identify the {Note.PitchClass.Name} note";
    public string Answer => Note.PitchClass.Name;
    public bool PuzzleComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint =>
        "D is always between the group with two black keys." +
        "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B" +
        "\nSharp (#) = +1.   Flat (b) = -1.";

    public NotePuzzle3()
    {
        Random random = new();

        ILetter letter = random.Next(0, 5) switch
        {
            0 => new MusicTheory.Letters.C(),
            1 => new MusicTheory.Letters.B(),
            2 => new MusicTheory.Letters.E(),
            _ => new MusicTheory.Letters.F(),
        };
        IAccidental accidental = letter is MusicTheory.Letters.C or MusicTheory.Letters.F ? new Flat() : new Sharp();
        int octave = letter is MusicTheory.Letters.C ? 4 : letter is MusicTheory.Letters.B ? 3 : random.Next(3, 5);
        IPitchClass pitchClass = IPitchClass.Get(letter, accidental);

        Notes = [new Pitch(pitchClass: pitchClass, octave)];
        Gamut = Notes[0];
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Carat, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[0].Chromatic == Note.Chromatic;
    }
}


public class NotePuzzle4 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();

    public int NumOfNotes => 1;
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .7f));
        return [.. notes];
    }

    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }

    public Pitch Carat { get; set; } = new(new MusicTheory.Notes.C(), 4);
    public Pitch[]? Playing { get; set; }
    public Pitch[] Notes { get; }
    public string Desc => $"Identify the {Note.PitchClass.Name} note";
    public string Answer => Note.PitchClass.Name;
    public bool PuzzleComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint =>
        "D is always between the group with two black keys." +
        "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B" +
        "\nSharp (#) = +1.   Flat (b) = -1.";

    public NotePuzzle4()
    {
        Random random = new();

        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        var accidental = IAccidental.GetAll().ToList()[random.Next(1, IAccidental.GetAll().Count() - 1)];
        int octave;
        if (letter is MusicTheory.Letters.C && accidental is Flat) octave = 4;
        else if (letter is MusicTheory.Letters.B && accidental is Sharp) octave = 3;
        else octave = random.Next(3, 5);

        IPitchClass pitchClass = IPitchClass.Get(letter, accidental);

        Notes = [new Pitch(pitchClass: pitchClass, octave)];
        Gamut = Notes[0];
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Carat, Playing);
    }

    public bool CheckAnswer(string arg)
    {
        var answerLetter = ILetter.GetAll().Single(s => s.Name == arg[0].ToString());
        IAccidental answerAccidental = arg.Length == 1 ? new Natural() :
            IAccidental.GetAll().Single(s => s.Ascii == arg[1].ToString());
        IPitchClass pcAnswer = IPitchClass.Get(answerLetter, answerAccidental);

        return pcAnswer.Chromatic == Notes[0].Chromatic;
    }

    public bool CheckAnswer()
    {
        return Selected[0].Chromatic == Note.Chromatic;
    }
}