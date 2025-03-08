using MusicTheory.Notes;
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
