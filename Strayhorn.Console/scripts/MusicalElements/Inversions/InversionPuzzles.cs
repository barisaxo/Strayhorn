using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory.Intervals;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;


public class InversionPuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public IInterval Interval => Gamut is IInterval interval ? interval : throw new System.ArgumentNullException();

    public PuzzleType PuzzleType { get; }
    public int NumOfNotes => 2;
    public Pitch[] PuzzleNotes { get; }
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);

    public string Desc => $"Build an Inverted {IInterval.Invert(Interval).IntervalAbbrev}";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    public string Hint => "1st <──> 8th   :   2nd <──> 7th   :   3rd <──> 6th   :   4th <──> 5th\n" +
                          "Major <──> Minor   :   Augmented <──> Diminished    :   Perfect <──> Perfect";

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

    public InversionPuzzle(PuzzleType puzzleType, IInterval interval)
    {
        PuzzleType = puzzleType;
        Gamut = interval;
        BottomNote = new(IPitchClass.GetAllNoEnharmonic().GetRandom(), octave: 3);
        SelectedNotes.Add(BottomNote);
        PuzzleNotes = [BottomNote,
            Interval is P8 ? new(BottomNote.PitchClass, BottomNote.Octave + 1) :
            Pitch.GetPitchAbove(BottomNote, Interval)];
    }

}



// public class InversionPractice1 : IPuzzle
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

//     public string Desc => $"Build an Inverted {IInterval.Invert(Interval).IntervalAbbrev}";
//     public string Answer => Interval.Name;
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     public string Hint => "1st <──> 8th   :   2nd <──> 7th   :   3rd <──> 6th   :   4th <──> 5th\n" +
//                           "Major <──> Minor   :   Augmented <──> Diminished    :   Perfect <──> Perfect";

//     public InversionPractice1()
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);
//         SelectedNotes.Add(BottomNote);

//         IInterval[] collection = [
//                new mi2(), new M2(), new mi3(), new M3(), new P4(), new d5(), new P5(),
//             new mi6(), new M6(), new mi7(), new M7(), new P8(),
//         ];
//         Gamut = collection[random.Next(0, collection.Length)];

//         IPitchClass topPC = IPitchClass.GetPitchClassAbove(BottomNote.PitchClass, Interval);
//         Pitch top = new(pitchClass: topPC,
//             octave: BottomNote.Octave + (Pitch.GetPitchID(topPC, BottomNote.Octave) < BottomNote.PitchID ? 1 : 0));

//         if (Interval is P8) top = new(BottomNote.PitchClass, BottomNote.Octave + 1);

//         PuzzleNotes = [BottomNote, top];
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
