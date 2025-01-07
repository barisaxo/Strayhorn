
using MusicTheory.Intervals;

namespace MusicTheory.Chords;

/// <summary> 
/// https://barisaxo.github.io/pages/chords/voicings.html  \n          
/// https://barisaxo.github.io/pages/chords/tonalities.html
/// </summary>
public interface IChord
{
    public string Name { get; }
    public string ChordSymbol { get; }
    public IInterval[] ChordTones { get; }
    public IInterval[] AvailableTensions { get; }

    public static IInterval[] Invert(IChord chord, ChordInversion inversion)
    {
        if (inversion is ChordInversion.Third && chord is ITriad)
        {
            throw new System.ArgumentOutOfRangeException(chord.Name +
                "... Triads cannot be in 3rd inversion, they don't contain a 7th!");
        }

        var inverted = new IInterval[chord.ChordTones.Length];
        for (int i = 0; i < inverted.Length; i++)
            inverted[i] = chord.ChordTones[(i + (int)inversion) % inverted.Length];

        return inverted;
    }

    public static IEnumerable<ITriad> Triads() => [
        new MajorTriad(), new MinorTriad(), new AugmentedTriad(), new DiminishedTriad(),
        ];

    // public static IEnumerable<Chord> Sixths() => [
    //     Major6, Minor6,
    //     ];

    // public static IEnumerable<Chord> Sevenths() => [
    //     Major7, Minor7, Dominant7, SevenSus, TonicMin7, Minor7b5,
    //     Augmented7, Sevens11, Altered7, Sevenb9Sus, Diminished7,
    //     ];

    // public static IEnumerable<Chord> GetAll() => [
    //     Major, Minor, Augmented, Diminished,
    //     Major6, Minor6,
    //     Major7, Minor7, Dominant7, SevenSus, TonicMin7, Minor7b5,
    //     Augmented7, Sevens11, Altered7, Sevenb9Sus, Diminished7,
    //     ];
}

public enum ChordInversion { First = 1, Second = 2, Third = 3 }
