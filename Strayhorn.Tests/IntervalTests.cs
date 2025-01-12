using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicTheory.Intervals;
using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory;

namespace MusicTheoryTests;

[TestClass]
public sealed class IntervalTests
{
    [TestMethod]
    public void GetStepAboveTest()
    {
        IAccidental[] accidentals = [new Flat(), new Natural(), new Sharp()];
        IStep[] steps = [new H(), new W()];
        foreach (ILetter letter in ILetter.GetAll())
        {
            foreach (IAccidental accidental in accidentals)
            {
                var pitchClass = IPitchClass.Get(letter, accidental);
                foreach (IStep step in steps)
                {
                    var nextPitchClass = IPitchClass.GetPitchClassAbove(pitchClass, step);
                    Assert.IsTrue(nextPitchClass.Chromatic.Value - pitchClass.Chromatic.Value
                        + (pitchClass.Chromatic.Value > nextPitchClass.Chromatic.Value ? Chromatic.Gamut : 0)
                     == step.Chromatic.Value);
                }
            }
        }
    }

    [TestMethod]
    public void GetLetterAboveTest()
    {
        // IInterval[] intervals = IInterval.GetAll().ToArray();
        foreach (ILetter letter in ILetter.GetAll())
        {
            foreach (IInterval interval in IInterval.GetAll())
            {
                var nextLetter = ILetter.GetLetterAbove(letter, interval);
                Assert.IsTrue(nextLetter.Diatonic.Value ==
                ((letter.Diatonic.Value - 2 + interval.Quantity.ChordTone.Value) % Diatonic.Gamut) + 1);
            }
        }
    }

    [TestMethod]
    public void StepAsIntervalTest()
    {
        var Steps = IStep.GetAll();

        foreach (IStep step in Steps)
        {
            Assert.IsTrue(IStep.AsInterval(step).Chromatic.Equals(step.Chromatic));
        }
    }

    [TestMethod]
    public void AdjacentLettersToStepTest()
    {
        var Letters = ILetter.GetAll();

        foreach (ILetter letter in Letters)
        {
            ILetter nextLetter = ILetter.GetNextLetter(letter);
            var step = IStep.GetStep(letter, nextLetter);
            Assert.IsTrue((letter is MusicTheory.Letters.B or MusicTheory.Letters.E && step is H) || step is W);
        }
    }

    [TestMethod]
    public void QuantityInvertTest()
    {
        foreach (IQuantity quantity in IQuantity.GetAll())
        {
            IQuantity inversion = IQuantity.Invert(quantity);
            IQuantity original = IQuantity.Invert(inversion);

            Assert.IsTrue(original.Equals(quantity));
            Assert.IsTrue(
                quantity.ScaleDegree.Value + inversion.ScaleDegree.Value +
                (original is Octave or Unison ? Diatonic.Gamut : 0)
                 == Diatonic.InversionSum
                );
        }
    }

    [TestMethod]
    public void QualityInvertTest()
    {
        var Qualities = IQuality.GetAll();

        foreach (IQuality Quality in Qualities)
        {
            IQuality inversion = IQuality.Invert(Quality);
            IQuality original = IQuality.Invert(inversion);

            Assert.IsTrue(original.Equals(Quality));
        }
    }

    [TestMethod]
    public void IntervalInvertTest()
    {
        var Intervals = IInterval.GetAll();

        foreach (IInterval interval in Intervals)
        {
            IInterval inversion = IInterval.Invert(interval);
            IInterval original = IInterval.Invert(inversion);

            Assert.IsTrue(original.Equals(interval));
            Assert.IsTrue(
                interval.Chromatic.Value + inversion.Chromatic.Value +
                (original.Quantity is Unison or Octave ? Chromatic.Gamut : 0)
             == Chromatic.Gamut);
        }
    }

}

