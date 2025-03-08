using System;

using MusicTheory.Letters;
namespace MusicTheory.Intervals;

/// <summary>https://barisaxo.github.io/pages/arithmetic/steps.html </summary>
public interface IStep : IMusicalElement
{
    public string Abbrev { get; }
    public Chromatic Chromatic { get; }

    public static IInterval AsInterval(IStep step) => step switch
    {
        H => new mi2(),
        W => new M2(),
        S => new mi3(),
        _ => throw new SystemException()
    };

    public static IStep[] GetAll() =>
        [new H(), new W(), new S()];

    public static IStep[] GetHW() =>
        [new H(), new W(), new S()];

    public static IStep GetStep(Chromatic chromatic) => chromatic.Value switch
    {
        1 => new H(),
        2 => new W(),
        3 => new S(),
        _ => throw new SystemException()
    };

    public static IStep GetStep(ILetter bottom, ILetter top) =>
       GetAll().Single(s => s.Chromatic.Value ==
            (top.Chromatic.Value - bottom.Chromatic.Value +
            (bottom.Chromatic.Value > top.Chromatic.Value ? Chromatic.Gamut : 0)
        ));

}


/// <summary> Half Step = +1 </summary>
public readonly struct H : IStep
{
    public readonly string Name => "Half";
    public readonly string Abbrev => nameof(H);
    public readonly Chromatic Chromatic => new(1);
}


/// <summary> Whole Step = +2 </summary>
public readonly struct W : IStep
{
    public readonly string Name => "Whole";
    public readonly string Abbrev => nameof(W);
    public readonly Chromatic Chromatic => new(2);
}


/// <summary> Skip = +3 </summary>
public readonly struct S : IStep
{
    public readonly string Name => "Skip";
    public readonly string Abbrev => nameof(S);
    public readonly Chromatic Chromatic => new(3);
}