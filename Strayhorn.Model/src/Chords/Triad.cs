
using MusicTheory.Intervals;

namespace MusicTheory.Chords;
/// <summary> https://barisaxo.github.io/pages/arithmetic/triads.html </summary>
public interface ITriad : IChord
{
    public IInterval Third { get; }
    public IInterval Fifth { get; }

    public static IEnumerable<ITriad> GetAll() =>
    [new MajorTriad(), new MinorTriad(), new AugmentedTriad(), new DiminishedTriad(),
     new Sus4Triad(), new Sus2Triad(), new PowerChord()];

    public static IEnumerable<ITriad> GetCommon() =>
    [new MajorTriad(), new MinorTriad(), new AugmentedTriad(), new DiminishedTriad()];

    public static IEnumerable<ITriad> GetTheoretical() =>
    [new Sus4Triad(), new Sus2Triad(), new PowerChord()];
}

public readonly struct MajorTriad : ITriad
{
    public readonly string Name => nameof(MajorTriad);
    public readonly string ChordSymbol => "";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct MinorTriad : ITriad
{
    public readonly string Name => nameof(MinorTriad);
    public readonly string ChordSymbol => "-";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct AugmentedTriad : ITriad
{
    public readonly string Name => nameof(AugmentedTriad);
    public readonly string ChordSymbol => "+";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new A5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct DiminishedTriad : ITriad
{
    public readonly string Name => nameof(DiminishedTriad);
    public readonly string ChordSymbol => "º";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new d5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Sus4Triad : ITriad
{
    public readonly string Name => nameof(Sus4Triad);
    public readonly string ChordSymbol => "4";
    public readonly IInterval Third => new P4();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Sus2Triad : ITriad
{
    public readonly string Name => nameof(Sus2Triad);
    public readonly string ChordSymbol => "2";
    public readonly IInterval Third => new M2();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct PowerChord : ITriad
{
    public readonly string Name => nameof(PowerChord);
    public readonly string ChordSymbol => "5";
    public readonly IInterval Third => new P5();
    public readonly IInterval Fifth => new P8();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth];
    public readonly IInterval[] AvailableTensions => [];
}