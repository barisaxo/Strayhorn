namespace Strayhorn.Menus;
using Strayhorn.Systems.State;

public interface IMenuItem
{
    public string Desc { get; }
    public IState? GetState();
}

public class MenuItem(string desc, Func<IState?> getState) : IMenuItem, IEquatable<MenuItem>
{
    public string Desc { get; } = desc;
    public IState? GetState() => getState();

    public bool Equals(MenuItem? other) => other is not null && GetHashCode() == other.GetHashCode();
    public override bool Equals(object? obj) => obj is MenuItem other && Equals(other);
    public static bool operator ==(MenuItem left, MenuItem right) => Equals(left, right);
    public static bool operator !=(MenuItem left, MenuItem right) => !Equals(left, right);
    public override int GetHashCode() => Desc.GetHashCode();
}
