
namespace MusicTheory.Rhythms;


public interface IDurationSymbol : IMusicalElement
{
    public int Value { get; }

    public static IEnumerable<IDurationSymbol> GetAll() =>
    [new Whole(),
     new DotHalf(), new Half(), new TripHalf(),
     new DotQuarter(), new Quarter(), new TripQuarter(),
     new DotEighth(), new Eighth(), new TripEighth(),
     new Sixteenth()];
}

public class Whole : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.Whole;
    public string Name => nameof(Whole);
}

public class DotHalf : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.DotHalf;
    public string Name => nameof(Half);
}
public class Half : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.Half;
    public string Name => nameof(Half);
}
public class TripHalf : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.TripHalf;
    public string Name => nameof(Half);
}

public class DotQuarter : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.DotQuarter;
    public string Name => nameof(Quarter);
}
public class Quarter : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.Quarter;
    public string Name => nameof(Quarter);
}
public class TripQuarter : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.TripQuarter;
    public string Name => nameof(Quarter);
}

public class DotEighth : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.DotEighth;
    public string Name => nameof(Eighth);
}
public class Eighth : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.Eighth;
    public string Name => nameof(Eighth);
}
public class TripEighth : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.TripEighth;
    public string Name => nameof(Eighth);
}

public class Sixteenth() : IDurationSymbol
{
    public int Value { get; } = (int)RhythmicValue.Sixteenth;
    public string Name => nameof(Sixteenth);
}