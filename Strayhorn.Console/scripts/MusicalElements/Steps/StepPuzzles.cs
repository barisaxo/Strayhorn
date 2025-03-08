using MusicTheory.Intervals;
using MusicTheory.Notes;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

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