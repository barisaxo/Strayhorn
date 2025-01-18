
namespace MusicTheory.Rhythms;

/// <summary>
/// Rhythmic Note Designations. 
/// </summary>
public interface INote : IMusicalElement
{
    /// <summary> Duration modifiers, Triplet = 2/3, augmentation dot = 3/2 </summary>
    public DurationModifier Modifier { get; }

    /// <summary>Duration = (int)MetricLevel * Math.Pow(2, BeatLevel) </summary>
    public MetricLevel MetricLevel { get; }

    // /// <summary>BPM, Beats Per Minute</summary> 
    // public readonly double Tempo;

    /// <summary>Actual real-time length of note (in seconds)</summary>
    public double Duration { get; }

    public IDurationSymbol DurationSymbol { get; }
}

public class Note : INote
{
    public DurationModifier Modifier { get; }

    public MetricLevel MetricLevel { get; }

    public double Duration { get; }

    public IDurationSymbol DurationSymbol { get; }
    public string Name =>
          (Modifier is DurationModifier.Triplet ? "Triplet " :
           Modifier is DurationModifier.Dot ? "Dotted " : "") +
           DurationSymbol.Name + " Note";

    public Note(MetricLevel metricLevel, double tempo, ITimeSignature timeSignature, DurationModifier modifier = DurationModifier.None)
    {
        MetricLevel = metricLevel;
        Modifier = modifier;

        float augment = Modifier is DurationModifier.Dot ? 1.5f : 1f;
        float triplet = Modifier is DurationModifier.Triplet ? (2f / 3f) : 1f;

        float augmentOrCompound = (MetricLevel == MetricLevel.Beat && timeSignature.Meter.Divisor is BeatDivisor.Compound) || Modifier is DurationModifier.Dot ? 1.5f : 1f;
        double compoundMetric = Math.Pow(2, (int)MetricLevel + timeSignature.Meter.Divisor is BeatDivisor.Compound ? 1 : 0);

        Duration = 60 * Math.Pow(2, (int)MetricLevel) * triplet * augment / tempo;

        DurationSymbol = IDurationSymbol.GetAll().Single(d =>
            d.Value == (int)timeSignature.SubCount * compoundMetric * augmentOrCompound * triplet);
    }
}

