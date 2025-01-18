using MusicTheory.Utilities;
namespace MusicTheory.Rhythms;

public interface ITimeSignature
{
    public SubCount SubCount { get; }
    public IMeter Meter { get; }
    public Count Count => GetCount();

    private Count GetCount()
    {
        int i = 0;
        foreach (var p in Meter.Pulses)
            i += (int)p;
        return (Count)i;
    }
}


public class TwoTwo : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new SimpleDuple();
}

public class ThreeTwo : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new SimpleTriple();
}
public class EightTwo : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new SimpleQuadruple();
}
public class FiveTwo23 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new IrregularDupleTriple();
}
public class FiveTwo32 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new IrregularTripleDuple();
}
public class SixTwo : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new CompoundDuple();
}
public class SevenTwo34 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new IrregularTripleQuadruple();
}
public class SevenTwo43 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new IrregularQuadrupleTriple();
}
public class NineTwo : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new CompoundTriple();
}
public class TwelveTwo : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Two;
    public IMeter Meter { get; } = new CompoundQuadruple();
}


public class TwoFour : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new SimpleDuple();
}
public class ThreeFour : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new SimpleTriple();
}
public class FourFour : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new SimpleQuadruple();
}
public class FiveFour23 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new IrregularDupleTriple();
}
public class FiveFour32 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new IrregularTripleDuple();
}
public class SixFour : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new CompoundDuple();
}
public class SevenFour34 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new IrregularTripleQuadruple();
}
public class SevenFour43 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new IrregularQuadrupleTriple();
}
public class NineFour : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new CompoundTriple();
}
public class TwelveFour : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.For;
    public IMeter Meter { get; } = new CompoundQuadruple();
}


public class TwoEight : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new SimpleDuple();
}
public class ThreeEight : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new SimpleTriple();
}
public class FourEight : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new SimpleQuadruple();
}
public class FiveEight23 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new IrregularDupleTriple();
}
public class FiveEight32 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new IrregularTripleDuple();
}
public class SixEight : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new CompoundDuple();
}
public class SevenEight322 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new IrregularTripleQuadruple();
}
public class SevenEight232 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new IrregularTripleQuadruple();
}
public class SevenEight223 : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new Irregular([PulseStress.Quadruple, PulseStress.Triple]);
}
public class NineEight : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new CompoundTriple();
}
public class TwelveEight : ITimeSignature
{
    public SubCount SubCount { get; } = SubCount.Eht;
    public IMeter Meter { get; } = new CompoundQuadruple();
}