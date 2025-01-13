using System;
using MusicTheory.Intervals;

namespace MusicTheory.Notes;

///<summary>
/// 88key piano range: A0 - C8. Pitch is a PitchClass with an Octave designation.
/// https://barisaxo.github.io/pages/arithmetic/notes.html
/// </summary>
public readonly struct Pitch : IComparable<Pitch>, IComparer<Pitch>, IEquatable<Pitch>, IMusicalElement
{
    /// <summary> 88 key piano range: A0 - C8. </summary>
    public const int MinPitchID = 0;
    /// <summary> 88 key piano range: A0 - C8. </summary>
    public const int MaxPitchID = 87;

    /// <summary> ISO octave designations, middle C = C4 </summary>
    public const int MinOctave = 0;
    /// <summary> ISO octave designations, middle C = C4 </summary>
    public const int MaxOctave = 8;

    public double Frequency => this.GetFrequency();//Frequencies.NoteFrequencies.GetValueOrDefault(Chromatic.Value) * Math.Pow(2, Octave);
    /// <summary> PitchID = (Octave * Gamut) + 
    /// pitchClass.Chromatic.Value + Chromatic.LetterOffset; </summary>
    public readonly int PitchID;

    public static int GetPitchID(IPitchClass pitchClass, int octave) =>
        pitchClass.Chromatic.Value + Chromatic.LetterOffset +
        ((octave + (pitchClass is Cb or Cbb ? -1 : pitchClass is Bs or Bx ? 1 : 0)) * Chromatic.Gamut);


    /// <summary> ISO octave designation. </summary> 
    public readonly int Octave;

    public readonly IPitchClass PitchClass;
    public readonly Chromatic Chromatic => PitchClass.Chromatic;

    public readonly string Name => PitchClass.Name + Octave;

    public Pitch(IPitchClass pitchClass, int octave)
    {
        if (octave < MinOctave || octave > MaxOctave)
            throw new ArgumentOutOfRangeException(octave + " is out of octave range");

        PitchID = GetPitchID(pitchClass, octave);

        if (PitchID < MinPitchID || PitchID > MaxPitchID)
            throw new ArgumentOutOfRangeException(PitchID + " is out of pitch range");

        Octave = octave;
        PitchClass = pitchClass;
    }

    public static Pitch GetPitchAbove(Pitch bottom, IInterval interval, bool allowEnharmonicWhite = false, bool preferDoubles = false)
    {
        IPitchClass topPC = IPitchClass.GetPitchClassAbove(bottom.PitchClass, interval, allowEnharmonicWhite, preferDoubles);
        return new(pitchClass: topPC, bottom.Octave + (GetPitchID(topPC, bottom.Octave) < bottom.PitchID ? 1 : 0));
    }

    public static Pitch GetPitchAbove(Pitch bottom, IStep step, bool allowEnharmonicWhite = false, bool preferDoubles = false)
    {
        IPitchClass topPC = IPitchClass.GetPitchClassAbove(bottom.PitchClass, step, allowEnharmonicWhite, preferDoubles);
        return new(pitchClass: topPC, bottom.Octave + (GetPitchID(topPC, bottom.Octave) < bottom.PitchID ? 1 : 0));
    }

    /// <summary>Checks enharmonic equivalency, ignoring octave designation.</summary>
    /// <returns> left.PitchClass.ChromaticValue == right.PitchClass.ChromaticValue; </returns>
    public static bool IsEnharmonic(Pitch left, Pitch right) =>
        left.PitchClass.Chromatic == right.PitchClass.Chromatic;

    /// <summary> Evaluates PitchClass and octave designation (enharmonic equivalents are NOT equal) </summary>
    public static bool operator ==(Pitch left, Pitch right) => Equals(left, right);

    /// <summary> Evaluates PitchClass and octave designation (enharmonic equivalents are NOT equal) </summary>
    public static bool operator !=(Pitch left, Pitch right) => !Equals(left, right);

    /// <summary> Compares pitches by PitchID (enharmonic equivalents are equal, different octaves are not) </summary>
    public readonly int CompareTo(Pitch other) => PitchID - other.PitchID;

    /// <summary> Evaluates PitchClass and octave designation (enharmonic equivalents are NOT equal) </summary>
    public readonly bool Equals(Pitch other) => Name == other.Name;

    /// <summary> Evaluates PitchClass and octave designation (enharmonic equivalents are NOT equal) </summary>
    public readonly override bool Equals(object? obj) => obj is Pitch other && Equals(other);

    /// <summary> returns NoteName.GetHashCode() </summary>
    public readonly override int GetHashCode() => Name.GetHashCode();

    /// <summary> Compares pitches by PitchID (enharmonic equivalents are equal, different octaves are not) </summary>
    public int Compare(Pitch x, Pitch y) => x.PitchID - y.PitchID;
}
