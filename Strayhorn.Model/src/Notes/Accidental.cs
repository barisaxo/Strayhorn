using System;

namespace MusicTheory.Notes;

// https://barisaxo.github.io/pages/arithmetic/notes.html
public interface IAccidental : IMusicalElement
{
    public Chromatic Chromatic { get; }
    // public string Name { get; }
    public string Unicode { get; }
    public string Ascii { get; }

    public static IEnumerable<IAccidental> GetAll() =>
        [new DoubleFlat(), new Flat(), new Natural(), new Sharp(), new DoubleSharp(),];

    public static IEnumerable<IAccidental> GetAllExceptDoubles() =>
        [new Flat(), new Natural(), new Sharp(),];
}


public readonly struct DoubleSharp : IAccidental
{
    public readonly string Name => nameof(DoubleSharp);
    public readonly Chromatic Chromatic => new(2);
    public readonly string Unicode => "𝄪";
    public readonly string Ascii => "x";
}


public readonly struct Sharp : IAccidental
{
    public readonly string Name => nameof(Sharp);
    public readonly Chromatic Chromatic => new(1);
    public readonly string Unicode => "♯";
    public readonly string Ascii => "#";
}


public readonly struct Natural : IAccidental
{
    public readonly string Name => nameof(Natural);
    public readonly Chromatic Chromatic => new(0);
    public readonly string Unicode => "";
    public readonly string Ascii => "";
    public static string Actual => "♮";
}


public readonly struct Flat : IAccidental
{
    public readonly string Name => nameof(Flat);
    public readonly Chromatic Chromatic => new(-1);
    public readonly string Unicode => "♭";
    public readonly string Ascii => "b";
}


public readonly struct DoubleFlat : IAccidental
{
    public readonly string Name => nameof(DoubleFlat);
    public readonly Chromatic Chromatic => new(-2);
    public readonly string Unicode => "𝄫";
    public readonly string Ascii => "d";
}