
using MusicTheory.Intervals;

namespace MusicTheory.Chords;
/// <summary> https://barisaxo.github.io/pages/arithmetic/triads.html </summary>
public interface ITriad : IChord
{
    public IInterval Third { get; }
    public IInterval Fifth { get; }

    public static IEnumerable<ITriad> GetAll() =>
    [new MajorTriad(), new MinorTriad(), new AugmentedTriad(), new DiminishedTriad()];
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