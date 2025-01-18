using MusicTheory.Utilities;
namespace MusicTheory.Rhythms;

public interface IMeter
{
    public BeatDivisor Divisor { get; }
    public PulseStress[] Pulses { get; }

    public static IEnumerable<IMeter> GetAllRegular() => [
        new SimpleDuple(), new SimpleTriple(), new SimpleQuadruple(),
        new CompoundDuple(), new CompoundTriple(), new CompoundQuadruple(),
    ];
}

/// <summary> 2/subCount  </summary>
public class SimpleDuple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Simple;
    public PulseStress[] Pulses => [PulseStress.Duple];
}

/// <summary> 3/subCount </summary>
public class SimpleTriple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Simple;
    public PulseStress[] Pulses => [PulseStress.Triple];
}

/// <summary> 4 / subCount  </summary>
public class SimpleQuadruple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Simple;
    public PulseStress[] Pulses => [PulseStress.Quadruple];
}

/// <summary> 6 / subCount  </summary>
public class CompoundDuple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Compound;
    public PulseStress[] Pulses => [PulseStress.Duple];
}

/// <summary> 9 / subCount  </summary>
public class CompoundTriple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Compound;
    public PulseStress[] Pulses => [PulseStress.Triple];
}

/// <summary> 12 / subCount  </summary>
public class CompoundQuadruple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Compound;
    public PulseStress[] Pulses => [PulseStress.Quadruple];
}

/// <summary> 5 : 2+3/subCount </summary>
public class IrregularDupleTriple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Simple;
    public PulseStress[] Pulses => [PulseStress.Duple, PulseStress.Triple];
}

/// <summary> 5 : 3+2/subCount </summary>
public class IrregularTripleDuple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Simple;
    public PulseStress[] Pulses => [PulseStress.Triple, PulseStress.Duple];
}

/// <summary> 7 : 4+3 / subCount </summary>
public class IrregularQuadrupleTriple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Simple;
    public PulseStress[] Pulses => [PulseStress.Quadruple, PulseStress.Triple,];
}

/// <summary> 7 : 3+4 / subCount </summary>
public class IrregularTripleQuadruple : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Simple;
    public PulseStress[] Pulses => [PulseStress.Triple, PulseStress.Quadruple,];
}

public class Irregular(PulseStress[] pulses) : IMeter
{
    public BeatDivisor Divisor => BeatDivisor.Simple;
    public PulseStress[] Pulses { get; } = pulses;
}