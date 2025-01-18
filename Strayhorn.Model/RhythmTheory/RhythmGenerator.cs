using MusicTheory.Utilities;

namespace MusicTheory.Rhythms;
public static class RhythmGenerator
{
    /// <summary>
    /// Metric levels must be < 1 (beat level or smaller).
    /// </summary>
    public static IRhythmCell[] GenerateRhythmCells(this IMeter meter, MetricLevel maxLevel, MetricLevel minLevel)
    {
        Random rand = new();
        return meter switch
        {
            SimpleDuple => (minLevel, maxLevel) switch//1d, 1q, 2q
            {
                (MetricLevel.D1, MetricLevel.Beat) => rand.Next(0, 2) == 0 ?
                    [IRhythmCell.Get2Counts().GetRandom()] :
                    [IRhythmCell.Get4Counts().GetRandom().SetMetricLevel(MetricLevel.D1)],
                (MetricLevel.D1, MetricLevel.D1) =>
                    [IRhythmCell.Get4Counts().GetRandom().SetMetricLevel(MetricLevel.D1)],
                (MetricLevel.D2, MetricLevel.D1) => rand.Next(0, 2) == 0 ?
                    [IRhythmCell.Get4Counts().GetRandom().SetMetricLevel(MetricLevel.D1)] :
                    GetCells(counts: 2, cellsPerCount: 1, cellType: 4, MetricLevel.D2),
                (_, MetricLevel.D2) =>
                    GetCells(counts: 2, cellsPerCount: 1, cellType: 4, MetricLevel.D2),
                _ => [IRhythmCell.Get2Counts().GetRandom()],
            },

            SimpleTriple => (minLevel, maxLevel) switch//1t,3d,3q
            {
                (MetricLevel.D1, MetricLevel.Beat) => rand.Next(0, 2) == 0 ?
                    [IRhythmCell.Get3Counts().GetRandom()] :
                    GetCells(counts: 3, cellsPerCount: 1, cellType: 2, MetricLevel.D1),
                (MetricLevel.D1, MetricLevel.D1) =>
                    GetCells(counts: 3, cellsPerCount: 1, cellType: 2, MetricLevel.D1),
                (MetricLevel.D2, MetricLevel.D1) =>
                    GetMixedCells(counts: 3, d1CellsPerCount: 1, d1CellType: 2, d2CellsPerCount: 1, d2CellType: 4),
                (_, MetricLevel.D2) =>
                    GetCells(counts: 3, cellsPerCount: 1, cellType: 4, MetricLevel.D2),
                _ => [IRhythmCell.Get3Counts().GetRandom()],
            },

            SimpleQuadruple => (minLevel, maxLevel) switch//1q, 2q, 4q
            {
                (MetricLevel.D1, MetricLevel.Beat) => rand.Next(0, 2) == 0 ?
                    [IRhythmCell.Get4Counts().GetRandom()] :
                    GetCells(counts: 2, cellsPerCount: 1, cellType: 4, MetricLevel.D1),
                (MetricLevel.D1, MetricLevel.D1) =>
                    GetCells(counts: 2, cellsPerCount: 1, cellType: 4, MetricLevel.D1),
                (MetricLevel.D2, MetricLevel.D1) =>
                    GetMixedCells(counts: 4, d1CellsPerCount: 1, d1CellType: 4, d2CellsPerCount: 2, d2CellType: 4),
                (_, MetricLevel.D2) =>
                    GetCells(counts: 4, cellsPerCount: 1, cellType: 4, MetricLevel.D2),
                _ => [IRhythmCell.Get4Counts().GetRandom()],
            },

            CompoundDuple => (minLevel, maxLevel) switch//1d, 2t, 6d
            {
                (MetricLevel.D1, MetricLevel.Beat) => rand.Next(0, 2) == 0 ?
                    [IRhythmCell.Get2Counts().GetRandom()] :
                    GetCells(counts: 2, cellsPerCount: 1, cellType: 3, MetricLevel.D1),
                (MetricLevel.D1, MetricLevel.D1) =>
                    GetCells(counts: 2, cellsPerCount: 1, cellType: 3, MetricLevel.D1),
                (MetricLevel.D2, MetricLevel.D1) =>
                    GetMixedCells(counts: 2, d1CellsPerCount: 1, d1CellType: 3, d2CellsPerCount: 3, d2CellType: 2),
                (_, MetricLevel.D2) =>
                    GetCells(counts: 6, cellsPerCount: 1, cellType: 2, MetricLevel.D2),
                _ => [IRhythmCell.Get2Counts().GetRandom()],
            },

            CompoundTriple => (minLevel, maxLevel) switch//1d, 3t, 9d
            {
                (MetricLevel.D1, MetricLevel.Beat) => rand.Next(0, 2) == 0 ?
                    [IRhythmCell.Get3Counts().GetRandom()] :
                    GetCells(counts: 3, cellsPerCount: 1, cellType: 3, MetricLevel.D1),
                (MetricLevel.D1, MetricLevel.D1) =>
                    GetCells(counts: 3, cellsPerCount: 1, cellType: 3, MetricLevel.D1),
                (MetricLevel.D2, MetricLevel.D1) =>
                    GetMixedCells(counts: 3, d1CellsPerCount: 1, d1CellType: 3, d2CellsPerCount: 3, d2CellType: 2),
                (_, MetricLevel.D2) =>
                    GetCells(counts: 9, cellsPerCount: 1, cellType: 2, MetricLevel.D2),
                _ => [IRhythmCell.Get3Counts().GetRandom()],

            },

            CompoundQuadruple => (minLevel, maxLevel) switch//1d, 4t, 12d
            {
                (MetricLevel.D1, MetricLevel.Beat) => rand.Next(0, 2) == 0 ?
                    [IRhythmCell.Get4Counts().GetRandom()] :
                    GetCells(counts: 4, cellsPerCount: 1, cellType: 3, MetricLevel.D1),
                (MetricLevel.D1, MetricLevel.D1) =>
                    GetCells(counts: 4, cellsPerCount: 1, cellType: 3, MetricLevel.D1),
                (MetricLevel.D2, MetricLevel.D1) =>
                    GetMixedCells(counts: 4, d1CellsPerCount: 4, d1CellType: 3, d2CellsPerCount: 12, d2CellType: 12),
                (_, MetricLevel.D2) =>
                    GetCells(counts: 12, cellsPerCount: 1, cellType: 2, MetricLevel.D2),
                _ => [IRhythmCell.Get3Counts().GetRandom()],
            },

            _ => throw new Exception("Generation failed"),
        };

        IRhythmCell[] GetMixedCells(int counts, int d1CellsPerCount, int d1CellType, int d2CellsPerCount, int d2CellType)
        {
            List<IRhythmCell> cells = [];
            for (int i = 0; i < counts; i++)
            {
                if (rand.Next(0, 2) == 0) for (int di = 0; di < d1CellsPerCount; di++)
                        cells.Add(d1CellType switch
                        {
                            2 => IRhythmCell.Get2Counts().GetRandom().SetMetricLevel(MetricLevel.D1),
                            3 => IRhythmCell.Get3Counts().GetRandom().SetMetricLevel(MetricLevel.D1),
                            _ => IRhythmCell.Get4Counts().GetRandom().SetMetricLevel(MetricLevel.D1),
                        });
                else for (int dii = 0; dii < d2CellsPerCount; dii++)
                        cells.Add(d2CellType switch
                        {
                            2 => IRhythmCell.Get2Counts().GetRandom().SetMetricLevel(MetricLevel.D2),
                            3 => IRhythmCell.Get3Counts().GetRandom().SetMetricLevel(MetricLevel.D2),
                            _ => IRhythmCell.Get4Counts().GetRandom().SetMetricLevel(MetricLevel.D2),
                        });
            }
            return [.. cells];
        }

        IRhythmCell[] GetCells(int counts, int cellsPerCount, int cellType, MetricLevel ml)
        {
            List<IRhythmCell> cells = [];
            for (int i = 0; i < counts; i++)
                for (int ii = 0; ii < cellsPerCount; ii++)
                    cells.Add(cellType switch
                    {
                        2 => IRhythmCell.Get2Counts().GetRandom().SetMetricLevel(ml),
                        3 => IRhythmCell.Get3Counts().GetRandom().SetMetricLevel(ml),
                        _ => IRhythmCell.Get4Counts().GetRandom().SetMetricLevel(ml),
                    });
            return [.. cells];
        }
    }
}
