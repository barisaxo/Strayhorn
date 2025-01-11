using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicTheory.Chords;

namespace MusicTheoryTests;

[TestClass]
public sealed class NoteTests
{
    [TestMethod]
    public void PitchIDTest()
    {


        // var Triads = IChord.Triads();

        // foreach (IChord triad in Triads)
        // {
        //     var first = IChord.Invert(triad, ChordInversion.First);
        //     Assert.IsTrue(triad.ChordTones[1].Equals(first[0]));

        //     var second = IChord.Invert(triad, ChordInversion.Second);
        //     Assert.IsTrue(triad.ChordTones[2].Equals(second[0]));

        //     Assert.ThrowsException<ArgumentOutOfRangeException>(
        //         () => IChord.Invert(triad, ChordInversion.Third));
        // }
    }
}