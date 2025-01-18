namespace MusicTheory.Rhythms;

public class Measure(ITimeSignature timeSignature, IRhythmCell[] rhythmCells)
{
    public readonly ITimeSignature TimeSignature = timeSignature;
    public readonly IRhythmCell[] RhythmCells = rhythmCells;
}

