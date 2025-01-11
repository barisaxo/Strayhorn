using Strayhorn.Systems.Display;

namespace Strayhorn;

public interface ITutorial
{
    public ITutorial? PrevPage();
    public ITutorial? NextPage();
    public IDisplay Display { get; }
}
