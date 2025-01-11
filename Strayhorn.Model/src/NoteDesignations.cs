namespace MusicTheory;

/// <summary>
/// Chromatic values help define pitches and accidentals.
/// </summary>
public readonly struct Chromatic(int value) : IEquatable<Chromatic>
{
    /// <summary>The chromatic value of a pitch class is the sum of 
    /// the chromatic values of its letter and accidental, starting with 0 at C. </summary>
    public readonly int Value = (value + Gamut) % Gamut;

    /// <summary> https://en.wikipedia.org/wiki/12_equal_temperament </summary>
    public const int Gamut = 12;

    /// <summary> Offset letter value since octaves start at 'C'.
    ///  <para>Also, interestingly, the additive inverse of the Diatonic InversionSum.</para> </summary>
    public const int LetterOffset = -9;

    public bool Equals(Chromatic other) => other is Chromatic c && c.Value == Value;
    public override bool Equals(object? other) => other is Chromatic c && c.Value == Value;
    public static bool operator ==(Chromatic l, Chromatic r) => l.Equals(r);
    public static bool operator !=(Chromatic l, Chromatic r) => !l.Equals(r);
    public override int GetHashCode() => Value;
}

/// <summary>
/// Diatonic values help define scale degrees, intervals, and chord tones.
/// </summary>
public readonly struct Diatonic(int value)
{
    /// <summary>Diatonic values are based off of the major scale. </summary>
    public readonly int Value = ((value - 1) % Gamut) + 1;

    /// <summary> There are 7 notes in the diatonic scale. </summary>
    public const int Gamut = 7;

    /// <summary> When you add the scale degree to its inversion pair, you get 9. </summary>
    public const int InversionSum = 9;
}