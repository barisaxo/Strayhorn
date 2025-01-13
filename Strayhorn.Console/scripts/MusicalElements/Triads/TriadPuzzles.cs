using MusicTheory.Notes;
using MusicTheory.Letters;
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


// public class TriadPractice1 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public ITriad Triad => Gamut is ITriad Triad ? Triad : throw new System.ArgumentNullException();

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

//     public string Desc => $"Build a {Triad.Name} {nameof(Triad)}";
//     public string Answer => Triad.Name;
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     string GetHint()
//     {
//         string temp = "";
//         foreach (IInterval ct in Triad.ChordTones) temp += $"{ct.IntervalAbbrev} ";
//         return temp;
//     }
//     public string Hint => GetHint();

//     public TriadPractice1()
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//         SelectedNotes.Add(BottomNote);
//         ITriad[] standard = [new MajorTriad(), new MinorTriad()];
//         Gamut = standard[random.Next(0, standard.Length)];

//         Pitch[] notes = new Pitch[Triad.ChordTones.Length];
//         notes[0] = BottomNote;
//         for (int i = 1; i < notes.Length; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Triad.ChordTones[i], allowEnharmonicWhite: true);
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

// public class TriadPractice2 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public ITriad Triad => Gamut is ITriad Triad ? Triad : throw new System.ArgumentNullException();

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

//     public string Desc => $"Build a {Triad.Name} {nameof(Triad)}";
//     public string Answer => Triad.Name;
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     string GetHint()
//     {
//         string temp = "";
//         foreach (IInterval ct in Triad.ChordTones) temp += $"{ct.IntervalAbbrev} ";
//         return temp;
//     }
//     public string Hint => GetHint();

//     public TriadPractice2()
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//         SelectedNotes.Add(BottomNote);
//         ITriad[] standard = [new AugmentedTriad(), new DiminishedTriad()];
//         Gamut = standard[random.Next(0, standard.Length)];

//         Pitch[] notes = new Pitch[Triad.ChordTones.Length];
//         notes[0] = BottomNote;
//         for (int i = 1; i < notes.Length; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Triad.ChordTones[i], allowEnharmonicWhite: true);
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

// public class TriadPractice3 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public ITriad Triad => Gamut is ITriad Triad ? Triad : throw new System.ArgumentNullException();

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

//     public string Desc => $"Build a {Triad.Name} {nameof(Triad)}";
//     public string Answer => Triad.Name;
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     string GetHint()
//     {
//         string temp = "";
//         foreach (IInterval ct in Triad.ChordTones) temp += $"{ct.IntervalAbbrev} ";
//         return temp;
//     }
//     public string Hint => GetHint();

//     public TriadPractice3()
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//         ITriad[] standard = ITriad.GetTheoretical().ToArray();
//         Gamut = standard[random.Next(0, standard.Length)];

//         int octave = 3;
//         Pitch[] notes = new Pitch[Triad.ChordTones.Length];
//         notes[0] = BottomNote;
//         for (int i = 1; i < notes.Length; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Triad.ChordTones[i], allowEnharmonicWhite: true);
//             notes[i] = new Pitch(pc, octave + (pc.Chromatic.Value < notes[0].Chromatic.Value ? 1 : 0));
//         }

//         PuzzleNotes = notes;
//         BottomNote = PuzzleNotes[0];
//         SelectedNotes.Add(BottomNote);
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