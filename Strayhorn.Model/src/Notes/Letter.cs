using System.Collections.Generic;

namespace MusicTheory.Letters;

/// <summary> https://barisaxo.github.io/pages/arithmetic/notes.html </summary> 

public interface ILetter : IMusicalElement
{
    public Chromatic Chromatic { get; }
    public Diatonic Diatonic { get; }

    public static IEnumerable<ILetter> GetAll() =>
        [new C(), new D(), new E(), new F(), new G(), new A(), new B()];

    public static ILetter GetNextLetter(ILetter letter) =>
        GetAll().Single(l => l.Diatonic.Value == (letter.Diatonic.Value % Diatonic.Gamut) + 1);
    // GetAll().ToList()[letter.Diatonic.Value % Diatonic.Gamut]; //just a different way to do it
}

[System.Serializable]
public readonly struct C : ILetter
{
    public string Name => nameof(C);
    public Chromatic Chromatic => new(0);
    public Diatonic Diatonic => new(1);
}

[System.Serializable]
public readonly struct D : ILetter
{
    public string Name => nameof(D);
    public Chromatic Chromatic => new(2);
    public Diatonic Diatonic => new(2);
}

[System.Serializable]
public readonly struct E : ILetter
{
    public string Name => nameof(E);
    public Chromatic Chromatic => new(4);
    public Diatonic Diatonic => new(3);
}

[System.Serializable]
public readonly struct F : ILetter
{
    public string Name => nameof(F);
    public Chromatic Chromatic => new(5);
    public Diatonic Diatonic => new(4);
}

[System.Serializable]
public readonly struct G : ILetter
{
    public string Name => nameof(G);
    public Chromatic Chromatic => new(7);
    public Diatonic Diatonic => new(5);
}

[System.Serializable]
public readonly struct A : ILetter
{
    public string Name => nameof(A);
    public Chromatic Chromatic => new(9);
    public Diatonic Diatonic => new(6);
}

[System.Serializable]
public readonly struct B : ILetter
{
    public string Name => nameof(B);
    public Chromatic Chromatic => new(11);
    public Diatonic Diatonic => new(7);
}
