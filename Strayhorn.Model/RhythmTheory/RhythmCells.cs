namespace MusicTheory.Rhythms;


//There are - or should be - a finite amount of rhythmic shapes used in sheet music.
//There are only eight 4-count shapes, the most common shapes used.
//Three count shapes are used for compound meter and triplet injection. 
//Save for TL - that is nonsensical for triplets since it just equals a 4 count long shape.
//DL and DSS shapes overlap entirely with L and LL, but still good to abstract separately for arithmetic purposes.


public interface IRhythmCell
{
    public int[] Shape { get; protected set; }
    public bool TiesTo { get; protected set; }
    public bool TiedFrom { get; protected set; }
    public bool Rest { get; protected set; }
    public MetricLevel MetricLevel { get; protected set; }

    public IRhythmCell SetMetricLevel(MetricLevel ml) { MetricLevel = ml; return this; }
    /// <summary>Collection of all 14 rhythmic shapes</summary>
    public static IEnumerable<IRhythmCell> GetAll() =>
        [new DL(), new DSS(),
         new TL(), new TLS(), new TSL(), new TSSS(),
         new L(), new LL(), new SSSS(),
         new SSL(), new LSS(), new SLS(),
         new LS(), new SL()];

    /// <summary>Collection of 11 rhythmic shapes from quadruple time with triplets</summary>
    public static IEnumerable<IRhythmCell> Get11() =>
        [ new TLS(), new TSL(), new TSSS(),
         new L(), new LL(), new SSSS(),
         new SSL(), new LSS(), new SLS(),
         new LS(), new SL()];

    /// <summary>Collection of both 2 count figures</summary>
    public static IEnumerable<IRhythmCell> Get2Counts() =>
        [new DL(), new DSS()];

    /// <summary>Collection of all four 3 count figures (includes TL shape)  </summary>
    public static IEnumerable<IRhythmCell> Get3Counts() =>
        [new TL(), new TLS(), new TSL(), new TSSS()];

    /// <summary>Collection of three Triplet figures (No TL shape in triplets)  </summary>
    public static IEnumerable<IRhythmCell> GetTriplets() =>
        [new TLS(), new TSL(), new TSSS()];

    /// <summary>Collection of all eight 4 count figures</summary>
    public static IEnumerable<IRhythmCell> Get4Counts() =>
        [new L(), new LL(), new SSSS(),
         new SSL(), new LSS(), new SLS(),
         new LS(), new SL()];
}

public abstract class RhythmCell : IRhythmCell
{
    public RhythmCell(MetricLevel metricLevel, int[] shape, bool rest = false, bool tiesTo = false, bool tiedFrom = false)
    {
        if (rest && tiedFrom) throw new Exception("Cannot tie to a rest!");

        MetricLevel = metricLevel;
        TiesTo = tiesTo;
        TiedFrom = tiedFrom;
        Rest = rest;
        Shape = shape;
    }

    public int[] Shape { get; set; } = [];
    public bool TiesTo { get; set; } = false;
    public bool TiedFrom { get; set; } = false;
    public bool Rest { get; set; } = false;
    public MetricLevel MetricLevel { get; set; } = MetricLevel.Beat;

}

public class DSS(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [1, 1], rest, tiesTo, tiedFrom)
{ }

public class DL(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [2], rest, tiesTo, tiedFrom)
{ }

public class TL(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [3], rest, tiesTo, tiedFrom)
{ }

public class TLS(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [2, 1], rest, tiesTo, tiedFrom)
{ }

public class TSL(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [1, 2], rest, tiesTo, tiedFrom)
{ }

public class TSSS(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [1, 1, 1], rest, tiesTo, tiedFrom)
{ }

public class L(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [4], rest, tiesTo, tiedFrom)
{ }

public class LL(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [2, 2], rest, tiesTo, tiedFrom)
{ }

public class SSSS(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [1, 1, 1, 1], rest, tiesTo, tiedFrom)
{ }
public class LSS(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [2, 1, 1], rest, tiesTo, tiedFrom)
{ }

public class SSL(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [1, 1, 2], rest, tiesTo, tiedFrom)
{ }

public class SLS(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [1, 2, 1], rest, tiesTo, tiedFrom)
{ }

public class SL(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [1, 3], rest, tiesTo, tiedFrom)
{ }

public class LS(
    MetricLevel metricLevel = MetricLevel.Beat,
    bool rest = false, bool tiesTo = false, bool tiedFrom = false) :
    RhythmCell(metricLevel, [3, 1], rest, tiesTo, tiedFrom)
{ }