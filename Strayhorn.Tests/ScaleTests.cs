using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicTheory.Scales;

namespace MusicTheoryTests;

[TestClass]
public sealed class ScaleTests
{
    [TestMethod]
    public void ScaleStepsAccuracyTest()
    {
        var Scales = IScale.GetAll();

        foreach (IScale scale in Scales)
        {
            int chromaticValue = 0;

            foreach (var step in scale.Steps)
                chromaticValue += step.Chromatic.Value;

            Assert.IsTrue(chromaticValue == MusicTheory.Chromatic.Gamut);
        }
    }

    [TestMethod]
    public void ScaleDegreesAccuracyTest()
    {
        var Scales = IScale.GetAll();

        foreach (IScale scale in Scales)
        {
            int chromaticSum = 0;
            int stepValue = 0;

            foreach (var degree in scale.ScaleDegrees)
            {
                chromaticSum += degree.Chromatic.Value - stepValue;
                stepValue = degree.Chromatic.Value;
            }

            chromaticSum += MusicTheory.Chromatic.Gamut - stepValue;

            Assert.IsTrue(chromaticSum == MusicTheory.Chromatic.Gamut);
        }
    }
}

