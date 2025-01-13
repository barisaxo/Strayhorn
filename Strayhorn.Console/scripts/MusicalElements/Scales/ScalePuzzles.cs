using MusicTheory.Intervals;
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



// public class ScalePractice1 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public IScale Scale => Gamut is IScale Scale ? Scale : throw new System.ArgumentNullException();
//     public int NumOfNotes => 8;
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
//         return [.. notes];
//     }
//     public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
//     {
//         List<(Pitch[], int, float)> notes = [];
//         foreach (var n in PuzzleNotes) notes.Add(([n], 750, .5f));
//         return [.. notes];
//     }
//     public string Desc => $"Build the {Scale.Name} Scale";
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     public string Hint =>
//         @"1   2   3 4   5   6   7 1" + "\n" +
//         @" \ / \ / ‾ \ / \ / \ / ‾ " + "\n" +
//         @"  W   W  H  W   W   W  H " + "\n" + "\n";

//     public ScalePractice1()
//     {
//         Gamut = new MusicTheory.Scales.Major();

//         IPitchClass[] keys =
//             [new C(), new F(), new Bb(), new Eb(), new Ab(), new Db(),
//              new Fs(), new B(), new E(), new A(), new D(), new G()];

//         int octave = 3;
//         Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length + 1];
//         BottomNote = new(keys[new Random().Next(0, keys.Length)], octave);
//         SelectedNotes.Add(BottomNote);
//         notes[0] = BottomNote;
//         notes[^1] = new(notes[0].PitchClass, octave + 1);

//         for (int i = 1; i < notes.Length - 1; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i], allowEnharmonicWhite: true);
//             notes[i] = new Pitch(pc, octave: BottomNote.Octave + (Pitch.GetPitchID(pc, BottomNote.Octave) < BottomNote.PitchID ? 1 : 0));
//         }

//         PuzzleNotes = notes;
//     }

//     public void DrawQuestion()
//     {
//         PianoScroll.DrawTwoOctavePianoQuestionWithCarat(BottomNote, [.. SelectedNotes], Caret, ActiveNotes);
//     }

//     public bool CheckAnswer()
//     {
//         foreach (var p in PuzzleNotes)
//             try { _ = SelectedNotes.First(s => s.PitchID == p.PitchID); }
//             catch { return false; }
//         return true;
//     }

// }