using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory.Intervals;
using MusicTheory.Chords;
using MusicTheory;

namespace Strayhorn.Puzzles;

public class TriadPuzzle1 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public ITriad Triad => Gamut is ITriad Triad ? Triad : throw new System.ArgumentNullException();

    public int NumOfNotes => Triad.ChordTones.Length;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.C(), 4);
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .5f));
        notes.Add(([.. Selected], 1250, .5f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        notes.Add((Notes, 1250, .5f));
        return [.. notes];
    }

    public string Desc => $"Build a {Triad.Name} {nameof(Triad)}";
    public string Answer => Triad.Name;
    public bool PuzzleComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in Triad.ChordTones) temp += $"{ct.IntervalAbbrev} ";
        return temp;
    }
    public string Hint => GetHint();

    public TriadPuzzle1()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        ITriad[] standard = [new MajorTriad(), new MinorTriad()];
        Gamut = standard[random.Next(0, standard.Length)];

        int octave = 3;
        Pitch[] notes = new Pitch[Triad.ChordTones.Length];
        notes[0] = Bottom;
        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Triad.ChordTones[i], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave + (pc.Chromatic.Value < notes[0].Chromatic.Value ? 1 : 0));
        }

        Notes = notes;
        Bottom = Notes[0];
        Selected.Add(Bottom);
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        foreach (var p in Notes)
            try { _ = Selected.First(s => s.PitchID == p.PitchID); }
            catch { return false; }
        return true;
    }

}

public class TriadPuzzle2 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public ITriad Triad => Gamut is ITriad Triad ? Triad : throw new System.ArgumentNullException();

    public int NumOfNotes => Triad.ChordTones.Length;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.C(), 4);
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .5f));
        notes.Add(([.. Selected], 1250, .5f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        notes.Add((Notes, 1250, .5f));
        return [.. notes];
    }

    public string Desc => $"Build a {Triad.Name} {nameof(Triad)}";
    public string Answer => Triad.Name;
    public bool PuzzleComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in Triad.ChordTones) temp += $"{ct.IntervalAbbrev} ";
        return temp;
    }
    public string Hint => GetHint();

    public TriadPuzzle2()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        ITriad[] standard = [new AugmentedTriad(), new DiminishedTriad()];
        Gamut = standard[random.Next(0, standard.Length)];

        int octave = 3;
        Pitch[] notes = new Pitch[Triad.ChordTones.Length];
        notes[0] = Bottom;
        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Triad.ChordTones[i], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave + (pc.Chromatic.Value < notes[0].Chromatic.Value ? 1 : 0));
        }

        Notes = notes;
        Bottom = Notes[0];
        Selected.Add(Bottom);
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        foreach (var p in Notes)
            try { _ = Selected.First(s => s.PitchID == p.PitchID); }
            catch { return false; }
        return true;
    }

}

public class TriadPuzzle3 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public ITriad Triad => Gamut is ITriad Triad ? Triad : throw new System.ArgumentNullException();

    public int NumOfNotes => Triad.ChordTones.Length;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.C(), 4);
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .5f));
        notes.Add(([.. Selected], 1250, .5f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        notes.Add((Notes, 1250, .5f));
        return [.. notes];
    }

    public string Desc => $"Build a {Triad.Name} {nameof(Triad)}";
    public string Answer => Triad.Name;
    public bool PuzzleComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in Triad.ChordTones) temp += $"{ct.IntervalAbbrev} ";
        return temp;
    }
    public string Hint => GetHint();

    public TriadPuzzle3()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        ITriad[] standard = ITriad.GetAll().ToArray();
        Gamut = standard[random.Next(0, standard.Length)];

        int octave = 3;
        Pitch[] notes = new Pitch[Triad.ChordTones.Length];
        notes[0] = Bottom;
        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Triad.ChordTones[i], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave + (pc.Chromatic.Value < notes[0].Chromatic.Value ? 1 : 0));
        }

        Notes = notes;
        Bottom = Notes[0];
        Selected.Add(Bottom);
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        foreach (var p in Notes)
            try { _ = Selected.First(s => s.PitchID == p.PitchID); }
            catch { return false; }
        return true;
    }

}