namespace Strayhorn.Menus;

public interface IMenu
{
    public IMenuItem[] MenuItems { get; }
    public IMenuItem Selection { get; set; }

    public void ScrollUp()
    {
        int length = MenuItems.Length;
        for (int i = 0; i < length; i++)
        {
            if (Selection == MenuItems[i])
            {
                Selection = MenuItems[((i + 1) == length) ? length - 1 : i + 1];
                break;
            }
        }
    }

    public void ScrollDown()
    {
        int length = MenuItems.Length;
        for (int i = 0; i < length; i++)
        {
            if (Selection == MenuItems[i])
            {
                Selection = MenuItems[((i - 1) < 0) ? 0 : i - 1];
                break;
            }
        }
    }

}

