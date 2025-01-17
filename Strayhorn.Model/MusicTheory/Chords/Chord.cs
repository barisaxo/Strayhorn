
using MusicTheory.Intervals;
using MusicTheory.Notes;

namespace MusicTheory.Chords;

/// <summary> 
/// https://barisaxo.github.io/pages/chords/voicings.html       
/// </summary><remarks>https://barisaxo.github.io/pages/chords/tonalities.html</remarks>
public interface IChord : IMusicalElement
{
    public string ChordSymbol { get; }
    public IInterval[] ChordTones { get; }
    public IInterval[] AvailableTensions { get; }

    public static Pitch[] Build(IChord chord, Pitch root, bool allowEnharmonicWhite = false, bool preferDoubles = false)
    {
        Pitch[] notes = new Pitch[chord.ChordTones.Length];
        notes[0] = root;
        for (int i = 1; i < notes.Length; i++)
        {
            notes[i] = Pitch.GetPitchAbove(root, chord.ChordTones[i], allowEnharmonicWhite, preferDoubles);
        }
        return notes;
    }

    public static Pitch[] Invert(IChord chord, Pitch root, ChordInversion inversion, bool allowEnharmonicWhite = false, bool preferDoubles = false)
    {
        if (inversion is ChordInversion.Third && chord is ITriad) throw new System.Exception("Triads cannot be in 3rd inversion!");

        Pitch bottomNote = new(IPitchClass.GetPitchClassAbove(root.PitchClass, chord.ChordTones[(int)inversion], allowEnharmonicWhite: true), root.Octave);
        Pitch[] notes = new Pitch[chord.ChordTones.Length];
        notes[0] = bottomNote;

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(root.PitchClass, chord.ChordTones[(i + (int)inversion) % notes.Length], allowEnharmonicWhite: true);
            notes[i] = new Pitch(pc, octave: bottomNote.Octave + (Pitch.GetPitchID(pc, bottomNote.Octave) < bottomNote.PitchID ? 1 : 0));
        }

        var sorted = notes.ToList();
        sorted.Sort();
        return [.. sorted];
    }
}

/// <summary>
/// https://barisaxo.github.io/pages/arithmetic/invertedchords.html  
/// </summary>
public enum ChordInversion { Root = 0, First = 1, Second = 2, Third = 3 }
