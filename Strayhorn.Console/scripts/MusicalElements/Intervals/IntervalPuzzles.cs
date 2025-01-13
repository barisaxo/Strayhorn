using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory.Intervals;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

public class IntervalPuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public IInterval Interval => Gamut is IInterval interval ? interval : throw new Exception();

    public PuzzleType PuzzleType { get; }
    public int NumOfNotes => 2;
    public Pitch[] PuzzleNotes { get; }
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);

    public string Desc => PuzzleType is PuzzleType.Theory ?
        $"Build the {Interval.Name} Interval" :
        "Build the Interval";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    public string Hint => "P1 mi2 M2 mi3 M3 P4 TT P5 mi6 M6 mi7 M7 P8";

    public bool CheckAnswer()
    {
        return SelectedNotes[^1].PitchID == PuzzleNotes[^1].PitchID;
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

    public IntervalPuzzle(PuzzleType puzzleType, IInterval interval)
    {
        PuzzleType = puzzleType;
        Gamut = interval;
        BottomNote = new(IPitchClass.GetAllNoEnharmonic().GetRandom(), octave: 3);
        PuzzleNotes = [BottomNote, Pitch.GetPitchAbove(BottomNote, Interval)];
        SelectedNotes.Add(BottomNote);
    }

}

// public class IntervalPractice1 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public IInterval Interval => Gamut is IInterval Interval ? Interval : throw new System.ArgumentNullException();

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

//     public string Desc => $"Build a {Interval.Name} {nameof(Interval)}";
//     public string Answer => Interval.Name;
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     public string Hint => "P1 mi2 M2 mi3 M3 P4 TT P5 mi6 M6 mi7 M7 P8";

//     public IntervalPractice1()
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//         IInterval[] collection = [
//             new mi2(), new M2(), new mi3(), new M3(), new P4(), new d5(), new P5(),
//             new mi6(), new M6(), new mi7(), new M7(), new P8()
//         ];
//         Gamut = collection[random.Next(0, collection.Length)];

//         IPitchClass topPC = IPitchClass.GetPitchClassAbove(BottomNote.PitchClass, Interval);
//         Pitch top = new(pitchClass: topPC,
//             octave: BottomNote.Octave + (Pitch.GetPitchID(topPC, BottomNote.Octave) < BottomNote.PitchID ? 1 : 0));
//         if (Interval is P8) top = new(BottomNote.PitchClass, BottomNote.Octave + 1);

//         PuzzleNotes = [BottomNote, top];
//         SelectedNotes.Add(BottomNote);
//     }

//     public void DrawQuestion()
//     {
//         PianoScroll.DrawTwoOctavePianoQuestionWithCarat(BottomNote, [.. SelectedNotes], Caret, ActiveNotes);
//     }

//     public bool CheckAnswer()
//     {
//         return SelectedNotes[^1].PitchID == PuzzleNotes[^1].PitchID;
//     }

// }
