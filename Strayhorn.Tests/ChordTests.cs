using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicTheory.Chords;

namespace MusicTheoryTests;

[TestClass]
public sealed class ChordTests
{
    [TestMethod]
    public void TriadInvertTest()
    {
        var Triads = IChord.Triads();

        foreach (IChord triad in Triads)
        {
            var first = IChord.Invert(triad, ChordInversion.First);
            Assert.IsTrue(triad.ChordTones[1].Equals(first[0]));

            var second = IChord.Invert(triad, ChordInversion.Second);
            Assert.IsTrue(triad.ChordTones[2].Equals(second[0]));

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => IChord.Invert(triad, ChordInversion.Third));
        }
    }

    // [TestMethod]
    // public void SeventhChordInvertTest()
    // {
    //     var Sevenths = IChord.Sevenths();

    //     foreach (Chord seventh in Sevenths)
    //     {
    //         var root = Chord.Invert(seventh, Chord.Inversion.Root);
    //         Assert.IsTrue(seventh.ChordTones[0] == root[0]);

    //         var first = Chord.Invert(seventh, Chord.Inversion.First);
    //         Assert.IsTrue(seventh.ChordTones[1] == first[0]);

    //         var second = Chord.Invert(seventh, Chord.Inversion.Second);
    //         Assert.IsTrue(seventh.ChordTones[2] == second[0]);

    //         var third = Chord.Invert(seventh, Chord.Inversion.Third);
    //         Assert.IsTrue(seventh.ChordTones[3] == third[0]);
    //     }
    // }
}

