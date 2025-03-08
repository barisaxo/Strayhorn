using MusicTheory.Notes;
using MusicTheory.Intervals;
using MusicTheory.Chords;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

public class SeventhChordPuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public I7Chord SeventhChord => Gamut is I7Chord seventhChord ? seventhChord : throw new Exception($"{Gamut} is the wrong type.");

    public PuzzleType PuzzleType { get; }
    public int NumOfNotes => SeventhChord.ChordTones.Length;
    public Pitch[] PuzzleNotes { get; }
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);

    public string Desc => PuzzleType is PuzzleType.Theory ?
        $"Build the {SeventhChord.ChordSymbol} Chord" :
         "Build the 7th Chord";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    private string? _hint;
    public string Hint => _hint ??= GetHint();
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in SeventhChord.ChordTones) temp += $"{ct.ScaleDegree} ";
        return temp;
    }

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

    public SeventhChordPuzzle(PuzzleType puzzleType, I7Chord i7Chord)
    {
        PuzzleType = puzzleType;
        Gamut = i7Chord;
        BottomNote = new(IPitchClass.GetAllNoEnharmonic().GetRandom(), octave: 3);
        SelectedNotes.Add(BottomNote);
        PuzzleNotes = IChord.Build(SeventhChord, BottomNote, allowEnharmonicWhite: true);
    }
}