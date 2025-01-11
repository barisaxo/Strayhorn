using Strayhorn.Menus;
using Strayhorn.Utility;
using Strayhorn.Systems.State;
using static System.Console;
using System.Threading;
using System.Diagnostics;
using MusicTheory;
using MusicTheory.Notes;

namespace Strayhorn;

public static class Logos
{
    public static readonly string[] Strayhorn1 = [
        @"╔───────────────────────────────────────────────────────────────╗",
        @"│      ____ _____ ____     _ __   ___   _  ___  ____  _   _     │",
        @"│     / ___|_   _|  _ \   / \\ \ / | | | |/ _ \|  _ \| \ | |    │",
        @"│     \___ \ | | | |_) | / ∆ \\ V /| └─┘ | | | | |_) |  \| |    │",
        @"│      ___) || | |  _ < / ___ \| | | ┌─┐ | |_| |  _ <| |\  |    │",
        @"│     |____/ |_| |_| \_/_/   \_|_| |_| |_|\___/|_| \_|_| \_|    │",
        @"│                                                               │",
        @"╚───────────────────────────────────────────────────────────────╝",];

    public static readonly string[] Strayhorn2 = [
        @"╔─────────────────────────────────────────────────────────────────────────────╗",
        @"│    █████████████████████╗ █████╗██╗   ████╗  ██╗██████╗██████╗███╗   ██╗    │",
        @"│    ██╔════╚══██╔══██╔══████╔══██╚██╗ ██╔██║  ████╔═══████╔══██████╗  ██║    │",
        @"│    ███████╗  ██║  ██████╔███████║╚████╔╝█████████║   ████████╔██╔██╗ ██║    │",
        @"│    ╚════██║  ██║  ██╔══████╔══██║ ╚██╔╝ ██╔══████║   ████╔══████║╚██╗██║    │",
        @"│    ███████║  ██║  ██║  ████║  ██║  ██║  ██║  ██╚██████╔██║  ████║ ╚████║    │",
        @"│    ╚══════╝  ╚═╝  ╚═╝  ╚═╚═╝  ╚═╝  ╚═╝  ╚═╝  ╚═╝╚═════╝╚═╝  ╚═╚═╝  ╚═══╝    │",
        @"╚─────────────────────────────────────────────────────────────────────────────╝",];

    public static readonly string[] Strayhorn3 = [
        @"╔─────────────────────────────────────────────╗",
        @"│                                             │",
        @"│      __ ___ _               _   _           │",
        @"│     (_   | |_)  /\ \_/ |_| / \ |_) |\ |     │",
        @"│     __)  | | \ /--\ |  | | \_/ | \ | \|     │",
        @"│                                             │",
        @"│                                             │",
        @"╚─────────────────────────────────────────────╝",];

    public static readonly string[] Strayhorn4 = [
        @"╔─────────────────────────────────────────────────────────────────────╗",
        @"│    .---. ,--,--.-,--.     ,.   .  . ,-_/,. ,,--. .-,--. ,-,-.       │",
        @"│    \___  `- |   `|__/    / |   |  | ' |_|/ |`, |  `|__/ ` | |       │",
        @"│        \  , |   )| \    /~~|-. |  |  /| |  |   |  )| \    | |-.     │",
        @"│    `---'  `-'   `'  ` ,'   `-' `--|  `' `' `---'  `'  `  ,' `-'     │",
        @"│                                .- |                                 │",
        @"│                                `--'                                 │",
        @"╚─────────────────────────────────────────────────────────────────────╝",];

    public static readonly string[] Strayhorn5 = [
        @"╔───────────────────────────────────────────────────────╗",
        @"│     .-..---..--.     .  .   ..   . .--. .--. .   .    │",
        @"│    (   ) |  |   )   / \  \ / |   |:    :|   )|\  |    │",
        @"│     `-.  |  |--'   /___\  :  |---||    ||--' | \ |    │",
        @"│    (   ) |  |  \  /     \ |  |   |:    ;|  \ |  \|    │",
        @"│     `-'  '  '   `'       `'  '   ' `--' '   `'   '    │",
        @"╚───────────────────────────────────────────────────────╝",];

    public static readonly string[] Strayhorn6 = [
        @"╔───────────────────────────────────────────────────────────────╗",
        @"│                                                               │",
        @"│     __  _____  ___    __    _     _     ___   ___   _         │",
        @"│    ( (`  | |  | |_)  / /\  \ \_/ | |_| / / \ | |_) | |\ |     │",
        @"│    _)_)  |_|  |_| \ /_/--\  |_|  |_| | \_\_/ |_| \ |_| \|     │",
        @"│                                                               │",
        @"│                                                               │",
        @"╚───────────────────────────────────────────────────────────────╝",];

    public static readonly string[] Strayhorn7 = [
        @"╔─────────────────────────────────────────────────────────────────────────────────╗",
        @"│       ___    _____    ___     ___   __   __  _   _    ___     ___    _  _       │",
        @"│      / __|  |_   _|  | _ \   /   \  \ \ / / | | | |  / _ \   | _ \  | \| |      │",
        @"│      \__ \    | |    |   /   | ∆ |   \ V /  | ┌─┐ | | (_) |  |   /  | .` |      │",
        @"│      |___/   _|_|_   |_|_\   |_|_|   _|_|_  |_| |_|  \___/   |_|_\  |_|\_|      │",
        @"│    _|'''''|_|'''''|_|'''''|_|'''''|_|'''''|_|'''''|_|'''''|_|'''''|_|'''''|     │",
        @"│    '`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-'     │",
        @"╚─────────────────────────────────────────────────────────────────────────────────╝",];

    static readonly string[] OutroLogo = [
        "┌┬──────────────────────────┬─────────┬───────────────────────────┬┐",
        "││                          │STRAYHORN│                           ││",
        "│├──────────────────────────┴─────────┴───────────────────────────┤│",
        "││                                                                ││",
        "│├────────────────────────────────────────────────────────────────┤│",
        "││                                                                ││",
        "│├────────────────────────────────────────────────────────────────┤│",
        "││ ©2025 Aural Tech Games                       AuralTech.itch.io ││",
        "└┴────────────────────────────────────────────────────────────────┴┘",];

    public static void PrintIntroCredits()
    {
        CursorVisible = false;
        ForegroundColor = RandDarkColor();
        var logo = new Random().Next(0, 7) switch
        {
            0 => Strayhorn1,
            1 => Strayhorn2,
            2 => Strayhorn3,
            3 => Strayhorn4,
            4 => Strayhorn5,
            5 => Strayhorn6,
            6 => Strayhorn7,
            _ => Strayhorn1
        };
        StateMachine.BlockInput = true;
        //sing
        new Thread(PlayIntro).Start();

        //dance
        int[] timers = [225, 225, 225, 300, 375, 300, 375, 250];
        for (int i = timers.Length - 1; i >= 0; i--)
        {
            Clear();
            for (int ii = i; ii < logo.Length; ii++)
            {
                logo[ii].WriteLineCentered();
            };
            Thread.Sleep(timers[i]);
        }

        Clear();
        StateMachine.BlockInput = false;
        foreach (string line in logo) line.WriteLineCentered();
        ResetColor();

        WriteLine();
        Utils.WriteLineCentered("Welcome to Strayhorn, a music theory practice tool.");
        Utils.WriteLineCentered("©2025 AuralTechGames - AuralTech.itch.io");
        Utils.WriteLineCentered("Happy practicing!");

        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("\npress 'CTRL + z' at any time to force quit.");
        ResetColor();

        static void PlayIntro()
        {
            (Pitch[], int, float)[] chelseaBridge =
            [
                ([new Pitch(new Bb(),3)],375,.4f),
                ([new Pitch(new C(),4)], 300,.5f),
                ([new Pitch(new Db(),4)],375,.4f),
                ([new Pitch(new Eb(),4)],300,.5f),
                ([new Pitch(new F(),4)], 225,.45f),
                ([new Pitch(new G(),4)], 225,.45f),
                ([new Pitch(new Ab(),4)],225,.5f), 
                //Bb-∆7
                ([new Pitch(new G(),3), new Pitch(new Bb(),3), new Pitch(new C(),4), new Pitch(new F(),4), new Pitch(new A(),4)], 1500, .4f)
            ];
            AudioGenerator.PlayAudio(chelseaBridge, () => { });
        }
    }


    public static void PrintOutroCredits()
    {
        Clear();
        WriteLine("\nGoodbye!\n\n");
        ForegroundColor = RandDarkColor();
        foreach (string line in OutroLogo) line.WriteLineCentered();
        WriteLine("\n");
        ResetColor();
    }

    public static void PressAnyKeyToContinue()
    {
        BackgroundColor = (ConsoleColor)(-1);
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("\n\n(press any key to continue...)\n");
        ResetColor();
        ReadKey(true);
    }

    public static void ScrollWithUD()
    {
        BackgroundColor = (ConsoleColor)(-1);
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("\n\nuse ↑ ↓ keys to navigate, and press 'enter' to confirm\n");
        ResetColor();
    }

    public static ConsoleColor RandDarkColor()
    {
        Random rand = new();
        return rand.Next(0, 8) switch
        {
            0 => ConsoleColor.DarkBlue,
            1 => ConsoleColor.DarkCyan,
            2 => ConsoleColor.DarkGray,
            3 => ConsoleColor.DarkGreen,
            4 => ConsoleColor.DarkMagenta,
            5 => ConsoleColor.DarkRed,
            6 => ConsoleColor.DarkYellow,
            _ => ConsoleColor.Black
        };
    }
}
