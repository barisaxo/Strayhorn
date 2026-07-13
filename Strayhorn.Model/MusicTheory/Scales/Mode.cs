
using MusicTheory.Scales;
using MusicTheory.Intervals;
namespace MusicTheory.Modes;

public enum ModeDegree { Prime, Second, Third, Fourth, Fifth, Sixth, Seventh }

public interface IMode : IMusicalElement
{
    public IScale Parent { get; }
    public IInterval ModeDegree { get; }
    public int ModeNumber()
    {
        for (int i = 0; i < Parent.Modes.Length; i++)
            if (Parent.Modes[i].Equals(this))
                return i;
        throw new Exception(Parent.Name + " does not contain " + Name + " ??");
    }

    public static Notes.Pitch[] Build(Notes.Pitch key, IMode mode, bool allowEnharmonicWhite = false, bool preferDoubles = false)
    {
        var scale = mode.Parent;
        int scaleLength = scale.ScaleDegrees.Length;
        int modeNo = mode.ModeNumber();

        Notes.Pitch[] notes = new Notes.Pitch[scale.ScaleDegrees.Length + 1];
        IInterval[] intervals = new IInterval[scaleLength];

        for (int i = 0; i < scaleLength; i++)
            intervals[i] = IInterval.GetInterval(mode.Parent.ScaleDegrees[modeNo],
                mode.Parent.ScaleDegrees[(modeNo + i) % mode.Parent.ScaleDegrees.Length]);

        notes[0] = key;
        notes[^1] = new Notes.Pitch(key.PitchClass, key.Octave + 1);

        for (int i = 1; i < notes.Length - 1; i++)
            notes[i] = Notes.Pitch.GetPitchAbove(key, intervals[i]);

        return notes;
    }
}

#region  Major Modes

public readonly struct Ionian : IMode
{
    public readonly string Name => "Ionian Scale (Prime Mode of the Major Scale)";
    public readonly IScale Parent => new Scales.Major();
    public readonly IInterval ModeDegree => new P1();
}

public readonly struct Dorian : IMode
{
    public readonly string Name => "Dorian Scale (2nd Mode of the Major Scale)";
    public readonly IScale Parent => new Scales.Major();
    public readonly IInterval ModeDegree => new M2();
}

public readonly struct Phrygian : IMode
{
    public readonly string Name => "Phrygian Scale (3rd Mode of the Major Scale)";
    public readonly IScale Parent => new Scales.Major();
    public readonly IInterval ModeDegree => new M3();
}

public readonly struct Lydian : IMode
{
    public readonly string Name => "Lydian Scale (4th Mode of the Major Scale)";
    public readonly IScale Parent => new Scales.Major();
    public readonly IInterval ModeDegree => new P4();
}

public readonly struct Mixolydian : IMode
{
    public readonly string Name => "Mixolydian Scale (5th Mode of the Major Scale)";
    public readonly IScale Parent => new Scales.Major();
    public readonly IInterval ModeDegree => new P5();
}

public readonly struct Aeolian : IMode
{
    public readonly string Name => "Aeolian Scale (6th Mode of the Major Scale)";
    public readonly IScale Parent => new Scales.Major();
    public readonly IInterval ModeDegree => new M6();
}

public readonly struct Locrian : IMode
{
    public readonly string Name => "Locrian Scale (7th Mode of the Major Scale)";
    public readonly IScale Parent => new Scales.Major();
    public readonly IInterval ModeDegree => new M7();
}

#endregion  Major Modes


#region  Pentatonic Modes

public readonly struct Pentatonic : IMode
{
    public readonly string Name => "Pentatonic Scale";
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly IInterval ModeDegree => new P1();
}

public readonly struct PentatonicII : IMode
{
    public readonly string Name => "Second Mode of the Pentatonic Scale";
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly IInterval ModeDegree => new M2();
}

public readonly struct PentatonicIII : IMode
{
    public readonly string Name => "Third Mode of the Pentatonic Scale";
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly IInterval ModeDegree => new M3();
}

public readonly struct PentatonicIV : IMode
{
    public readonly string Name => "Fourth Mode of the Pentatonic Scale";
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly IInterval ModeDegree => new P5();
}

public readonly struct PentatonicMinor : IMode
{
    public readonly string Name => "Pentatonic Minor Scale (5th Mode of the Pentatonic Scale)";
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly IInterval ModeDegree => new M6();
}

#endregion  Pentatonic Modes


#region Blues Modes

public readonly struct Blues : IMode
{
    public readonly string Name => "Blues Scale";
    public readonly IScale Parent => new Scales.Blues();
    public readonly IInterval ModeDegree => new P1();
}

public readonly struct BluesMajor : IMode
{
    public readonly string Name => "Blues Major Scale (2nd Mode of the Blues Scale)";
    public readonly IScale Parent => new Scales.Blues();
    public readonly IInterval ModeDegree => new mi3();
}

#endregion  Blues Modes


#region WholeTone Modes

public readonly struct WholeTone : IMode
{
    public readonly string Name => "Whole Tone Scale";
    public readonly IScale Parent => new Scales.WholeTone();
    public readonly IInterval ModeDegree => new P1();
}

#endregion WholeTone Modes


#region Jazz Modes

public readonly struct JazzMinor : IMode
{
    public readonly string Name => "Jazz Minor Scale";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly IInterval ModeDegree => new P1();
}

public readonly struct PhrygianS6 : IMode
{
    public readonly string Name => "Phrygian ♮6 Scale (2nd Mode of Jazz Minor)";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly IInterval ModeDegree => new M2();
}

public readonly struct LydianS5 : IMode
{
    public readonly string Name => "Lydian ♯5 Scale (3rd Mode of Jazz Minor)";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly IInterval ModeDegree => new mi3();
}

public readonly struct LydianDom : IMode
{
    public readonly string Name => "Lydian Dominant Scale (4th Mode of Jazz Minor)";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly IInterval ModeDegree => new P4();
}

public readonly struct Mixolydianb6 : IMode
{
    public readonly string Name => "Mixolydian ♭6 Scale (5th Mode of Jazz Minor)";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly IInterval ModeDegree => new P5();
}

public readonly struct LocrianS9 : IMode
{
    public readonly string Name => "Locrian ♮9 Scale (6th Mode of Jazz Minor)";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly IInterval ModeDegree => new M6();
}

public readonly struct Altered : IMode
{
    public readonly string Name => "Altered Scale (7th Mode of Jazz Minor)";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly IInterval ModeDegree => new M7();
}

#endregion Jazz Modes


#region Harmonic Minor Modes

public readonly struct HarmonicMinor : IMode
{
    public readonly string Name => "Harmonic Minor";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly IInterval ModeDegree => new P1();
}

public readonly struct LocrianS6 : IMode
{
    public readonly string Name => "Locrian ♮6 Scale (2nd Mode of Harmonic Minor)";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly IInterval ModeDegree => new M2();
}

public readonly struct IonianS5 : IMode
{
    public readonly string Name => "Ionian #5 Scale (3rd Mode of Harmonic Minor)";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly IInterval ModeDegree => new mi3();
}

public readonly struct DorianS11 : IMode
{
    public readonly string Name => "Dorian #11 Scale (4th Mode of Harmonic Minor)";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly IInterval ModeDegree => new P4();
}

public readonly struct PhrygianDominant : IMode
{
    public readonly string Name => "Phrygian Dominant Scale (5th Mode of Harmonic Minor)";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly IInterval ModeDegree => new P5();
}

public readonly struct LydianS2 : IMode
{
    public readonly string Name => "Lydian #2 (6th Mode of Harmonic Minor)";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly IInterval ModeDegree => new mi6();
}

public readonly struct SuperLocrian : IMode
{
    public readonly string Name => "Super Locrian Scale (7th Mode of the Harmonic Minor)";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly IInterval ModeDegree => new M7();
}

#endregion Harmonic Minor Modes


#region Diminished6th Modes

public readonly struct SixthDiminished : IMode
{
    public readonly string Name => "Sixth Diminished Scale(Barry Harris Scale)";
    public readonly IScale Parent => new Scales.SixthDiminished();
    public readonly IInterval ModeDegree => new P1();
}

public readonly struct SixthDiminishedII : IMode
{
    public readonly string Name => "Sixth Diminished II Scale (2nd Mode of the Sixth Diminished Scale)";
    public readonly IScale Parent => new Scales.SixthDiminished();
    public readonly IInterval ModeDegree => new M2();
}

#endregion Diminished6th Modes


#region  Chromatic Modes

public readonly struct Chromatic : IMode
{
    public readonly string Name => "Chromatic Scale";
    public readonly IScale Parent => new Scales.Chromatic();
    public readonly IInterval ModeDegree => new P1();
}

#endregion  Chromatic Modes

#region Diminished Modes

public readonly struct WholeHalf : IMode
{
    public readonly string Name => "Diminished Scale (Whole-Half Diminished)";
    public readonly IScale Parent => new Scales.Diminished();
    public readonly IInterval ModeDegree => new P1();
}

public readonly struct HalfWhole : IMode
{
    public readonly string Name => "Half-Whole Diminished Scale (2nd Mode of the Diminished Scale)";
    public readonly IScale Parent => new Scales.Diminished();
    public readonly IInterval ModeDegree => new M2();
}

#endregion Diminished Modes