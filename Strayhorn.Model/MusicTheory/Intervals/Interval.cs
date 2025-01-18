
namespace MusicTheory.Intervals;

// https://barisaxo.github.io/pages/chords/romannumerals.html 
// https://barisaxo.github.io/pages/arithmetic/scales.html 
// https://barisaxo.github.io/pages/arithmetic/triads.html 
// https://barisaxo.github.io/pages/arithmetic/seventhchords.html 
// https://barisaxo.github.io/pages/arithmetic/inversions.html 

/// <summary>https://barisaxo.github.io/pages/arithmetic/intervals.html </summary>
public interface IInterval : IMusicalElement
{
    public string IntervalAbbrev => Quality.Abbrev + Quantity.Ordinal;
    public string ChordTone => Quality.ChordTone + Quantity.ChordTone;
    public string RomanNumeral => Quality.ScaleDegree + Quantity.Roman;
    public string ScaleDegree => ((Quality is Diminished && Quantity is Seventh)
        ? "𝄫" : Quality.ScaleDegree) + Quantity.ScaleDegree.Value;

    public IQuality Quality { get; }
    public IQuantity Quantity { get; }
    public Chromatic Chromatic => new(Quantity.Chromatic.Value + Quality.Chromatic(Quantity).Value);

    public bool IsEnharmonic(IInterval other) => Chromatic.Equals(other.Chromatic);
    public static bool IsEnharmonic(IInterval a, IInterval b) => a.Chromatic.Equals(b.Chromatic);

    public static IInterval Invert(IInterval interval) => GetAll().Single(r =>
        r.Quality.Equals(IQuality.Invert(interval.Quality)) &&
        r.Quantity.Equals(IQuantity.Invert(interval.Quantity)));

    public static IInterval GetInterval(IInterval left, IInterval right)
    {
        IInterval newInterval = new P1();
        IQuantity quantity = IQuantity.GetQuantity(left, right);
        int chromaticValue = (right.Chromatic.Value + Chromatic.Gamut - left.Chromatic.Value) % Chromatic.Gamut;

        foreach (var interval in GetAll())
        {
            if (interval.Chromatic.Value.Equals(chromaticValue) &&
                MathF.Abs(interval.Quantity.ScaleDegree.Value - quantity.ScaleDegree.Value) <
                MathF.Abs(newInterval.Quantity.ScaleDegree.Value - quantity.ScaleDegree.Value))
                newInterval = interval;
        }

        return newInterval;
    }

    public static IEnumerable<IInterval> GetAll() =>
        [new P1(), new mi2(), new M2(), new A2(), new mi3(), new M3(),
         new d4(), new P4(), new A4(), new d5(), new P5(), new A5(),
         new mi6(), new M6(), new d7(), new mi7(), new M7(), new P8()];


    public static IEnumerable<IInterval> GetCommonNoP1() =>
        [new mi2(), new M2(), new mi3(), new M3(),
          new P4(), new A4(), new d5(), new P5(),
          new mi6(), new M6(), new mi7(), new M7(), new P8()];

    public static IEnumerable<IInterval> GetAllNoP1() =>
        [new mi2(), new M2(), new A2(), new mi3(), new M3(),
         new d4(), new P4(), new A4(), new d5(), new P5(), new A5(),
         new mi6(), new M6(), new d7(), new mi7(), new M7(), new P8()];
}

#pragma warning disable IDE1006 // Naming Styles


public readonly struct P1 : IInterval
{
    public IQuality Quality => new Perfect();
    public IQuantity Quantity => new Unison();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct mi2 : IInterval
{
    public IQuality Quality => new Minor();
    public IQuantity Quantity => new Second();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct M2 : IInterval
{
    public IQuality Quality => new Major();
    public IQuantity Quantity => new Second();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct A2 : IInterval
{
    public IQuality Quality => new Augmented();
    public IQuantity Quantity => new Second();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct mi3 : IInterval
{
    public IQuality Quality => new Minor();
    public IQuantity Quantity => new Third();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct M3 : IInterval
{
    public IQuality Quality => new Major();
    public IQuantity Quantity => new Third();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct d4 : IInterval
{
    public IQuality Quality => new Diminished();
    public IQuantity Quantity => new Fourth();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct P4 : IInterval
{
    public IQuality Quality => new Perfect();
    public IQuantity Quantity => new Fourth();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct A4 : IInterval
{
    public IQuality Quality => new Augmented();
    public IQuantity Quantity => new Fourth();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct d5 : IInterval
{
    public IQuality Quality => new Diminished();
    public IQuantity Quantity => new Fifth();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct P5 : IInterval
{
    public IQuality Quality => new Perfect();
    public IQuantity Quantity => new Fifth();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct A5 : IInterval
{
    public IQuality Quality => new Augmented();
    public IQuantity Quantity => new Fifth();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct mi6 : IInterval
{
    public IQuality Quality => new Minor();
    public IQuantity Quantity => new Sixth();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct M6 : IInterval
{
    public IQuality Quality => new Major();
    public IQuantity Quantity => new Sixth();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct d7 : IInterval
{
    public IQuality Quality => new Diminished();
    public IQuantity Quantity => new Seventh();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct mi7 : IInterval
{
    public IQuality Quality => new Minor();
    public IQuantity Quantity => new Seventh();
    public string Name => Quality.Name + " " + Quantity.Name;
}


public readonly struct M7 : IInterval
{
    public IQuality Quality => new Major();
    public IQuantity Quantity => new Seventh();
    public string Name => Quality.Name + " " + Quantity.Name;
}

/// <summary>
/// Octaves need to be handled manually, the arithmetic does a modulo wrap. 
/// P8 is essentially the same as P1, except by name (they both have chromatic value of 0).
/// </summary>
public readonly struct P8 : IInterval
{
    public IQuality Quality => new Perfect();
    public IQuantity Quantity => new Octave();
    public string Name => Quality.Name + " " + Quantity.Name;
}

#pragma warning restore IDE1006 // Naming Styles