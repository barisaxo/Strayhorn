using MusicTheory.Notes;
using MusicTheory.Chords;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

public class ChordInversionPuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public IChord Chord => Gamut is IChord chord ? chord : throw new System.ArgumentNullException();

    public PuzzleType PuzzleType { get; }
    readonly ChordInversion Inversion;
    public int NumOfNotes => Chord.ChordTones.Length;
    public Pitch[] PuzzleNotes { get; }
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch Caret { get; set; } = new(new D(), 4);


    public string Desc => PuzzleType is PuzzleType.Theory ?
        $"Build the {(Chord is ITriad ? Chord.Name : Chord.ChordSymbol)} Chord in {((int)Inversion).ToOrdinal()} inversion" :
        "Build the inverted chord";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    string GetHint()
    {
        string temp = "";
        for (int i = 0; i < Chord.ChordTones.Length; i++)
            temp += $"{Chord.ChordTones[(i + (int)Inversion) % Chord.ChordTones.Length].ScaleDegree} ";
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

    public ChordInversionPuzzle(PuzzleType puzzleType, IChord chord)
    {
        PuzzleType = puzzleType;
        Gamut = chord;
        Inversion = (ChordInversion)new Random().Next(1, chord is ITriad ? 3 : 4);
        Pitch root = new(IPitchClass.GetAllNoEnharmonic().GetRandom(), octave: 3);
        PuzzleNotes = IChord.Invert(chord, root, Inversion);
        BottomNote = PuzzleNotes[0];
        SelectedNotes.Add(BottomNote);
    }



}