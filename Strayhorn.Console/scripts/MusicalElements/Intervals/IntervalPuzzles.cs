using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory.Intervals;
using MusicTheory;

namespace Strayhorn.Practice;

public class IntervalPractice1 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IInterval Interval => Gamut is IInterval Interval ? Interval : throw new System.ArgumentNullException();

    public int NumOfNotes => 2;
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

    public string Desc => $"Build a {Interval.Name} {nameof(Interval)}";
    public string Answer => Interval.Name;
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint => "P1 mi2 M2 mi3 M3 P4 TT P5 mi6 M6 mi7 M7 P8";

    public IntervalPractice1()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        IInterval[] standard = [
            new P1(), new mi2(), new M2(), new mi3(), new M3(), new P4(), new d5(), new P5(),
            new mi6(), new M6(), new mi7(), new M7(), new P8()
        ];
        Gamut = standard[random.Next(0, standard.Length)];

        IPitchClass topPC = IPitchClass.GetPitchClassAbove(Bottom.PitchClass, Interval);
        Pitch top = new(pitchClass: topPC,
            octave: Bottom.Octave + (Pitch.GetPitchID(topPC, Bottom.Octave) < Bottom.PitchID ? 1 : 0));

        Notes = [Bottom, top];
        Selected.Add(Bottom);
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[^1].PitchID - Bottom.PitchID == Interval.Chromatic.Value;
    }

}

public class IntervalPractice2 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IInterval Interval => Gamut is IInterval Interval ? Interval : throw new System.ArgumentNullException();

    public int NumOfNotes => 2;
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

    public string Desc => $"Build a {Interval.Name} {nameof(Interval)}";
    // public string AnswerFormatValidation => "Answer from the following: H, W, S";
    public string Answer => Interval.Name;
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint => "P1 mi2 M2 mi3 M3 P4 TT P5 mi6 M6 mi7 M7 P8";

    public IntervalPractice2()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        IInterval[] all = IInterval.GetAll().ToArray();
        Gamut = all[random.Next(0, all.Length)];

        IPitchClass topPC = IPitchClass.GetPitchClassAbove(Bottom.PitchClass, Interval);
        Pitch top = new(pitchClass: topPC,
            octave: Bottom.Octave + (Pitch.GetPitchID(topPC, Bottom.Octave) < Bottom.PitchID ? 1 : 0));

        Notes = [Bottom, top];
        Selected.Add(Bottom);
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[^1].PitchID - Bottom.PitchID == Interval.Chromatic.Value;
    }

}