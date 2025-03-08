using MusicTheory.Notes;
using MusicTheory.Scales;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

public class ScalePuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public IScale Scale => Gamut is IScale scale ? scale : throw new System.ArgumentNullException();

    public PuzzleType PuzzleType { get; }
    public int NumOfNotes { get; }
    public Pitch[] PuzzleNotes { get; }
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch Caret { get; set; } = new(new D(), 4);

    public string Desc => $"Build the{(PuzzleType is PuzzleType.Theory ? " " + Gamut.Name + " " : " ")}Scale";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (var sd in Scale.ScaleDegrees) temp += $"{sd.IntervalAbbrev} ";
        return temp;
    }
    public string Hint => GetHint();

    public bool CheckAnswer()
    {
        foreach (var p in PuzzleNotes)
            try { _ = SelectedNotes.First(s => s.PitchID == p.PitchID); }
            catch { return false; }
        return true;
    }

    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        SelectedNotes.Sort();
        foreach (var n in SelectedNotes) notes.Add(([n], 750, .5f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in PuzzleNotes) notes.Add(([n], 750, .5f));
        return [.. notes];
    }

    public ScalePuzzle(PuzzleType puzzleType, IScale scale)
    {
        PuzzleType = puzzleType;
        Gamut = scale;
        NumOfNotes = Scale.ScaleDegrees.Length + 1;
        BottomNote = new(IPitchClass.Get12KeySignatures().GetRandom(), octave: 3);
        SelectedNotes.Add(BottomNote);
        PuzzleNotes = IScale.Build(BottomNote, Scale, allowEnharmonicWhite: true);
    }

}