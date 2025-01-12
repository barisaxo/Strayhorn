using MusicTheory.Intervals;
using MusicTheory.Notes;
using MusicTheory.Scales;
using MusicTheory.Modes;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

public class ModePractice1 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IMode Mode => Gamut is IMode mode ? mode : throw new System.ArgumentNullException();
    public int NumOfNotes => 8;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
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
    public string Desc => $"Build the {Mode.Name} Scale";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = string.Empty;
        int mode = Mode.ModeNumber();

        for (int i = 0; i < Mode.Parent.Steps.Length; i++)
            temp += Mode.Parent.Steps[(mode + i) % Mode.Parent.Steps.Length].Abbrev + ' ';

        temp += "\n";

        for (int i = 0; i < Mode.Parent.ScaleDegrees.Length; i++) temp +=
        IInterval.GetInterval(
            Mode.Parent.ScaleDegrees[mode],
            Mode.Parent.ScaleDegrees[(mode + i) % Mode.Parent.ScaleDegrees.Length]).ScaleDegree + ' ';

        temp += "1";
        return temp;
    }
    private string? _hint = null;
    public string Hint => _hint ??= GetHint();

    public ModePractice1()
    {
        Random rand = new();
        MusicTheory.Scales.Major scale = new();
        int length = scale.Modes.Length;
        int mode = rand.Next(0, length);
        Gamut = scale.Modes[mode];

        IPitchClass[] keys =
            [new C(), new F(), new Bb(), new Eb(), new Ab(), new Db(),
             new Fs(), new B(), new E(), new A(), new D(), new G()];

        Pitch[] notes = new Pitch[scale.ScaleDegrees.Length + 1];
        Bottom = new(keys[rand.Next(0, keys.Length)], octave: 3);
        IPitchClass parent = IPitchClass.GetPitchClassAbove(Bottom.PitchClass, IInterval.Invert(scale.ScaleDegrees[mode]));
        Selected.Add(Bottom);
        notes[0] = Bottom;
        notes[^1] = new Pitch(Bottom.PitchClass, Bottom.Octave + 1);

        for (int i = 1; i < notes.Length - 1; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(parent, scale.ScaleDegrees[(i + mode) % length]);
            notes[i] = new Pitch(pc, octave: Bottom.Octave + (Bottom.PitchID > Pitch.GetPitchID(pc, Bottom.Octave) ? 1 : 0));
        }
        Notes = notes;
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


public class ModePractice2 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IMode Mode => Gamut is IMode mode ? mode : throw new System.ArgumentNullException();
    public int NumOfNotes { get; }
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
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
    public string Desc => $"Build the {Mode.Name} scale ({(Mode.ModeNumber() + 1).ToOrdinal()} mode of the {Mode.Parent.Name} scale).";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = string.Empty;
        int mode = Mode.ModeNumber();

        for (int i = 0; i < Mode.Parent.Steps.Length; i++)
            temp += Mode.Parent.Steps[(mode + i) % Mode.Parent.Steps.Length].Abbrev + ' ';

        temp += "\n";

        for (int i = 0; i < Mode.Parent.ScaleDegrees.Length; i++)
            temp += IInterval.GetInterval(
                Mode.Parent.ScaleDegrees[mode],
                Mode.Parent.ScaleDegrees[(mode + i) % Mode.Parent.ScaleDegrees.Length]).ScaleDegree + ' ';

        temp += "1";
        return temp;
    }
    private string? _hint = null;
    public string Hint => _hint ??= GetHint();

    public ModePractice2()
    {
        Random rand = new();
        IPitchClass[] keys =
            [new C(), new F(), new Bb(), new Eb(), new Ab(), new Db(),
             new Fs(), new B(), new E(), new A(), new D(), new G()];
        var scales = IScale.GetAll().ToList();
        scales.Remove(new MusicTheory.Scales.Chromatic());
        scales.Remove(new MusicTheory.Scales.WholeTone());
        IScale scale = scales[rand.Next(0, scales.Count)];
        int scaleLength = scale.ScaleDegrees.Length;
        int mode = rand.Next(1, scale.Modes.Length);
        Pitch[] notes = new Pitch[scale.ScaleDegrees.Length + 1];

        Gamut = scale.Modes[mode];
        NumOfNotes = scaleLength + 1;

        Bottom = new(keys[rand.Next(0, keys.Length)], octave: 3);
        Selected.Add(Bottom);
        notes[0] = Bottom;
        notes[^1] = new Pitch(Bottom.PitchClass, Bottom.Octave + 1);

        List<IInterval> intervals = [];

        for (int i = 0; i < Mode.Parent.ScaleDegrees.Length; i++)
            intervals.Add(IInterval.GetInterval(
                Mode.Parent.ScaleDegrees[mode],
                Mode.Parent.ScaleDegrees[(mode + i) % Mode.Parent.ScaleDegrees.Length]));

        for (int i = 1; i < notes.Length - 1; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(Bottom.PitchClass, intervals[i]);
            notes[i] = new Pitch(pc, octave: Bottom.Octave + (Bottom.PitchID > Pitch.GetPitchID(pc, Bottom.Octave) ? 1 : 0));
        }

        Notes = notes;
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