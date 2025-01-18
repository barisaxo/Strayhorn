
using MusicTheory.Intervals;

namespace MusicTheory.Chords;
/// <summary> https://barisaxo.github.io/pages/arithmetic/triads.html </summary>
public interface ITriad : IChord
{
    public IInterval Third { get; }
    public IInterval Fifth { get; }

    public static IEnumerable<ITriad> GetAll() =>
    [new Major(), new Minor(), new Augmented(), new Diminished(),
     new Sus4(), new Sus2(), new Power()];

    public static IEnumerable<ITriad> GetCommon() =>
    [new Major(), new Minor(), new Augmented(), new Diminished()];

    public static IEnumerable<ITriad> GetTheoretical() =>
    [new Sus4(), new Sus2(), new Power()];
}

public readonly struct Major : ITriad
{
    public readonly string Name => nameof(Major);
    public readonly string ChordSymbol => "";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Minor : ITriad
{
    public readonly string Name => nameof(Minor);
    public readonly string ChordSymbol => "-";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Augmented : ITriad
{
    public readonly string Name => nameof(Augmented);
    public readonly string ChordSymbol => "+";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new A5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Diminished : ITriad
{
    public readonly string Name => nameof(Diminished);
    public readonly string ChordSymbol => "º";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new d5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Sus2 : ITriad
{
    public readonly string Name => nameof(Sus2);
    public readonly string ChordSymbol => "2";
    public readonly IInterval Third => new M2();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Sus4 : ITriad
{
    public readonly string Name => nameof(Sus4);
    public readonly string ChordSymbol => "4";
    public readonly IInterval Third => new P4();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Power : ITriad
{
    public readonly string Name => nameof(Power);
    public readonly string ChordSymbol => "5";
    public readonly IInterval Third => new P5();
    public readonly IInterval Fifth => new P8();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}