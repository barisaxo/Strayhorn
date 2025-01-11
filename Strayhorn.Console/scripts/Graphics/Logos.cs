using Strayhorn.Utility;
using Strayhorn.Systems.State;
using static System.Console;
using MusicTheory.Notes;

namespace Strayhorn;

public static class Logos
{
    public static readonly string[][] StrayhornLogos = [
        [@"╔───────────────────────────────────────────────────────────────╗",
         @"│      ____ _____ ____     _ __   ___   _  ___  ____  _   _     │",
         @"│     / ___|_   _|  _ \   / \\ \ / | | | |/ _ \|  _ \| \ | |    │",
         @"│     \___ \ | | | |_) | / ∆ \\ V /| └─┘ | | | | |_) |  \| |    │",
         @"│      ___) || | |  _ < / ___ \| | | ┌─┐ | |_| |  _ <| |\  |    │",
         @"│     |____/ |_| |_| \_/_/   \_|_| |_| |_|\___/|_| \_|_| \_|    │",
         @"│                                                               │",
         @"╚───────────────────────────────────────────────────────────────╝",],
        [@"╔─────────────────────────────────────────────────────────────────────────────╗",
         @"│    █████████████████████╗ █████╗██╗   ████╗  ██╗██████╗██████╗███╗   ██╗    │",
         @"│    ██╔════╚══██╔══██╔══████╔══██╚██╗ ██╔██║  ████╔═══████╔══██████╗  ██║    │",
         @"│    ███████╗  ██║  ██████╔███████║╚████╔╝█████████║   ████████╔██╔██╗ ██║    │",
         @"│    ╚════██║  ██║  ██╔══████╔══██║ ╚██╔╝ ██╔══████║   ████╔══████║╚██╗██║    │",
         @"│    ███████║  ██║  ██║  ████║  ██║  ██║  ██║  ██╚██████╔██║  ████║ ╚████║    │",
         @"│    ╚══════╝  ╚═╝  ╚═╝  ╚═╚═╝  ╚═╝  ╚═╝  ╚═╝  ╚═╝╚═════╝╚═╝  ╚═╚═╝  ╚═══╝    │",
         @"╚─────────────────────────────────────────────────────────────────────────────╝",],
        [@"╔─────────────────────────────────────────────╗",
         @"│                                             │",
         @"│      __ ___ _               _   _           │",
         @"│     (_   | |_)  /\ \_/ |_| / \ |_) |\ |     │",
         @"│     __)  | | \ /--\ |  | | \_/ | \ | \|     │",
         @"│                                             │",
         @"│                                             │",
         @"╚─────────────────────────────────────────────╝",],
        [@"╔─────────────────────────────────────────────────────────────────────╗",
         @"│    .---. ,--,--.-,--.     ,.   .  . ,-_/,. ,,--. .-,--. ,-,-.       │",
         @"│    \___  `- |   `|__/    / |   |  | ' |_|/ |`, |  `|__/ ` | |       │",
         @"│        \  , |   )| \    /~~|-. |  |  /| |  |   |  )| \    | |-.     │",
         @"│    `---'  `-'   `'  ` ,'   `-' `--|  `' `' `---'  `'  `  ,' `-'     │",
         @"│                                .- |                                 │",
         @"│                                `--'                                 │",
         @"╚─────────────────────────────────────────────────────────────────────╝",],
        [@"╔───────────────────────────────────────────────────────╗",
         @"│     .-..---..--.     .  .   ..   . .--. .--. .   .    │",
         @"│    (   ) |  |   )   / \  \ / |   |:    :|   )|\  |    │",
         @"│     `-.  |  |--'   /___\  :  |---||    ||--' | \ |    │",
         @"│    (   ) |  |  \  /     \ |  |   |:    ;|  \ |  \|    │",
         @"│     `-'  '  '   `'       `'  '   ' `--' '   `'   '    │",
         @"╚───────────────────────────────────────────────────────╝",],
        [@"╔───────────────────────────────────────────────────────────────╗",
         @"│                                                               │",
         @"│     __  _____  ___    __    _     _     ___   ___   _         │",
         @"│    ( (`  | |  | |_)  / /\  \ \_/ | |_| / / \ | |_) | |\ |     │",
         @"│    _)_)  |_|  |_| \ /_/--\  |_|  |_| | \_\_/ |_| \ |_| \|     │",
         @"│                                                               │",
         @"│                                                               │",
         @"╚───────────────────────────────────────────────────────────────╝",] ,
        [@"╔─────────────────────────────────────────────────────────────────────────────────╗",
         @"│       ___    _____    ___     ___   __   __  _   _    ___     ___    _  _       │",
         @"│      / __|  |_   _|  | _ \   /   \  \ \ / / | | | |  / _ \   | _ \  | \| |      │",
         @"│      \__ \    | |    |   /   | ∆ |   \ V /  | ┌─┐ | | (_) |  |   /  | .` |      │",
         @"│      |___/   _|_|_   |_|_\   |_|_|   _|_|_  |_| |_|  \___/   |_|_\  |_|\_|      │",
         @"│    _|'''''|_|'''''|_|'''''|_|'''''|_|'''''|_|'''''|_|'''''|_|'''''|_|'''''|     │",
         @"│    '`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-''`-0-0-'     │",
         @"╚─────────────────────────────────────────────────────────────────────────────────╝",]
        ];

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
        StateMachine.BlockInput = true;
        CursorVisible = false;
        ForegroundColor = RandDarkColor();
        var logo = StrayhornLogos[new Random().Next(0, StrayhornLogos.Length)];

        //dance
        int[] timers = [225, 225, 225, 300, 375, 300, 375];
        Thread.Sleep(timers[0]);
        //sing
        AudioGenerator.PlayAudio(ChelseaBridge, () =>
        {
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
            foreach (string line in logo) line.WriteLineCentered();
            ResetColor();

            WriteLine();
            Utils.WriteLineCentered("Welcome to Strayhorn, a music theory practice tool.");
            Utils.WriteLineCentered("©2025 AuralTechGames - AuralTech.itch.io");
            Utils.WriteLineCentered("Happy practicing!");
        });

        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("\npress 'CTRL + z' at any time to force quit.");
        ResetColor();

        StateMachine.BlockInput = false;
        return;
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

    public static void PrintScrollWithUD()
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

    static readonly (Pitch[], int, float)[] ChelseaBridge =
       [([new Pitch(new Bb(),3)],375,.4f),
        ([new Pitch(new C(),4)], 300,.5f),
        ([new Pitch(new Db(),4)],375,.4f),
        ([new Pitch(new Eb(),4)],300,.5f),
        ([new Pitch(new F(),4)], 225,.45f),
        ([new Pitch(new G(),4)], 225,.45f),
        ([new Pitch(new Ab(),4)],225,.5f),
        ([new Pitch(new A(),4), //Bb-∆
          new Pitch(new F(),4),
          new Pitch(new C(),4),
          new Pitch(new Bb(),3),
          new Pitch(new G(),3)], 1500, .4f)];

}
