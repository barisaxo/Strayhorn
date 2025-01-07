using System;

namespace MusicTheory.Notes;

// https://barisaxo.github.io/pages/arithmetic/notes.html
public interface IAccidental
{
    public Chromatic Chromatic { get; }
    public string Name { get; }
    public string Unicode { get; }
    public string Ascii { get; }

    public static IEnumerable<IAccidental> GetAll() =>
        [new DoubleSharp(), new Sharp(), new Natural(), new Flat(), new DoubleFlat()];
}

[System.Serializable]
public readonly struct DoubleSharp : IAccidental
{
    public readonly string Name => nameof(DoubleSharp);
    public readonly Chromatic Chromatic => new(2);
    public readonly string Unicode => "𝄪";
    public readonly string Ascii => "x";
}

[System.Serializable]
public readonly struct Sharp : IAccidental
{
    public readonly string Name => nameof(Sharp);
    public readonly Chromatic Chromatic => new(1);
    public readonly string Unicode => "♯";
    public readonly string Ascii => "#";
}

[System.Serializable]
public readonly struct Natural : IAccidental
{
    public readonly string Name => nameof(Natural);
    public readonly Chromatic Chromatic => new(0);
    public readonly string Unicode => "";
    public readonly string Ascii => "";
    public static string Actual => "♮";
}

[System.Serializable]
public readonly struct Flat : IAccidental
{
    public readonly string Name => nameof(Flat);
    public readonly Chromatic Chromatic => new(-1);
    public readonly string Unicode => "♭";
    public readonly string Ascii => "b";
}

[System.Serializable]
public readonly struct DoubleFlat : IAccidental
{
    public readonly string Name => nameof(DoubleFlat);
    public readonly Chromatic Chromatic => new(-2);
    public readonly string Unicode => "𝄫";
    public readonly string Ascii => "d";
}