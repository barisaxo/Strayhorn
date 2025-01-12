

namespace MusicTheory.Intervals;


//https://barisaxo.github.io/pages/arithmetic/inversions.html 

/// <summary>https://barisaxo.github.io/pages/arithmetic/intervals.html </summary>
public interface IQuality
{
    public string Name { get; }
    public string Abbrev { get; }
    public string ChordTone { get; }
    public string ScaleDegree { get; }
    public Chromatic Chromatic(IQuantity quantity);

    public static IQuality Invert(IQuality quality) => quality switch
    {
        Major => new Minor(),
        Minor => new Major(),
        Perfect => new Perfect(),
        Augmented => new Diminished(),
        Diminished => new Augmented(),
        _ => throw new System.NotSupportedException(),
    };

    public static IEnumerable<IQuality> GetAll() =>
        [new Major(), new Minor(), new Augmented(), new Diminished(), new Perfect()];
}

[System.Serializable]
public readonly struct Major : IQuality
{
    public string Name => nameof(Major);
    public string Abbrev => "M";
    public string ChordTone => "∆";
    public string ScaleDegree => "";
    public Chromatic Chromatic(IQuantity quantity) => new(0);
}

[System.Serializable]
public readonly struct Minor : IQuality
{
    public string Name => nameof(Minor);
    public string Abbrev => "mi";
    public string ChordTone => "-";
    public string ScaleDegree => "b";
    public Chromatic Chromatic(IQuantity quantity) => new(-1);
}

[System.Serializable]
public readonly struct Augmented : IQuality
{
    public string Name => nameof(Augmented);
    public string Abbrev => "A";
    public string ChordTone => "+";
    public string ScaleDegree => "#";
    public Chromatic Chromatic(IQuantity quantity) => new(1);
}

[System.Serializable]
public readonly struct Diminished : IQuality
{
    public string Name => nameof(Diminished);
    public string Abbrev => "d";
    public string ChordTone => "º";
    public string ScaleDegree => "b";
    public Chromatic Chromatic(IQuantity quantity) => quantity switch
    {
        Fourth or Fifth => new(-1),
        Seventh => new(-2),
        _ => throw new System.ArgumentException(quantity.Name + "s should not be diminished"),
    };
}

[System.Serializable]
public readonly struct Perfect : IQuality
{
    public string Name => nameof(Perfect);
    public string Abbrev => "P";
    public string ChordTone => "";
    public string ScaleDegree => "";
    public Chromatic Chromatic(IQuantity quantity) => new(0);
}