using System;
using MusicTheory.Intervals;
using MusicTheory.Letters;
namespace MusicTheory.Notes;

/// <summary> https://barisaxo.github.io/pages/arithmetic/notes.html </summary> 
// public readonly struct PitchClass(ILetter letter, IAccidental accidental) :
//     IEquatable<PitchClass>, IComparable<PitchClass>
// {
//     public readonly ILetter Letter { get; } = letter;
//     public readonly IAccidental Accidental { get; } = accidental;

//     public string Name => Letter.Name + Accidental.Symbol;
//     public Chromatic Chromatic => new(Letter.Chromatic.Value + Accidental.Chromatic.Value);

//     public static PitchClass GetStepAbove(PitchClass pitchClass, IStep step)
//     {
//         var letter = ILetter.GetNextLetter(pitchClass.Letter);

//         int chromaticDiff = letter.Chromatic.Value - pitchClass.Chromatic.Value - step.Chromatic.Value
//             + (pitchClass.Chromatic.Value > letter.Chromatic.Value ? Chromatic.Gamut : 0);

//         var accidental = IAccidental.GetAll().First(a => a.Chromatic.Value == chromaticDiff);

//         return new PitchClass(letter, accidental);
//     }

//     public static bool operator ==(PitchClass left, PitchClass right) => Equals(left, right);
//     public static bool operator !=(PitchClass left, PitchClass right) => !Equals(left, right);
//     public readonly int CompareTo(PitchClass other) => Chromatic.Value.CompareTo(other.Chromatic.Value);
//     public readonly bool Equals(PitchClass other) => Name == other.Name;
//     public readonly override bool Equals(object? obj) => obj is PitchClass other && Equals(other);
//     public readonly override int GetHashCode() => HashCode.Combine(Chromatic, Name);
// }

public interface IPitchClass
{
    public ILetter Letter { get; }
    public IAccidental Accidental { get; }

    public string Name => Letter.Name + Accidental.Unicode;
    public Chromatic Chromatic => new(Letter.Chromatic.Value + Accidental.Chromatic.Value);

    public static IEnumerable<IPitchClass> GetAll() => [
        new A(), new B(), new C(), new D(), new E(), new F(), new G(),
        new Ab(), new Bb(), new Cb(), new Db(), new Eb(), new Fb(), new Gb(),
        new As(), new Bs(), new Cs(), new Ds(), new Es(), new Fs(), new Gs(),
        new Ax(), new Bx(), new Cx(), new Dx(), new Ex(), new Fx(), new Gx(),
        new Abb(), new Bbb(), new Cbb(), new Dbb(), new Ebb(), new Fbb(), new Gbb()
    ];

    public static IPitchClass Get(ILetter letter, IAccidental accidental) =>
        GetAll().Single(pc => pc.Letter.Equals(letter) && pc.Accidental.Equals(accidental));

    public static IPitchClass GetPitchClassAbove(IPitchClass pitchClass, IStep step, bool AllowEnharmonicWhite = false, bool preferDoubles = false)
    {
        var letter = ILetter.GetNextLetter(pitchClass.Letter);

        int chromaticSum = (pitchClass.Chromatic.Value + step.Chromatic.Value) % Chromatic.Gamut;

        try
        {
            var getPC = GetAll().Single(pc => pc.Letter.Equals(letter) && pc.Chromatic.Value == chromaticSum);
            if (!preferDoubles && getPC.Accidental is DoubleFlat or DoubleSharp) throw new Exception();
            if (!AllowEnharmonicWhite && (getPC is Cb or Fb or Bs or Es)) throw new Exception();
            else return getPC;
        }
        catch
        {
            try
            {
                return GetAll().First(pc => pc.Accidental is Natural && pc.Chromatic.Value == chromaticSum);
            }
            catch
            {
                return GetAll().First(pc => pc.Accidental is Sharp or Flat && pc.Chromatic.Value == chromaticSum);
            }
        }
    }

    public static IPitchClass GetPitchClassAbove(IPitchClass pitchClass, IInterval interval, bool allowEnharmonicWhite = false, bool preferDoubles = false)
    {
        var letter = ILetter.GetLetterAbove(pitchClass.Letter, interval);
        int chromaticSum = (pitchClass.Chromatic.Value + interval.Chromatic.Value) % Chromatic.Gamut;
        var all = GetAll();
        try
        {
            var get = all.Single(pc => pc.Letter.Equals(letter) && pc.Chromatic.Value == chromaticSum);
            if (!preferDoubles && get.Accidental is DoubleFlat or DoubleSharp) { throw new Exception("Double Accidental"); }
            if (!allowEnharmonicWhite && (get is Cb or Fb or Bs or Es)) { throw new Exception("Enharmonic White"); }
            else return get;
        }
        catch
        {
            try
            {
                return all.Single(pc => pc.Accidental is Natural && pc.Chromatic.Value == chromaticSum);
            }
            catch
            {
                try
                {
                    return all.Single(pc => pc.Letter == letter && pc.Chromatic.Value == chromaticSum);
                }
                catch
                {
                    return all.First(pc => pc.Accidental is Sharp or Flat && pc.Chromatic.Value == chromaticSum);
                }
            }
        }
    }
}

public readonly struct A : IPitchClass { public ILetter Letter => new Letters.A(); public IAccidental Accidental => new Natural(); }
public readonly struct B : IPitchClass { public ILetter Letter => new Letters.B(); public IAccidental Accidental => new Natural(); }
public readonly struct C : IPitchClass { public ILetter Letter => new Letters.C(); public IAccidental Accidental => new Natural(); }
public readonly struct D : IPitchClass { public ILetter Letter => new Letters.D(); public IAccidental Accidental => new Natural(); }
public readonly struct E : IPitchClass { public ILetter Letter => new Letters.E(); public IAccidental Accidental => new Natural(); }
public readonly struct F : IPitchClass { public ILetter Letter => new Letters.F(); public IAccidental Accidental => new Natural(); }
public readonly struct G : IPitchClass { public ILetter Letter => new Letters.G(); public IAccidental Accidental => new Natural(); }

public readonly struct As : IPitchClass { public ILetter Letter => new Letters.A(); public IAccidental Accidental => new Sharp(); }
public readonly struct Bs : IPitchClass { public ILetter Letter => new Letters.B(); public IAccidental Accidental => new Sharp(); }
public readonly struct Cs : IPitchClass { public ILetter Letter => new Letters.C(); public IAccidental Accidental => new Sharp(); }
public readonly struct Ds : IPitchClass { public ILetter Letter => new Letters.D(); public IAccidental Accidental => new Sharp(); }
public readonly struct Es : IPitchClass { public ILetter Letter => new Letters.E(); public IAccidental Accidental => new Sharp(); }
public readonly struct Fs : IPitchClass { public ILetter Letter => new Letters.F(); public IAccidental Accidental => new Sharp(); }
public readonly struct Gs : IPitchClass { public ILetter Letter => new Letters.G(); public IAccidental Accidental => new Sharp(); }

public readonly struct Ab : IPitchClass { public ILetter Letter => new Letters.A(); public IAccidental Accidental => new Flat(); }
public readonly struct Bb : IPitchClass { public ILetter Letter => new Letters.B(); public IAccidental Accidental => new Flat(); }
public readonly struct Cb : IPitchClass { public ILetter Letter => new Letters.C(); public IAccidental Accidental => new Flat(); }
public readonly struct Db : IPitchClass { public ILetter Letter => new Letters.D(); public IAccidental Accidental => new Flat(); }
public readonly struct Eb : IPitchClass { public ILetter Letter => new Letters.E(); public IAccidental Accidental => new Flat(); }
public readonly struct Fb : IPitchClass { public ILetter Letter => new Letters.F(); public IAccidental Accidental => new Flat(); }
public readonly struct Gb : IPitchClass { public ILetter Letter => new Letters.G(); public IAccidental Accidental => new Flat(); }

public readonly struct Ax : IPitchClass { public ILetter Letter => new Letters.A(); public IAccidental Accidental => new DoubleSharp(); }
public readonly struct Bx : IPitchClass { public ILetter Letter => new Letters.B(); public IAccidental Accidental => new DoubleSharp(); }
public readonly struct Cx : IPitchClass { public ILetter Letter => new Letters.C(); public IAccidental Accidental => new DoubleSharp(); }
public readonly struct Dx : IPitchClass { public ILetter Letter => new Letters.D(); public IAccidental Accidental => new DoubleSharp(); }
public readonly struct Ex : IPitchClass { public ILetter Letter => new Letters.E(); public IAccidental Accidental => new DoubleSharp(); }
public readonly struct Fx : IPitchClass { public ILetter Letter => new Letters.F(); public IAccidental Accidental => new DoubleSharp(); }
public readonly struct Gx : IPitchClass { public ILetter Letter => new Letters.G(); public IAccidental Accidental => new DoubleSharp(); }

public readonly struct Abb : IPitchClass { public ILetter Letter => new Letters.A(); public IAccidental Accidental => new DoubleFlat(); }
public readonly struct Bbb : IPitchClass { public ILetter Letter => new Letters.B(); public IAccidental Accidental => new DoubleFlat(); }
public readonly struct Cbb : IPitchClass { public ILetter Letter => new Letters.C(); public IAccidental Accidental => new DoubleFlat(); }
public readonly struct Dbb : IPitchClass { public ILetter Letter => new Letters.D(); public IAccidental Accidental => new DoubleFlat(); }
public readonly struct Ebb : IPitchClass { public ILetter Letter => new Letters.E(); public IAccidental Accidental => new DoubleFlat(); }
public readonly struct Fbb : IPitchClass { public ILetter Letter => new Letters.F(); public IAccidental Accidental => new DoubleFlat(); }
public readonly struct Gbb : IPitchClass { public ILetter Letter => new Letters.G(); public IAccidental Accidental => new DoubleFlat(); }
