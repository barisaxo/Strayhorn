
namespace MusicTheory.Intervals;

//https://barisaxo.github.io/pages/arithmetic/inversions.html 

/// <summary> https://barisaxo.github.io/pages/arithmetic/intervals.html </summary>
public interface IQuantity
{
    public string Name { get; }
    public string Solfege { get; }
    public Chromatic Chromatic { get; }
    public Diatonic ScaleDegree { get; }
    public Diatonic ChordTone { get; }
    public string Roman { get; }
    public string Ordinal { get; }

    public static IQuantity Invert(IQuantity quantity)
    {
        if (quantity is Unison) return new Octave();
        if (quantity is Octave) return new Unison();

        return GetAll().Single(r => r.ScaleDegree.Value ==
             Diatonic.InversionSum - quantity.ScaleDegree.Value);
    }

    public static IEnumerable<IQuantity> GetAll() =>
        [new Unison(), new Second(), new Third(), new Fourth(),
         new Fifth(), new Sixth(), new Seventh(), new Octave()];
}

[System.Serializable]
public readonly struct Unison : IQuantity
{
    public readonly string Name => nameof(Unison);
    public readonly string Solfege => "Do";
    public readonly Chromatic Chromatic => new(0);
    public readonly Diatonic ScaleDegree => new(1);
    public readonly Diatonic ChordTone => new(1);
    public readonly string Roman => "I";
    public readonly string Ordinal => "1st";
}

[System.Serializable]
public readonly struct Second : IQuantity
{
    public readonly string Name => nameof(Second);
    public readonly string Solfege => "Re";
    public readonly Chromatic Chromatic => new(2);
    public readonly Diatonic ScaleDegree => new(2);
    public readonly Diatonic ChordTone => new(9);
    public readonly string Roman => "II";
    public readonly string Ordinal => "2nd";
}

[System.Serializable]
public readonly struct Third : IQuantity
{
    public readonly string Name => nameof(Third);
    public readonly string Solfege => "Mi";
    public readonly Chromatic Chromatic => new(4);
    public readonly Diatonic ScaleDegree => new(3);
    public readonly Diatonic ChordTone => new(3);
    public readonly string Roman => "III";
    public readonly string Ordinal => "3rd";
}

[System.Serializable]
public readonly struct Fourth : IQuantity
{
    public readonly string Name => nameof(Fourth);
    public readonly string Solfege => "Fa";
    public readonly Chromatic Chromatic => new(5);
    public readonly Diatonic ScaleDegree => new(4);
    public readonly Diatonic ChordTone => new(11);
    public readonly string Roman => "IV";
    public readonly string Ordinal => "4th";
}

[System.Serializable]
public readonly struct Fifth : IQuantity
{
    public readonly string Name => nameof(Fifth);
    public readonly string Solfege => "So";
    public readonly Chromatic Chromatic => new(7);
    public readonly Diatonic ScaleDegree => new(5);
    public readonly Diatonic ChordTone => new(5);
    public readonly string Roman => "V";
    public readonly string Ordinal => "5th";
}

[System.Serializable]
public readonly struct Sixth : IQuantity
{
    public readonly string Name => nameof(Sixth);
    public readonly string Solfege => "La";
    public readonly Chromatic Chromatic => new(9);
    public readonly Diatonic ScaleDegree => new(6);
    public readonly Diatonic ChordTone => new(13);
    public readonly string Roman => "VI";
    public readonly string Ordinal => "6th";
}

[System.Serializable]
public readonly struct Seventh : IQuantity
{
    public readonly string Name => nameof(Seventh);
    public readonly string Solfege => "Ti";
    public readonly Chromatic Chromatic => new(11);
    public readonly Diatonic ScaleDegree => new(7);
    public readonly Diatonic ChordTone => new(7);
    public readonly string Roman => "VII";
    public readonly string Ordinal => "7th";
}

[System.Serializable]
public readonly struct Octave : IQuantity
{
    public readonly string Name => nameof(Octave);
    public readonly string Solfege => "Do";
    public readonly Chromatic Chromatic => new(12);
    public readonly Diatonic ScaleDegree => new(8);
    public readonly Diatonic ChordTone => new(1);
    public readonly string Roman => "I";
    public readonly string Ordinal => "8th";
}