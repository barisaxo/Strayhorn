using MusicTheory.Intervals;
using MusicTheory.Modes;
namespace MusicTheory.Scales;

/// <summary> https://barisaxo.github.io/pages/arithmetic/scales.html  </summary>
public interface IScale : IMusicalElement
{
    public IStep[] Steps { get; }
    public IMode[] Modes { get; }
    public IInterval[] ScaleDegrees { get; }
    public string[] Drawing { get; }

    public static IEnumerable<IScale> GetAll() =>
        [new Major(), new JazzMinor(), new HarmonicMinor(), new WholeTone(), new Diminished(),
         new SixthDiminished(), new Chromatic(), new Pentatonic(), new  Blues()];
}

public readonly struct Major : IScale
{
    public readonly string Name => nameof(Major);
    public readonly IMode[] Modes =>
        [new Ionian(), new Dorian(), new Phrygian(), new Lydian(),
         new Mixolydian(), new Aeolian(), new Locrian()];

    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new M3(), new P4(), new P5(), new M6(), new M7()];
    public readonly IStep[] Steps =>
        [new W(), new W(), new H(), new W(), new W(), new W(), new H()];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct Minor : IScale
{
    public readonly string Name => nameof(Major);
    public readonly IMode[] Modes =>
        [new Aeolian(), new Locrian(),new Ionian(), new Dorian(), new Phrygian(), new Lydian(),
         new Mixolydian(),];

    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new mi3(), new P4(), new P5(), new mi6(), new mi7()];
    public readonly IStep[] Steps =>
        [new W(), new H(), new W(), new W(), new H(), new W(), new W(),];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct JazzMinor : IScale
{
    public readonly string Name => nameof(JazzMinor);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new mi3(), new P4(), new P5(), new M6(), new M7()];
    public readonly IStep[] Steps =>
        [new W(), new H(), new W(), new W(), new W(), new W(), new H()];
    public readonly IMode[] Modes =>
        [new Modes.JazzMinor(), new PhrygianS6(), new LydianS5(), new LydianDom(),
         new Mixolydianb6(), new LocrianS9(), new Altered()];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct HarmonicMinor : IScale
{
    public readonly string Name => nameof(HarmonicMinor);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new mi3(), new P4(), new P5(), new mi6(), new M7()];
    public readonly IStep[] Steps =>
        [new W(), new H(), new W(), new W(), new H(), new S(), new H()];
    public readonly IMode[] Modes =>
        [new Modes.HarmonicMinor(), new LocrianS6(), new IonianS5(), new DorianS11(),
         new PhrygianDominant(), new LydianDom(), new SuperLocrian()];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct WholeTone : IScale
{
    public readonly string Name => nameof(WholeTone);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new M3(), new A4(), new A5(), new mi7()];
    public readonly IStep[] Steps =>
        [new W(), new W(), new W(), new W(), new W(), new W()];
    public readonly IMode[] Modes =>
        [new Modes.WholeTone()];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct Diminished : IScale
{
    public readonly string Name => nameof(Diminished);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new mi3(), new P4(), new d5(), new mi6(), new d7(), new M7()];
    public readonly IStep[] Steps =>
        [new W(), new H(), new W(), new H(), new W(), new H(), new W(), new H()];
    public readonly IMode[] Modes =>
        [new WholeHalf(), new HalfWhole()];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct SixthDiminished : IScale
{
    public readonly string Name => nameof(SixthDiminished);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new M3(), new P4(), new P5(), new mi6(), new M6(), new M7()];
    public readonly IStep[] Steps =>
        [new W(), new W(), new H(), new W(), new H(), new H(), new W(), new H()];
    public readonly IMode[] Modes =>
        [new Modes.SixthDiminished(), new Modes.SixthDiminished()];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct Chromatic : IScale
{
    public readonly string Name => nameof(Chromatic);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new mi2(), new M2(), new mi3(), new M3(), new P4(),
        new d5(), new P5(), new mi6(), new M6(), new mi7(), new M7()];
    public readonly IStep[] Steps =>
      [new H(), new H(), new H(), new H(), new H(), new H(),
       new H(), new H(), new H(), new H(), new H(), new H()];
    public readonly IMode[] Modes =>
     [new Modes.Chromatic()];
    public readonly string[] Drawing =>
       [@"C Db E Eb E F Gb G Ab A Bb B C",
        @"1 b2 2 b3 3 4 b5 5 b6 6 b7 7 1",
        @" ‾  ‾ ‾  ‾ ‾ ‾  ‾ ‾  ‾ ‾  ‾ ‾ ",
        @" H  H H  H H H  H H  H H  H H ",];
}

public readonly struct Pentatonic : IScale
{
    public readonly string Name => nameof(Pentatonic);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new M3(), new P5(), new M6(),];
    public readonly IStep[] Steps =>
       [new W(), new W(), new S(), new W(), new S()];
    public readonly IMode[] Modes =>
        [new Modes.Pentatonic(), new PentatonicII(), new PentatonicIII(),
         new PentatonicIV(), new PentatonicMinor()];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct MinorPentatonic : IScale
{
    public readonly string Name => nameof(Pentatonic);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new mi3(), new P4(), new P5(), new mi7(),];
    public readonly IStep[] Steps =>
       [new S(), new W(), new W(), new S(), new W(),];
    public readonly IMode[] Modes =>
        [new PentatonicMinor(), new Modes.Pentatonic(), new PentatonicII(), new PentatonicIII(),
         new PentatonicIV(), ];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct Blues : IScale
{
    public readonly string Name => nameof(Blues);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new mi3(), new P4(), new d5(), new P5(), new mi7()];
    public readonly IStep[] Steps =>
        [new S(), new W(), new H(), new H(), new S(), new W()];
    public readonly IMode[] Modes =>
        [new Modes.Blues(), new BluesMajor()];

    public string[] Drawing => throw new NotImplementedException();
}

public readonly struct MajorBlues : IScale
{
    public readonly string Name => nameof(Blues);
    public readonly IInterval[] ScaleDegrees =>
        [new P1(), new M2(), new mi3(), new M3(), new P5(), new M6()];
    public readonly IStep[] Steps =>
        [new W(), new H(), new H(), new S(), new W(), new S(),];
    public readonly IMode[] Modes =>
        [new Modes.Blues(), new BluesMajor()];

    public string[] Drawing => throw new NotImplementedException();
}
