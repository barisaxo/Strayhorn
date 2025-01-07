
using MusicTheory.Scales;
using MusicTheory;
namespace MusicTheory.Modes;

public enum ModeDegree { Prime, Second, Third, Fourth, Fifth, Sixth, Seventh }

public interface IMode : IMusicalElement
{
    public IScale Parent { get; }
    public ModeDegree ModeDegree { get; }
}

#region  Major Modes

public readonly struct Ionian : IMode
{
    public readonly string Name => nameof(Ionian);
    public readonly IScale Parent => new Major();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

public readonly struct Dorian : IMode
{
    public readonly string Name => nameof(Dorian);
    public readonly IScale Parent => new Major();
    public readonly ModeDegree ModeDegree => ModeDegree.Second;
}

public readonly struct Phrygian : IMode
{
    public readonly string Name => nameof(Phrygian);
    public readonly IScale Parent => new Major();
    public readonly ModeDegree ModeDegree => ModeDegree.Third;
}

public readonly struct Lydian : IMode
{
    public readonly string Name => nameof(Lydian);
    public readonly IScale Parent => new Major();
    public readonly ModeDegree ModeDegree => ModeDegree.Fourth;
}

public readonly struct Mixolydian : IMode
{
    public readonly string Name => nameof(Mixolydian);
    public readonly IScale Parent => new Major();
    public readonly ModeDegree ModeDegree => ModeDegree.Fifth;
}

public readonly struct Aeolian : IMode
{
    public readonly string Name => nameof(Aeolian);
    public readonly IScale Parent => new Major();
    public readonly ModeDegree ModeDegree => ModeDegree.Sixth;
}

public readonly struct Locrian : IMode
{
    public readonly string Name => nameof(Locrian);
    public readonly IScale Parent => new Major();
    public readonly ModeDegree ModeDegree => ModeDegree.Seventh;
}

#endregion  Major Modes


#region  Pentatonic Modes

public readonly struct Pentatonic : IMode
{
    public readonly string Name => nameof(Pentatonic);
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

public readonly struct PentatonicII : IMode
{
    public readonly string Name => nameof(PentatonicII);
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly ModeDegree ModeDegree => ModeDegree.Second;
}

public readonly struct PentatonicIII : IMode
{
    public readonly string Name => nameof(PentatonicIII);
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly ModeDegree ModeDegree => ModeDegree.Third;
}

public readonly struct PentatonicIV : IMode
{
    public readonly string Name => nameof(PentatonicIV);
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly ModeDegree ModeDegree => ModeDegree.Fourth;
}

public readonly struct PentatonicMinor : IMode
{
    public readonly string Name => nameof(PentatonicMinor);
    public readonly IScale Parent => new Scales.Pentatonic();
    public readonly ModeDegree ModeDegree => ModeDegree.Fifth;
}

#endregion  Pentatonic Modes


#region Blues Modes

public readonly struct Blues : IMode
{
    public readonly string Name => nameof(Blues);
    public readonly IScale Parent => new Scales.Blues();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

public readonly struct MajorBlues : IMode
{
    public readonly string Name => nameof(MajorBlues);
    public readonly IScale Parent => new Scales.Blues();
    public readonly ModeDegree ModeDegree => ModeDegree.Second;
}

#endregion  Blues Modes


#region WholeTone Modes

public readonly struct WholeTone : IMode
{
    public readonly string Name => nameof(WholeTone);
    public readonly IScale Parent => new Major();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

#endregion WholeTone Modes


#region Jazz Modes

public readonly struct JazzMinor : IMode
{
    public readonly string Name => nameof(JazzMinor);
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

public readonly struct PhrygianS6 : IMode
{
    public readonly string Name => "Phrygian ♮6";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Second;
}

public readonly struct LydianS5 : IMode
{
    public readonly string Name => "Lydian ♯5";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Third;
}

public readonly struct LydianDom : IMode
{
    public readonly string Name => nameof(LydianDom);
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Fourth;
}

public readonly struct Mixolydianb6 : IMode
{
    public readonly string Name => "Mixolydian ♭6";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Fifth;
}

public readonly struct LocrianS9 : IMode
{
    public readonly string Name => "Locrian ♮9";
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Sixth;
}

public readonly struct Altered : IMode
{
    public readonly string Name => nameof(Altered);
    public readonly IScale Parent => new Scales.JazzMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Seventh;
}

#endregion Jazz Modes


#region Harmonic Minor Modes

public readonly struct HarmonicMinor : IMode
{
    public readonly string Name => nameof(HarmonicMinor);
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

public readonly struct LocrianS6 : IMode
{
    public readonly string Name => "Locrian ♮6";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Second;
}

public readonly struct IonianS5 : IMode
{
    public readonly string Name => "Ionian +5";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Third;
}

public readonly struct DorianS11 : IMode
{
    public readonly string Name => "Dorian #11";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Fourth;
}

public readonly struct PhrygianDominant : IMode
{
    public readonly string Name => nameof(PhrygianDominant);
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Fifth;
}

public readonly struct LydianS2 : IMode
{
    public readonly string Name => "Lydian #2";
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Sixth;
}

public readonly struct SuperLocrian : IMode
{
    public readonly string Name => nameof(SuperLocrian);
    public readonly IScale Parent => new Scales.HarmonicMinor();
    public readonly ModeDegree ModeDegree => ModeDegree.Seventh;
}

#endregion Harmonic Minor Modes


#region Diminished6th Modes

public readonly struct SixthDiminished : IMode
{
    public readonly string Name => nameof(SixthDiminished);
    public readonly IScale Parent => new Scales.SixthDiminished();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

public readonly struct SixthDiminishedII : IMode
{
    public readonly string Name => nameof(SixthDiminished);
    public readonly IScale Parent => new Scales.SixthDiminished();
    public readonly ModeDegree ModeDegree => ModeDegree.Second;
}

#endregion Diminished6th Modes


#region  Chromatic Modes

public readonly struct Chromatic : IMode
{
    public readonly string Name => nameof(Chromatic);
    public readonly IScale Parent => new Scales.Chromatic();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

#endregion  Chromatic Modes

#region Diminished Modes

public readonly struct WholeHalf : IMode
{
    public readonly string Name => nameof(WholeHalf);
    public readonly IScale Parent => new Scales.Diminished();
    public readonly ModeDegree ModeDegree => ModeDegree.Prime;
}

public readonly struct HalfWhole : IMode
{
    public readonly string Name => nameof(HalfWhole);
    public readonly IScale Parent => new Scales.Diminished();
    public readonly ModeDegree ModeDegree => ModeDegree.Second;
}

#endregion Diminished Modes