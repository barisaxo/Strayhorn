using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory.Intervals;
using MusicTheory.Chords;
using MusicTheory;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

public class InvertedChordPractice1 : IPractice
{
    public IMusicalElement Gamut { get; }
    public ITriad Triad => Gamut is ITriad Triad ? Triad : throw new System.ArgumentNullException();
    int Inversion;
    public int NumOfNotes => Triad.ChordTones.Length;
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

    public string Desc => $"Build the {Triad.Name.StartCase()} in {Inversion.ToOrdinal()} inversion";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        for (int i = 0; i < Triad.ChordTones.Length; i++)
            temp += $"{Triad.ChordTones[(i + Inversion) % Triad.ChordTones.Length].ScaleDegree} ";
        return temp;
    }
    public string Hint => GetHint();

    public InvertedChordPractice1()
    {
        Random random = new();
        Inversion = random.Next(1, 3);
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Pitch root = new(
        pitchClass: IPitchClass.Get(letter, accidental),
        octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        ITriad[] standard = ITriad.GetAll().ToArray();
        Gamut = standard[random.Next(0, standard.Length)];
        Bottom = new(IPitchClass.GetPitchClassAbove(root.PitchClass, Triad.ChordTones[Inversion], allowEnharmonicWhite: true), 3);
        Selected.Add(Bottom);

        Pitch[] notes = new Pitch[Triad.ChordTones.Length];
        notes[0] = Bottom;

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(root.PitchClass, Triad.ChordTones[(i + Inversion) % notes.Length], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave: Bottom.Octave + (Pitch.GetPitchID(pc, Bottom.Octave) < Bottom.PitchID ? 1 : 0));
        }
        var sorted = notes.ToList();
        sorted.Sort();
        Notes = [.. sorted];
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

public class InvertedChordPractice2 : IPractice
{
    public IMusicalElement Gamut { get; }
    public I7Chord SeventhChord => Gamut is I7Chord SeventhChord ? SeventhChord : throw new System.ArgumentNullException();
    int Inversion;
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

    public string Desc => $"Build the {SeventhChord.ChordSymbol} Chord in {Inversion.ToOrdinal()} inversion";
    public bool PracticeComplete { get; set; }
    public bool HintFlag { get; set; }
    string GetHint()
    {
        string temp = "";
        for (int i = 0; i < SeventhChord.ChordTones.Length; i++)
            temp += $"{SeventhChord.ChordTones[(i + Inversion) % SeventhChord.ChordTones.Length].ScaleDegree} ";
        return temp;
    }
    public string Hint => GetHint();

    public InvertedChordPractice2()
    {
        Random random = new();
        Inversion = random.Next(1, 4);
        IAccidental[] accidentals = [new Flat(), new Sharp(), new Natural()];
        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = accidentals[random.Next(0, 3)];
        Pitch root = new(
            pitchClass: IPitchClass.Get(letter, accidental),
            octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

        I7Chord[] standard = I7Chord.GetAll().ToArray();
        Gamut = standard[random.Next(0, standard.Length)];
        Bottom = new(IPitchClass.GetPitchClassAbove(root.PitchClass, SeventhChord.ChordTones[Inversion], allowEnharmonicWhite: true), 3);
        Selected.Add(Bottom);

        Pitch[] notes = new Pitch[SeventhChord.ChordTones.Length];
        notes[0] = Bottom;

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(root.PitchClass, SeventhChord.ChordTones[(i + Inversion) % notes.Length], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave: Bottom.Octave + (Pitch.GetPitchID(pc, Bottom.Octave) < Bottom.PitchID ? 1 : 0));
        }
        var sorted = notes.ToList();
        sorted.Sort();
        Notes = [.. sorted];
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
