namespace MusicTheory.Utilities;

public static class Utils
{
    public static T GetRandom<T>(this IEnumerable<T> elements)
    {
        if (elements == null || !elements.Any())
        {
            throw new ArgumentException("The collection cannot be null or empty", nameof(elements));
        }

        return elements.ElementAt(new Random().Next(0, elements.Count()));
    }
}