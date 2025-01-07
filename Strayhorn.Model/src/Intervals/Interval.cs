
namespace MusicTheory.Intervals;

// https://barisaxo.github.io/pages/chords/romannumerals.html 
// https://barisaxo.github.io/pages/arithmetic/scales.html 
// https://barisaxo.github.io/pages/arithmetic/triads.html 
// https://barisaxo.github.io/pages/arithmetic/seventhchords.html 
// https://barisaxo.github.io/pages/arithmetic/inversions.html 

/// <summary>https://barisaxo.github.io/pages/arithmetic/intervals.html </summary>

// public readonly struct Interval(IQuality quality, IQuantity quantity)
// {
//     public readonly IQuality Quality = quality;
//     public readonly IQuantity Quantity = quantity;
//     public Chromatic Chromatic => new(Quantity.Chromatic.Value + Quality.Chromatic(Quantity).Value);

//     public string IntervalName => Quality.Name + " " + Quantity.Name;
//     public string IntervalAbbrev => Quality.Abbrev + Quantity.Ordinal;
//     public string ChordTone => Quality.ChordTone + Quantity.ChordTone;
//     public string ScaleDegree => ((Quality is Diminished && Quantity is Seventh)
//         ? "bb" : Quality.ScaleDegree) + Quantity.ScaleDegree;
//     public string RomanNumeral => Quality.ScaleDegree + Quantity.Roman;

//     public static Interval Invert(Interval interval) => GetAll().Single(r =>
//         r.Quality.Equals(IQuality.Invert(interval.Quality)) &&
//         r.Quantity.Equals(IQuantity.Invert(interval.Quantity)));

//     public static IEnumerable<Interval> GetAll() =>
//         [P1, mi2, M2, A2, mi3, M3,
//          d4, P4, A4, d5, P5, A5,
//          mi6, M6, d7, mi7, M7, P8];

//     public static readonly Interval P1 = new(new Perfect(), new Unison());
//     public static readonly Interval mi2 = new(new Minor(), new Second());
//     public static readonly Interval M2 = new(new Major(), new Second());
//     public static readonly Interval A2 = new(new Augmented(), new Second());
//     public static readonly Interval mi3 = new(new Minor(), new Third());
//     public static readonly Interval M3 = new(new Major(), new Third());
//     public static readonly Interval d4 = new(new Diminished(), new Fourth());
//     public static readonly Interval P4 = new(new Perfect(), new Fourth());
//     public static readonly Interval A4 = new(new Augmented(), new Fourth());
//     public static readonly Interval d5 = new(new Diminished(), new Fifth());
//     public static readonly Interval P5 = new(new Perfect(), new Fifth());
//     public static readonly Interval A5 = new(new Augmented(), new Fifth());
//     public static readonly Interval mi6 = new(new Minor(), new Sixth());
//     public static readonly Interval M6 = new(new Major(), new Sixth());
//     public static readonly Interval d7 = new(new Diminished(), new Seventh());
//     public static readonly Interval mi7 = new(new Minor(), new Seventh());
//     public static readonly Interval M7 = new(new Major(), new Seventh());
//     public static readonly Interval P8 = new(new Perfect(), new Octave());
// }

public interface IInterval
{
    public string IntervalName => Quality.Name + " " + Quantity.Name;
    public string IntervalAbbrev => Quality.Abbrev + Quantity.Ordinal;
    public string ChordTone => Quality.ChordTone + Quantity.ChordTone;
    public string RomanNumeral => Quality.ScaleDegree + Quantity.Roman;
    public string ScaleDegree => ((Quality is Diminished && Quantity is Seventh)
        ? "bb" : Quality.ScaleDegree) + Quantity.ScaleDegree;

    public IQuality Quality { get; }
    public IQuantity Quantity { get; }
    public Chromatic Chromatic => new(Quantity.Chromatic.Value + Quality.Chromatic(Quantity).Value);

    public bool IsEnharmonic(IInterval other) => Chromatic.Equals(other.Chromatic);
    public static bool IsEnharmonic(IInterval a, IInterval b) => a.Chromatic.Equals(b.Chromatic);

    public static IInterval Invert(IInterval interval) => GetAll().Single(r =>
        r.Quality.Equals(IQuality.Invert(interval.Quality)) &&
        r.Quantity.Equals(IQuantity.Invert(interval.Quantity)));

    public static IEnumerable<IInterval> GetAll() =>
        [new P1(), new mi2(), new M2(), new A2(), new mi3(), new M3(),
         new d4(), new P4(), new A4(), new d5(), new P5(), new A5(),
         new mi6(), new M6(), new d7(), new mi7(), new M7(), new P8()];
}

#pragma warning disable IDE1006 // Naming Styles

[System.Serializable]
public readonly struct P1 : IInterval
{
    public IQuality Quality => new Perfect();
    public IQuantity Quantity => new Unison();
}

[System.Serializable]
public readonly struct mi2 : IInterval
{
    public IQuality Quality => new Minor();
    public IQuantity Quantity => new Second();
}

[System.Serializable]
public readonly struct M2 : IInterval
{
    public IQuality Quality => new Major();
    public IQuantity Quantity => new Second();
}

[System.Serializable]
public readonly struct A2 : IInterval
{
    public IQuality Quality => new Augmented();
    public IQuantity Quantity => new Second();
}

[System.Serializable]
public readonly struct mi3 : IInterval
{
    public IQuality Quality => new Minor();
    public IQuantity Quantity => new Third();
}

[System.Serializable]
public readonly struct M3 : IInterval
{
    public IQuality Quality => new Major();
    public IQuantity Quantity => new Third();
}

[System.Serializable]
public readonly struct d4 : IInterval
{
    public IQuality Quality => new Diminished();
    public IQuantity Quantity => new Fourth();
}

[System.Serializable]
public readonly struct P4 : IInterval
{
    public IQuality Quality => new Perfect();
    public IQuantity Quantity => new Fourth();
}

[System.Serializable]
public readonly struct A4 : IInterval
{
    public IQuality Quality => new Augmented();
    public IQuantity Quantity => new Fourth();
}

[System.Serializable]
public readonly struct d5 : IInterval
{
    public IQuality Quality => new Diminished();
    public IQuantity Quantity => new Fifth();
}

[System.Serializable]
public readonly struct P5 : IInterval
{
    public IQuality Quality => new Perfect();
    public IQuantity Quantity => new Fifth();
}

[System.Serializable]
public readonly struct A5 : IInterval
{
    public IQuality Quality => new Augmented();
    public IQuantity Quantity => new Fifth();
}

[System.Serializable]
public readonly struct mi6 : IInterval
{
    public IQuality Quality => new Minor();
    public IQuantity Quantity => new Sixth();
}

[System.Serializable]
public readonly struct M6 : IInterval
{
    public IQuality Quality => new Major();
    public IQuantity Quantity => new Sixth();
}

[System.Serializable]
public readonly struct d7 : IInterval
{
    public IQuality Quality => new Diminished();
    public IQuantity Quantity => new Seventh();
}

[System.Serializable]
public readonly struct mi7 : IInterval
{
    public IQuality Quality => new Minor();
    public IQuantity Quantity => new Seventh();
}

[System.Serializable]
public readonly struct M7 : IInterval
{
    public IQuality Quality => new Major();
    public IQuantity Quantity => new Seventh();
}

[System.Serializable]
public readonly struct P8 : IInterval
{
    public IQuality Quality => new Perfect();
    public IQuantity Quantity => new Octave();
}

#pragma warning restore IDE1006 // Naming Styles