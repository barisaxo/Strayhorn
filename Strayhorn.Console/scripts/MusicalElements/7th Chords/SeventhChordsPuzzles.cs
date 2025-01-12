using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory.Intervals;
using MusicTheory.Chords;
using MusicTheory;

namespace Strayhorn.Practice;

// ? 
//TODO weird bug with B# chord and wanting a 5th note...
// ? 

public class SeventhChordPractice1 : IPractice
{
    public IMusicalElement Gamut { get; }
    public I7Chord SeventhChord => Gamut is I7Chord SeventhChord ? SeventhChord : throw new System.ArgumentNullException();

    public int NumOfNotes => SeventhChord.ChordTones.Length;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .5f));
        notes.Add(([.. Selected], 1250, .5f));
        return [.. notes];
    }

    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        notes.Add((Notes, 1250, .5f));
        return [.. notes];
    }

    public string Desc => $"Build the {SeventhChord.ChordSymbol} Chord";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in SeventhChord.ChordTones) temp += $"{ct.ScaleDegree} ";
        return temp;
    }
    public string Hint => GetHint();

    public SeventhChordPractice1()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        Selected.Add(Bottom);
        I7Chord[] standard = I7Chord.MajorTonality().ToArray();
        Gamut = standard[random.Next(0, standard.Length)];

        Pitch[] notes = new Pitch[SeventhChord.ChordTones.Length];
        notes[0] = Bottom;
        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, SeventhChord.ChordTones[i], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave: Bottom.Octave + (Pitch.GetPitchID(pc, Bottom.Octave) < Bottom.PitchID ? 1 : 0));
        }

        Notes = notes;
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        foreach (var p in Notes)
            try { _ = Selected.First(s => s.PitchID == p.PitchID); }
            catch { return false; }
        return true;
    }

}

public class SeventhChordPractice2 : IPractice
{
    public IMusicalElement Gamut { get; }
    public I7Chord SeventhChord => Gamut is I7Chord SeventhChord ? SeventhChord : throw new System.ArgumentNullException();

    public int NumOfNotes => SeventhChord.ChordTones.Length;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .5f));
        notes.Add(([.. Selected], 1250, .5f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        notes.Add((Notes, 1250, .5f));
        return [.. notes];
    }

    public string Desc => $"Build the {SeventhChord.ChordSymbol} Chord";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in SeventhChord.ChordTones) temp += $"{ct.ScaleDegree} ";
        return temp;
    }
    public string Hint => GetHint();

    public SeventhChordPractice2()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        Selected.Add(Bottom);
        I7Chord[] standard = I7Chord.MinorTonality().ToArray();
        Gamut = standard[random.Next(0, standard.Length)];

        Pitch[] notes = new Pitch[SeventhChord.ChordTones.Length];
        notes[0] = Bottom;
        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, SeventhChord.ChordTones[i], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave: Bottom.Octave + (Pitch.GetPitchID(pc, Bottom.Octave) < Bottom.PitchID ? 1 : 0));
        }

        Notes = notes;
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        foreach (var p in Notes)
            try { _ = Selected.First(s => s.PitchID == p.PitchID); }
            catch { return false; }
        return true;
    }

}

public class SeventhChordPractice3 : IPractice
{
    public IMusicalElement Gamut { get; }
    public I7Chord SeventhChord => Gamut is I7Chord SeventhChord ? SeventhChord : throw new System.ArgumentNullException();

    public int NumOfNotes => SeventhChord.ChordTones.Length;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .5f));
        notes.Add(([.. Selected], 1250, .5f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        notes.Add((Notes, 1250, .5f));
        return [.. notes];
    }

    public string Desc => $"Build the {SeventhChord.ChordSymbol} Chord";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in SeventhChord.ChordTones) temp += $"{ct.IntervalAbbrev} ";
        return temp;
    }
    public string Hint => GetHint();

    public SeventhChordPractice3()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);
        Selected.Add(Bottom);

        I7Chord[] standard = I7Chord.PassingChordDominant().ToArray();
        Gamut = standard[random.Next(0, standard.Length)];

        Pitch[] notes = new Pitch[SeventhChord.ChordTones.Length];
        notes[0] = Bottom;
        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, SeventhChord.ChordTones[i], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave: Bottom.Octave + (Pitch.GetPitchID(pc, Bottom.Octave) < Bottom.PitchID ? 1 : 0));
        }

        Notes = notes;
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        foreach (var p in Notes)
            try { _ = Selected.First(s => s.PitchID == p.PitchID); }
            catch { return false; }
        return true;
    }

}

public class SeventhChordPractice4 : IPractice
{
    public IMusicalElement Gamut { get; }
    public I7Chord SeventhChord => Gamut is I7Chord SeventhChord ? SeventhChord : throw new System.ArgumentNullException();

    public int NumOfNotes => SeventhChord.ChordTones.Length;
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .5f));
        notes.Add(([.. Selected], 1250, .5f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .5f));
        notes.Add((Notes, 1250, .5f));
        return [.. notes];
    }

    public string Desc => $"Build the {SeventhChord.ChordSymbol} Chord";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        foreach (IInterval ct in SeventhChord.ChordTones) temp += $"{ct.IntervalAbbrev} ";
        return temp;
    }
    public string Hint => GetHint();

    public SeventhChordPractice4()
    {
        Random random = new();
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Bottom = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);
        Selected.Add(Bottom);

        I7Chord[] standard = I7Chord.GetAll().ToArray();
        Gamut = standard[random.Next(0, standard.Length)];

        Pitch[] notes = new Pitch[SeventhChord.ChordTones.Length];
        notes[0] = Bottom;
        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, SeventhChord.ChordTones[i], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave: Bottom.Octave + (Pitch.GetPitchID(pc, Bottom.Octave) < Bottom.PitchID ? 1 : 0));
        }

        Notes = notes;
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        foreach (var p in Notes)
            try { _ = Selected.First(s => s.PitchID == p.PitchID); }
            catch { return false; }
        return true;
    }

}
