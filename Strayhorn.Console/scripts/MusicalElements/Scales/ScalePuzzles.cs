using MusicTheory.Intervals;
using MusicTheory.Notes;
using MusicTheory.Scales;
using MusicTheory;

namespace Strayhorn.Puzzles;

public class ScalePuzzle1 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public IScale Scale => Gamut is IScale Scale ? Scale : throw new System.ArgumentNullException();
    public int NumOfNotes => 8;
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
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        return [.. notes];
    }
    public string Desc => $"Build the {Scale.Name} Scale";
    public bool PuzzleComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint =>
        @"1   2   3 4   5   6   7 1" + "\n" +
        @" \ / \ / ‾ \ / \ / \ / ‾ " + "\n" +
        @"  W   W  H  W   W   W  H " + "\n" + "\n";

    public ScalePuzzle1()
    {
        Gamut = new MusicTheory.Scales.Major();

        IPitchClass[] keys =
            [new C(), new F(), new Bb(), new Eb(), new Ab(), new Db(),
             new Fs(), new B(), new E(), new A(), new D(), new G()];

        int octave = 3;
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length + 1];
        notes[0] = new(keys[new Random().Next(0, keys.Length)], octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i], allowEnharmonicWhite: true);
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

public class ScalePuzzle2 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public IScale Scale => Gamut is IScale Scale ? Scale : throw new System.ArgumentNullException();
    public int NumOfNotes { get; }
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
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        return [.. notes];
    }
    public string Desc => $"Build the {Scale.Name} Scale";
    public bool PuzzleComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IStep step in Scale.Steps) temp += $"{step.Abbrev} ";
        return temp;
    }
    public string Hint => GetHint();

    public ScalePuzzle2()
    {
        Random rand = new();
        var scales = IScale.GetAll().ToArray();
        Gamut = scales[rand.Next(0, scales.Length)];
        NumOfNotes = Scale.ScaleDegrees.Length + 1;

        IPitchClass[] keys =
           [new C(), new F(), new Bb(), new Eb(), new Ab(), new Db(),
             new Fs(), new B(), new E(), new A(), new D(), new G()];

        int octave = 3;
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length + 1];
        notes[0] = new(keys[rand.Next(0, keys.Length)], octave);
        notes[^1] = new(notes[0].PitchClass, octave + 1);

        for (int i = 1; i < notes.Length - 1; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i], allowEnharmonicWhite: true);
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
