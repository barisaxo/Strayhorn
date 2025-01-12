using MusicTheory.Intervals;
using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory;

namespace Strayhorn.Practice;

public class StepPractice1 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IStep Step => Gamut is IStep step ? step : throw new System.ArgumentNullException();
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

    public string Desc => $"Build a {Step.Name} {nameof(Step)}";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint => "H = Half-Step = +1\nW = Whole-Step = +2";

    public StepPractice1()
    {
        Random random = new();

        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        Bottom = new(pitchClass: IPitchClass.Get(letter, new Natural()), octave: 3);

        letter = ILetter.GetNextLetter(Bottom.PitchClass.Letter);
        IPitchClass topPC = IPitchClass.Get(letter, new Natural());
        Pitch top = new(pitchClass: topPC,
                   octave: Bottom.Octave + (Pitch.GetPitchID(topPC, Bottom.Octave) < Bottom.PitchID ? 1 : 0));

        IStep step = IStep.GetStep(Bottom.PitchClass.Letter, top.PitchClass.Letter);
        Notes = [Bottom, top];
        Selected.Add(Bottom);
        Gamut = step;
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[^1].PitchID - Bottom.PitchID == Step.Chromatic.Value;
    }

}


public class StepPractice2 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IStep Step => Gamut is IStep step ? step : throw new System.ArgumentNullException();

    public int NumOfNotes => 2;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; } = [];
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

    public string Desc => $"Build a {Step.Name} {nameof(Step)}";
    // public string AnswerFormatValidation => "Answer from the following: H, W";

    public string Answer => Step.Name;
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint => "H = Half-Step = +1\nW = Whole-Step = +2";

    public StepPractice2()
    {
        Random random = new();
        IAccidental[] accidentals = [new Sharp(), new Flat(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        var step = IStep.GetAll().ToList()[random.Next(0, 2)];

        IPitchClass topPC = IPitchClass.GetPitchClassAbove(Bottom.PitchClass, step);
        Pitch top = new(pitchClass: topPC,
             octave: Bottom.Octave + (Pitch.GetPitchID(topPC, Bottom.Octave) < Bottom.PitchID ? 1 : 0));

        Notes = [Bottom, top];

        Selected.Add(Bottom);
        Gamut = step;
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[^1].PitchID - Bottom.PitchID == Step.Chromatic.Value;
    }

}

public class StepPractice3 : IPractice
{
    public IMusicalElement Gamut { get; }
    public IStep Step => Gamut is IStep step ? step : throw new System.ArgumentNullException();

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

    public string Desc => $"Build a {Step.Name} {nameof(Step)}";
    // public string AnswerFormatValidation => "Answer from the following: H, W, S";
    public string Answer => Step.Name;
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    public string Hint => "H = Half-Step = +1\nW = Whole-Step = +2\nS = Skip-Step = +3";

    public StepPractice3()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        var step = IStep.GetAll().ToList()[random.Next(0, 3)];

        IPitchClass topPC = IPitchClass.GetPitchClassAbove(Bottom.PitchClass, step);
        Pitch top = new(pitchClass: topPC,
            octave: Bottom.Octave + (Pitch.GetPitchID(topPC, Bottom.Octave) < Bottom.PitchID ? 1 : 0));

        Notes = [Bottom, top];
        Selected.Add(Bottom);
        Gamut = step;
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        return Selected[^1].PitchID - Bottom.PitchID == Step.Chromatic.Value;
    }

}
