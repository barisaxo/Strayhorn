using MusicTheory.Intervals;
using MusicTheory.Notes;
using MusicTheory.Scales;
using MusicTheory.Modes;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;


public class ModePuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public IMode Mode => Gamut is IMode mode ? mode : throw new Exception();

    public PuzzleType PuzzleType { get; }
    public int NumOfNotes { get; }
    public Pitch[] PuzzleNotes { get; }
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);

    public string Desc => $"Build the{(PuzzleType is PuzzleType.Theory ? " " + Gamut.Name + " " : " ")}Mode.";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    string GetHint()
    {
        string temp = string.Empty;
        int mode = Mode.ModeNumber();

        for (int i = 0; i < Mode.Parent.Steps.Length; i++)
            temp += Mode.Parent.Steps[(mode + i) % Mode.Parent.Steps.Length].Abbrev + ' ';

        temp += "\n";

        for (int i = 0; i < Mode.Parent.ScaleDegrees.Length; i++)
            temp += IInterval.GetInterval(
                Mode.Parent.ScaleDegrees[mode],
                Mode.Parent.ScaleDegrees[(mode + i) % Mode.Parent.ScaleDegrees.Length]).ScaleDegree + ' ';

        temp += "1";
        return temp;
    }
    private string? _hint = null;
    public string Hint => _hint ??= GetHint();

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

    public ModePuzzle(PuzzleType puzzleType, IMode mode)
    {
        PuzzleType = puzzleType;
        Gamut = mode;
        NumOfNotes = Mode.Parent.ScaleDegrees.Length + 1;
        BottomNote = new(IPitchClass.Get12KeySignatures().GetRandom(), octave: 3);
        SelectedNotes.Add(BottomNote);
        PuzzleNotes = IMode.Build(BottomNote, mode, allowEnharmonicWhite: true);
    }

}



// public class ModePractice1 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public IMode Mode => Gamut is IMode mode ? mode : throw new System.ArgumentNullException();
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
//     public string Desc => $"Build the {Mode.Name} Scale";
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     string GetHint()
//     {
//         string temp = string.Empty;
//         int mode = Mode.ModeNumber();

//         for (int i = 0; i < Mode.Parent.Steps.Length; i++)
//             temp += Mode.Parent.Steps[(mode + i) % Mode.Parent.Steps.Length].Abbrev + ' ';

//         temp += "\n";

//         for (int i = 0; i < Mode.Parent.ScaleDegrees.Length; i++) temp +=
//         IInterval.GetInterval(
//             Mode.Parent.ScaleDegrees[mode],
//             Mode.Parent.ScaleDegrees[(mode + i) % Mode.Parent.ScaleDegrees.Length]).ScaleDegree + ' ';

//         temp += "1";
//         return temp;
//     }
//     private string? _hint = null;
//     public string Hint => _hint ??= GetHint();

//     public ModePractice1()
//     {
//         Random rand = new();
//         MusicTheory.Scales.Major scale = new();
//         int length = scale.Modes.Length;
//         int mode = rand.Next(0, length);
//         Gamut = scale.Modes[mode];

//         IPitchClass[] keys =
//             [new C(), new F(), new Bb(), new Eb(), new Ab(), new Db(),
//              new Fs(), new B(), new E(), new A(), new D(), new G()];

//         Pitch[] notes = new Pitch[scale.ScaleDegrees.Length + 1];
//         BottomNote = new(keys[rand.Next(0, keys.Length)], octave: 3);
//         IPitchClass parent = IPitchClass.GetPitchClassAbove(BottomNote.PitchClass, IInterval.Invert(scale.ScaleDegrees[mode]));
//         SelectedNotes.Add(BottomNote);
//         notes[0] = BottomNote;
//         notes[^1] = new Pitch(BottomNote.PitchClass, BottomNote.Octave + 1);

//         for (int i = 1; i < notes.Length - 1; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(parent, scale.ScaleDegrees[(i + mode) % length]);
//             notes[i] = new Pitch(pc, octave: BottomNote.Octave + (BottomNote.PitchID > Pitch.GetPitchID(pc, BottomNote.Octave) ? 1 : 0));
//         }
//         PuzzleNotes = notes;
//     }

//     public bool CheckAnswer()
//     {
//         foreach (var p in PuzzleNotes)
//             try { _ = SelectedNotes.First(s => s.PitchID == p.PitchID); }
//             catch { return false; }
//         return true;
//     }

// }
