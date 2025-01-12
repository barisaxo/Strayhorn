
using MusicTheory.Intervals;

namespace MusicTheory.Chords;

public interface I7Chord : IChord
{
    public IInterval Third { get; }
    public IInterval Fifth { get; }
    public IInterval Seventh { get; }

    public static IEnumerable<I7Chord> Sixths() => [
        new Major6(), new Minor6(),
    ];

    public static IEnumerable<I7Chord> MajorTonality() => [
       new Major6(), new Major7(), new Minor7(), new Dominant7(), new SevenSus(),
    ];

    public static IEnumerable<I7Chord> MinorTonality() => [
        new Minor6(), new Minor7Flat5(),  new Augmented7(), new TonicMinor7(),
       ];

    public static IEnumerable<I7Chord> PassingChordDominant() => [
        new SevenSharp11(),new Diminished7(),
       ];

    public static IEnumerable<I7Chord> Sevenths() => [
        new Major7(), new Minor7(), new Dominant7(), new SevenSus(),
        new Minor7Flat5(), new Diminished7(), new Augmented7(), new TonicMinor7(), new SevenSharp11(),
    ];

    public static IEnumerable<I7Chord> GetAll() => [
        new Major6(), new Major7(), new Minor7(), new Dominant7(), new SevenSus(),
        new Minor6(), new Minor7Flat5(),  new Augmented7(), new TonicMinor7(),
        new SevenSharp11(),new Diminished7(),
    ];
}

public readonly struct Major7 : I7Chord
{
    public readonly string Name => nameof(Major7);
    public readonly string ChordSymbol => "∆7";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval Seventh => new M7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Major6 : I7Chord
{
    public readonly string Name => nameof(Major6);
    public readonly string ChordSymbol => "6";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval Seventh => new M6();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Minor7 : I7Chord
{
    public readonly string Name => nameof(Minor7);
    public readonly string ChordSymbol => "-7";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval Seventh => new mi7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct TonicMinor7 : I7Chord
{
    public readonly string Name => nameof(TonicMinor7);
    public readonly string ChordSymbol => "-∆7";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval Seventh => new M7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Minor6 : I7Chord
{
    public readonly string Name => nameof(Minor6);
    public readonly string ChordSymbol => "-6";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval Seventh => new M6();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Minor7Flat5 : I7Chord
{
    public readonly string Name => nameof(Minor7Flat5);
    public readonly string ChordSymbol => "-7(b5)";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new d5();
    public readonly IInterval Seventh => new mi7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Dominant7 : I7Chord
{
    public readonly string Name => nameof(Dominant7);
    public readonly string ChordSymbol => "7";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval Seventh => new mi7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct SevenSus : I7Chord
{
    public readonly string Name => nameof(SevenSus);
    public readonly string ChordSymbol => "7(sus)";
    public readonly IInterval Third => new P4();
    public readonly IInterval Fifth => new P5();
    public readonly IInterval Seventh => new mi7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Augmented7 : I7Chord
{
    public readonly string Name => nameof(Augmented7);
    public readonly string ChordSymbol => "+7";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new A5();
    public readonly IInterval Seventh => new mi7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct Diminished7 : I7Chord
{
    public readonly string Name => nameof(Diminished7);
    public readonly string ChordSymbol => "º7";
    public readonly IInterval Third => new mi3();
    public readonly IInterval Fifth => new d5();
    public readonly IInterval Seventh => new d7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

public readonly struct SevenSharp11 : I7Chord
{
    public readonly string Name => nameof(SevenSharp11);
    public readonly string ChordSymbol => "7(#11)";
    public readonly IInterval Third => new M3();
    public readonly IInterval Fifth => new A4();
    public readonly IInterval Seventh => new mi7();
    public readonly IInterval[] ChordTones => [new P1(), Third, Fifth, Seventh];
    public readonly IInterval[] AvailableTensions => [];
}

