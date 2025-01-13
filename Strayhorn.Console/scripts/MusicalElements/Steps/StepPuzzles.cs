using MusicTheory.Intervals;
using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

// 
public class StepPuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public IStep Step => Gamut is IStep step ? step : throw new System.ArgumentNullException();
    public PuzzleType PuzzleType { get; }

    public int NumOfNotes => 2;
    public Pitch[] PuzzleNotes { get; }
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);

    public string Desc => $"Build the{(PuzzleType is PuzzleType.Theory ? " " + Gamut.Name + " " : " ")}{nameof(Step)}";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    public string Hint => "H = Half-Step = +1\nW = Whole-Step = +2\nS = Skip-Step = +3";

    public bool CheckAnswer()
    {
        return SelectedNotes[^1].PitchID - BottomNote.PitchID == Step.Chromatic.Value;
    }

    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        SelectedNotes.Sort();
        foreach (var n in SelectedNotes) notes.Add(([n], 750, .5f));
        notes.Add(([.. SelectedNotes], 1250, .5f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in PuzzleNotes) notes.Add(([n], 750, .5f));
        notes.Add((PuzzleNotes, 1250, .5f));
        return [.. notes];
    }

    public StepPuzzle(PuzzleType puzzleType, IStep step)
    {
        PuzzleType = puzzleType;
        Gamut = step;
        BottomNote = new(IPitchClass.GetAllNoEnharmonic().GetRandom(), octave: 3);
        PuzzleNotes = [BottomNote, Pitch.GetPitchAbove(BottomNote, Step)];
        SelectedNotes.Add(BottomNote);
    }


}
//   public StepPractice3(IPitchClass pitchClass, IStep step)
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//         var step = IStep.GetAll().ToList()[random.Next(0, 3)];

//         IPitchClass topPC = IPitchClass.GetPitchClassAbove(BottomNote.PitchClass, step);
//         Pitch top = new(pitchClass: topPC,
//             octave: BottomNote.Octave + (Pitch.GetPitchID(topPC, BottomNote.Octave) < BottomNote.PitchID ? 1 : 0));

//         PuzzleNotes = [BottomNote, top];
//         SelectedNotes.Add(BottomNote);
//         Gamut = step;
//     }


// public class StepPractice1 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public IStep Step => Gamut is IStep step ? step : throw new System.ArgumentNullException();
//     public int NumOfNotes => 2;
//     public Pitch[] PuzzleNotes { get; }
//     public List<Pitch> SelectedNotes { get; set; } = [];
//     public Pitch BottomNote { get; }
//     public Pitch[]? ActiveNotes { get; set; }
//     public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);

//     public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         SelectedNotes.Sort();
//         foreach (var n in SelectedNotes) notes.Add(([n], 750, .5f));
//         notes.Add(([.. SelectedNotes], 1250, .5f));
//         return [.. notes];
//     }

//     public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         foreach (var n in PuzzleNotes) notes.Add(([n], 750, .5f));
//         notes.Add((PuzzleNotes, 1250, .5f));
//         return [.. notes];
//     }

//     public string Desc => $"Build a {Step.Name} {nameof(Step)}";
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     public string Hint => "H = Half-Step = +1\nW = Whole-Step = +2";

//     public StepPractice1()
//     {
//         Random random = new();

//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         BottomNote = new(pitchClass: IPitchClass.Get(letter, new Natural()), octave: 3);

//         letter = ILetter.GetNextLetter(BottomNote.PitchClass.Letter);
//         IPitchClass topPC = IPitchClass.Get(letter, new Natural());
//         Pitch top = new(pitchClass: topPC,
//                    octave: BottomNote.Octave + (Pitch.GetPitchID(topPC, BottomNote.Octave) < BottomNote.PitchID ? 1 : 0));

//         IStep step = IStep.GetStep(BottomNote.PitchClass.Letter, top.PitchClass.Letter);
//         PuzzleNotes = [BottomNote, top];
//         SelectedNotes.Add(BottomNote);
//         Gamut = step;
//     }

//     public void DrawQuestion()
//     {
//         PianoScroll.DrawTwoOctavePianoQuestionWithCarat(BottomNote, [.. SelectedNotes], Caret, ActiveNotes);
//     }

//     public bool CheckAnswer()
//     {
//         return SelectedNotes[^1].PitchID - BottomNote.PitchID == Step.Chromatic.Value;
//     }

// }


// public class StepPractice2 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public IStep Step => Gamut is IStep step ? step : throw new System.ArgumentNullException();

//     public int NumOfNotes => 2;
//     public Pitch[] PuzzleNotes { get; }
//     public List<Pitch> SelectedNotes { get; } = [];
//     public Pitch BottomNote { get; }
//     public Pitch[]? ActiveNotes { get; set; }
//     public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);

//     public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         SelectedNotes.Sort();
//         foreach (var n in SelectedNotes) notes.Add(([n], 750, .5f));
//         notes.Add(([.. SelectedNotes], 1250, .5f));
//         return [.. notes];
//     }
//     public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         foreach (var n in PuzzleNotes) notes.Add(([n], 750, .5f));
//         notes.Add((PuzzleNotes, 1250, .5f));
//         return [.. notes];
//     }

//     public string Desc => $"Build a {Step.Name} {nameof(Step)}";
//     // public string AnswerFormatValidation => "Answer from the following: H, W";

//     public string Answer => Step.Name;
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     public string Hint => "H = Half-Step = +1\nW = Whole-Step = +2";

//     public StepPractice2()
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Sharp(), new Flat(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//         var step = IStep.GetAll().ToList()[random.Next(0, 2)];

//         IPitchClass topPC = IPitchClass.GetPitchClassAbove(BottomNote.PitchClass, step);
//         Pitch top = new(pitchClass: topPC,
//              octave: BottomNote.Octave + (Pitch.GetPitchID(topPC, BottomNote.Octave) < BottomNote.PitchID ? 1 : 0));

//         PuzzleNotes = [BottomNote, top];

//         SelectedNotes.Add(BottomNote);
//         Gamut = step;
//     }

//     public void DrawQuestion()
//     {
//         PianoScroll.DrawTwoOctavePianoQuestionWithCarat(BottomNote, [.. SelectedNotes], Caret, ActiveNotes);
//     }

//     public bool CheckAnswer()
//     {
//         return SelectedNotes[^1].PitchID - BottomNote.PitchID == Step.Chromatic.Value;
//     }

// }
