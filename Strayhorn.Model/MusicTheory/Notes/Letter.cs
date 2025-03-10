using System.Collections.Generic;
using MusicTheory.Intervals;

namespace MusicTheory.Letters;

/// <summary> https://barisaxo.github.io/pages/arithmetic/notes.html </summary> 

public interface ILetter : IMusicalElement
{
    public Chromatic Chromatic { get; }
    public Diatonic Diatonic { get; }

    public static ILetter[] GetAll() =>
        [new C(), new D(), new E(), new F(), new G(), new A(), new B()];

    public static ILetter GetNextLetter(ILetter letter) =>
        GetAll().Single(l => l.Diatonic.Value == (letter.Diatonic.Value % Diatonic.Gamut) + 1);
    // GetAll().ToList()[letter.Diatonic.Value % Diatonic.Gamut]; //just a different way to do it

    public static ILetter GetLetterAbove(ILetter letter, IInterval interval)
    {
        return GetAll().Single(l => l.Diatonic.Value == ((letter.Diatonic.Value - 2 + interval.Quantity.ChordTone.Value) % Diatonic.Gamut) + 1);
    }

    public static ILetter GetRandomLetter() => new Random().Next(0, 7) switch
    { 0 => new C(), 1 => new D(), 2 => new E(), 3 => new F(), 4 => new G(), 5 => new A(), _ => new B() };
}


public readonly struct C : ILetter
{
    public string Name => nameof(C);
    public Chromatic Chromatic => new(0);
    public Diatonic Diatonic => new(1);
}


public readonly struct D : ILetter
{
    public string Name => nameof(D);
    public Chromatic Chromatic => new(2);
    public Diatonic Diatonic => new(2);
}


public readonly struct E : ILetter
{
    public string Name => nameof(E);
    public Chromatic Chromatic => new(4);
    public Diatonic Diatonic => new(3);
}


public readonly struct F : ILetter
{
    public string Name => nameof(F);
    public Chromatic Chromatic => new(5);
    public Diatonic Diatonic => new(4);
}


public readonly struct G : ILetter
{
    public string Name => nameof(G);
    public Chromatic Chromatic => new(7);
    public Diatonic Diatonic => new(5);
}


public readonly struct A : ILetter
{
    public string Name => nameof(A);
    public Chromatic Chromatic => new(9);
    public Diatonic Diatonic => new(6);
}


public readonly struct B : ILetter
{
    public string Name => nameof(B);
    public Chromatic Chromatic => new(11);
    public Diatonic Diatonic => new(7);
}
