using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory.Intervals;
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
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);


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



// public class InvertedChordPractice1 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public ITriad Triad => Gamut is ITriad Triad ? Triad : throw new System.ArgumentNullException();
//     int Inversion;
//     public int NumOfNotes => Triad.ChordTones.Length;
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

//     public string Desc => $"Build the {Triad.Name.StartCase()} in {Inversion.ToOrdinal()} inversion";
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     string GetHint()
//     {
//         string temp = "";
//         for (int i = 0; i < Triad.ChordTones.Length; i++)
//             temp += $"{Triad.ChordTones[(i + Inversion) % Triad.ChordTones.Length].ScaleDegree} ";
//         return temp;
//     }
//     public string Hint => GetHint();

//     public InvertedChordPractice1()
//     {
//         Random random = new();
//         Inversion = random.Next(1, 3);
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         Pitch root = new(
//         pitchClass: IPitchClass.Get(letter, accidental),
//         octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//         ITriad[] standard = ITriad.GetAll().ToArray();
//         Gamut = standard[random.Next(0, standard.Length)];
//         BottomNote = new(IPitchClass.GetPitchClassAbove(root.PitchClass, Triad.ChordTones[Inversion], allowEnharmonicWhite: true), 3);
//         SelectedNotes.Add(BottomNote);

//         Pitch[] notes = new Pitch[Triad.ChordTones.Length];
//         notes[0] = BottomNote;

//         for (int i = 1; i < notes.Length; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(root.PitchClass, Triad.ChordTones[(i + Inversion) % notes.Length], allowEnharmonicWhite: true);
//             notes[i] = new Pitch(pc, octave: BottomNote.Octave + (Pitch.GetPitchID(pc, BottomNote.Octave) < BottomNote.PitchID ? 1 : 0));
//         }
//         var sorted = notes.ToList();
//         sorted.Sort();
//         PuzzleNotes = [.. sorted];
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