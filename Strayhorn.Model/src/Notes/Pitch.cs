using System;

namespace MusicTheory.Notes;

///<summary>
/// 88key piano range: A0 - C8. Pitch is a PitchClass with an Octave designation.
/// https://barisaxo.github.io/pages/arithmetic/notes.html
/// </summary>
public readonly struct Pitch : IComparable<Pitch>, IEquatable<Pitch>, IMusicalElement
{
    /// <summary> 88 key piano range: A0 - C8. </summary>
    public const int MinPitchID = 0;
    /// <summary> 88 key piano range: A0 - C8. </summary>
    public const int MaxPitchID = 87;

    /// <summary> ISO octave designations, middle C = C4 </summary>
    public const int MinOctave = 0;
    /// <summary> ISO octave designations, middle C = C4 </summary>
    public const int MaxOctave = 8;

    /// <summary> PitchID = (Octave * Gamut) + 
    /// pitchClass.Chromatic.Value + Chromatic.LetterOffset; </summary>
    public readonly int PitchID;

    public static int GetPitchID(IPitchClass pitchClass, int octave) =>
        (octave * Chromatic.Gamut) + pitchClass.Chromatic.Value + Chromatic.LetterOffset;

    /// <summary> ISO octave designation. </summary> 
    public readonly int Octave;

    public readonly IPitchClass PitchClass;
    public readonly Chromatic Chromatic => PitchClass.Chromatic;

    public readonly string Name => PitchClass.Name + Octave;

    public Pitch(IPitchClass pitchClass, int octave)
    {
        if (octave < MinOctave || octave > MaxOctave)
            throw new ArgumentOutOfRangeException(octave + " is out of octave range");

        PitchID = (octave * Chromatic.Gamut) + pitchClass.Chromatic.Value + Chromatic.LetterOffset;

        if (PitchID < MinPitchID || PitchID > MaxPitchID)
            throw new ArgumentOutOfRangeException(PitchID + " is out of pitch range");

        Octave = octave;
        PitchClass = pitchClass;
    }

    /// <summary>Checks enharmonic equivalency, ignoring octave designation.</summary>
    /// <returns> left.PitchClass.ChromaticValue == right.PitchClass.ChromaticValue; </returns>
    public static bool IsEnharmonic(Pitch left, Pitch right) =>
        left.PitchClass.Chromatic.Value == right.PitchClass.Chromatic.Value;

    /// <summary> Evaluates PitchClass and octave designation (enharmonic equivalents are NOT equal) </summary>
    public static bool operator ==(Pitch left, Pitch right) => Equals(left, right);

    /// <summary> Evaluates PitchClass and octave designation (enharmonic equivalents are NOT equal) </summary>
    public static bool operator !=(Pitch left, Pitch right) => !Equals(left, right);

    /// <summary> Compares pitches by PitchID (enharmonic equivalents are equal, different octaves are not) </summary>
    public readonly int CompareTo(Pitch other) => PitchID.CompareTo(other.PitchID);

    /// <summary> Evaluates PitchClass and octave designation (enharmonic equivalents are NOT equal) </summary>
    public readonly bool Equals(Pitch other) => Name == other.Name;

    /// <summary> Evaluates PitchClass and octave designation (enharmonic equivalents are NOT equal) </summary>
    public readonly override bool Equals(object? obj) => obj is Pitch other && Equals(other);

    /// <summary> returns NoteName.GetHashCode() </summary>
    public readonly override int GetHashCode() => Name.GetHashCode();

}
