using MusicTheory.Notes;
using MusicTheory.Letters;
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

// public class SeventhChordPractice2 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public I7Chord SeventhChord => Gamut is I7Chord SeventhChord ? SeventhChord : throw new System.ArgumentNullException();

//     public int NumOfNotes => SeventhChord.ChordTones.Length;
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

//     public string Desc => $"Build the {SeventhChord.ChordSymbol} Chord";
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     private string? _hint;
//     public string Hint => _hint ??= GetHint();
//     string GetHint()
//     {
//         string temp = "";
//         foreach (IInterval ct in SeventhChord.ChordTones) temp += $"{ct.ScaleDegree} ";
//         return temp;
//     }

//     public bool CheckAnswer()
//     {
//         foreach (var p in PuzzleNotes)
//             try { _ = SelectedNotes.First(s => s.PitchID == p.PitchID); }
//             catch { return false; }
//         return true;
//     }

//     public SeventhChordPractice2()
//     {
//         IAccidental accidental = IAccidental.GetAllExceptDoubles().GetRandom();
//         ILetter letter = ILetter.GetAll().GetRandom();
//         Gamut = I7Chord.MinorTonality().GetRandom();
//         Pitch[] notes = new Pitch[NumOfNotes];

//         BottomNote = new(pitchClass: IPitchClass.Get(letter, accidental),
//                          octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//         notes[0] = BottomNote;
//         SelectedNotes.Add(BottomNote);

//         for (int i = 1; i < notes.Length; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, SeventhChord.ChordTones[i], allowEnharmonicWhite: true);
//             notes[i] = new Pitch(pc, octave: BottomNote.Octave + (Pitch.GetPitchID(pc, BottomNote.Octave) < BottomNote.PitchID ? 1 : 0));
//         }

//         PuzzleNotes = notes;
//     }
// }

// public class SeventhChordPractice3 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public I7Chord SeventhChord => Gamut is I7Chord SeventhChord ? SeventhChord : throw new System.ArgumentNullException();

//     public int NumOfNotes => SeventhChord.ChordTones.Length;
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

//     public string Desc => $"Build the {SeventhChord.ChordSymbol} Chord";
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     string GetHint()
//     {
//         string temp = "";
//         foreach (IInterval ct in SeventhChord.ChordTones) temp += $"{ct.IntervalAbbrev} ";
//         return temp;
//     }
//     public string Hint => GetHint();

//     public SeventhChordPractice3()
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);
//         SelectedNotes.Add(BottomNote);

//         I7Chord[] standard = I7Chord.PassingChordDominant().ToArray();
//         Gamut = standard[random.Next(0, standard.Length)];

//         Pitch[] notes = new Pitch[SeventhChord.ChordTones.Length];
//         notes[0] = BottomNote;
//         for (int i = 1; i < notes.Length; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, SeventhChord.ChordTones[i], allowEnharmonicWhite: true);
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

// public class SeventhChordPractice4 : IPuzzle
// {
//     public IMusicalElement Gamut { get; }
//     public I7Chord SeventhChord => Gamut is I7Chord SeventhChord ? SeventhChord : throw new System.ArgumentNullException();

//     public int NumOfNotes => SeventhChord.ChordTones.Length;
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

//     public string Desc => $"Build the {SeventhChord.ChordSymbol} Chord";
//     public bool PuzzleIsComplete { get; set; }
//     public bool ShouldHintDisplay { get; set; }
//     string GetHint()
//     {
//         string temp = "";
//         foreach (IInterval ct in SeventhChord.ChordTones) temp += $"{ct.IntervalAbbrev} ";
//         return temp;
//     }
//     public string Hint => GetHint();

//     public SeventhChordPractice4()
//     {
//         Random random = new();
//         IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
//         var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//         IAccidental accidental = accidentals[random.Next(0, 3)];
//         BottomNote = new(
//             pitchClass: IPitchClass.Get(letter, accidental),
//             octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);
//         SelectedNotes.Add(BottomNote);

//         I7Chord[] standard = I7Chord.GetAll().ToArray();
//         Gamut = standard[random.Next(0, standard.Length)];

//         Pitch[] notes = new Pitch[SeventhChord.ChordTones.Length];
//         notes[0] = BottomNote;
//         for (int i = 1; i < notes.Length; i++)
//         {
//             IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, SeventhChord.ChordTones[i], allowEnharmonicWhite: true);
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
