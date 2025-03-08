using MusicTheory.Notes;
using MusicTheory.Intervals;
using MusicTheory.Chords;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

public class TriadPuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public ITriad Triad => Gamut is ITriad triad ? triad : throw new System.Exception();

    public PuzzleType PuzzleType { get; }
    public int NumOfNotes => Triad.ChordTones.Length;
    public Pitch[] PuzzleNotes { get; }
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);

    public string Desc => $"Build the{(PuzzleType is PuzzleType.Theory ? " " + Gamut.Name + " " : " ")}{nameof(Triad)}";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in Triad.ChordTones) temp += $"{ct.IntervalAbbrev} ";
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

    public TriadPuzzle(PuzzleType puzzleType, ITriad triad)
    {
        PuzzleType = puzzleType;
        Gamut = triad;
        BottomNote = new(IPitchClass.GetAllNoEnharmonic().GetRandom(), octave: 3);
        SelectedNotes.Add(BottomNote);
        PuzzleNotes = IChord.Build(triad, BottomNote, allowEnharmonicWhite: true);
    }

}