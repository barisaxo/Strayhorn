using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory.Intervals;
using MusicTheory;

namespace Strayhorn.Practice;

public class InversionPractice1 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IInterval Interval => Gamut is IInterval Interval ? Interval : throw new System.ArgumentNullException();

    public int NumOfNotes => 2;
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

    public string Desc => $"Build an Inverted {IInterval.Invert(Interval).IntervalAbbrev}";
    public string Answer => Interval.Name;
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint => "1st <──> 8th   :   2nd <──> 7th   :   3rd <──> 6th   :   4th <──> 5th\n" +
                          "Major <──> Minor   :   Augmented <──> Diminished    :   Perfect <──> Perfect";

    public InversionPractice1()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);
        Selected.Add(Bottom);

        IInterval[] collection = [
               new mi2(), new M2(), new mi3(), new M3(), new P4(), new d5(), new P5(),
            new mi6(), new M6(), new mi7(), new M7(), new P8(),
        ];
        Gamut = collection[random.Next(0, collection.Length)];

        IPitchClass topPC = IPitchClass.GetPitchClassAbove(Bottom.PitchClass, Interval);
        Pitch top = new(pitchClass: topPC,
            octave: Bottom.Octave + (Pitch.GetPitchID(topPC, Bottom.Octave) < Bottom.PitchID ? 1 : 0));

        if (Interval is P8) top = new(Bottom.PitchClass, Bottom.Octave + 1);

        Notes = [Bottom, top];
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[^1].PitchID == Notes[^1].PitchID;
    }

}


public class InversionPractice2 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IInterval Interval => Gamut is IInterval Interval ? Interval : throw new System.ArgumentNullException();

    public int NumOfNotes => 2;
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

    public string Desc => $"Build an Inverted {IInterval.Invert(Interval).IntervalAbbrev}";
    public string Answer => Interval.Name;
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint => "1st <──> 8th   :   2nd <──> 7th   :   3rd <──> 6th   :   4th <──> 5th\n" +
                          "Major <──> Minor   :   Augmented <──> Diminished    :   Perfect <──> Perfect";


    public InversionPractice2()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);
        Selected.Add(Bottom);

        var collection = IInterval.GetAll().ToList();
        collection.Remove(new P8());
        Gamut = collection[random.Next(0, collection.Count)];

        IPitchClass topPC = IPitchClass.GetPitchClassAbove(Bottom.PitchClass, Interval);
        Pitch top = new(pitchClass: topPC,
            octave: Bottom.Octave + (Pitch.GetPitchID(topPC, Bottom.Octave) < Bottom.PitchID ? 1 : 0));

        if (Interval.Quantity is Octave) top = new(Bottom.PitchClass, Bottom.Octave + 1);

        Notes = [Bottom, top];
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[^1].PitchID == Notes[^1].PitchID;
    }

}