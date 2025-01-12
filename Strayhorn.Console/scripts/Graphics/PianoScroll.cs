namespace Strayhorn;
using MusicTheory.Notes;
using Strayhorn.Utility;
using MusicTheory;

public static class PianoScroll
{
    const string b = "♭";
    const string s = "♯";
    const string x = "𝄪";
    const string n = "♮";
    const string d = "𝄫";

    public static readonly string[] OneOctaveWithLetters = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│  C  │  D  │  E  │  F  │  G  │  A  │  B  │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];




    public static readonly string[] OneOctaveWithEnharmonicWhite = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│  C♮ │     │  E♮ │  F♮ │     │     │  B♮ │",
        "│  B♯ │     │  F♭ │  E♯ │     │     │  C♭ │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];




    public static readonly string[] OneOctaveWithEnharmonicBlack = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │ D♭│   │ E♭│  │  │ G♭│  │ A♭│  │ B♭│  │",
        "│  │ C♯│   │ D♯│  │  │ F♯│  │ G♯│  │ A♯│  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];




    public static readonly string[] OneOctaveWithAllEnharmonic = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │ D♭│   │ E♭│  │  │ G♭│  │ A♭│  │ B♭│  │",
        "│  │ C♯│   │ D♯│  │  │ F♯│  │ G♯│  │ A♯│  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│  C♮ │     │  E♮ │  F♮ │     │     │  B♮ │",
        "│  B♯ │     │  F♭ │  E♯ │     │     │  C♭ │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];




    public static readonly string[] OneOctaveQuestion = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │ 01│   │ 03│  │  │ 06│  │ 08│  │ 10│  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│  00 │  02 │  04 │  05 │  07 │  09 │  11 │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];




    public static readonly string[] OneOctaveBlank = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];




    public static readonly string[] TwoOctaveBlank = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┬──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];




    public static readonly string[] TwoOctaveWithLetters = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┬──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│  C  │  D  │  E  │  F  │  G  │  A  │  B  │  C  │  D  │  E  │  F  │  G  │  A  │  B  │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];




    public static readonly string[] TwoOctaveQuestionTop = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┬──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",];

    public static readonly string TwoOctaveQuestionBlackKey =
        "│  │001│   │003│  │  │006│  │008│  │010│  │  │013│   │015│  │  │018│  │020│  │022│  │";

    public static readonly string[] TwoOctaveQuestionMiddle = [
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",];

    public static readonly string TwoOctaveQuestionWhiteKey =
        "│ 000 │ 002 │ 004 │ 005 │ 007 │ 009 │ 011 │ 012 │ 014 │ 016 │ 017 │ 019 │ 021 │ 023 │";

    public static readonly string TwoOctaveQuestionBottom =
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┘";

    public static void DrawTwoOctavePianoQuestionWithCarat(Pitch bottom, Pitch[] selected, Pitch Caret, Pitch[]? playing = null)
    {
        int windowWidth = Console.WindowWidth;
        int textLength = TwoOctaveQuestionTop[0].Length;
        int leftMargin = (windowWidth - textLength) / 2;
        string leftPad = "".PadLeft(leftMargin < 0 ? 0 : leftMargin);
        int remaining = windowWidth - leftPad.Length - textLength;
        string rightPad = "".PadRight(remaining < 0 ? 0 : remaining);

        foreach (string s in TwoOctaveQuestionTop) s.WriteLineCentered();
        PrintColoredNotes(TwoOctaveQuestionBlackKey);
        foreach (string s in TwoOctaveQuestionMiddle) s.WriteLineCentered();
        PrintColoredNotes(TwoOctaveQuestionWhiteKey);
        TwoOctaveQuestionBottom.WriteLineCentered();

        void PrintColoredNotes(string s)
        {
            string temp = "";
            Console.Write(leftPad);

            foreach (char ch in s)
            {
                if (temp.Length == 3 && temp.Contains('0'))
                {
                    //temp is three digits, time to parse the note
                    bool exit = false;
                    string? value = null;

                    if (playing != null)
                        foreach (Pitch p in playing)
                            if (Keyboard.TryGetValue(p.PitchID, out value))
                            {
                                if (temp == value)
                                {
                                    //Note is selected
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write("   ");
                                    Console.ResetColor();
                                    temp = "";
                                    temp += ch;
                                    exit = true;
                                }
                                if (exit) break;
                            }
                    if (exit) continue;

                    if (Keyboard.TryGetValue(Caret.PitchID, out value))
                    {
                        if (temp == value)
                        {
                            bool contains = false;
                            foreach (var p in selected)
                            {
                                if (p.PitchID == Caret.PitchID)
                                {
                                    //Note is selected and Caret
                                    contains = true;
                                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("   ");
                                    Console.ResetColor();
                                    temp = "";
                                    temp += ch;
                                    break;
                                }
                            }
                            if (!contains)
                            {
                                //Note is only Caret
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.Write("   ");
                                Console.ResetColor();
                                temp = "";
                                temp += ch;
                            }
                            continue;
                        }
                    }

                    if (Keyboard.TryGetValue(bottom.PitchID, out value))
                    {
                        if (temp == value)
                        {
                            //Note is bottom/question
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(" ? ");
                            Console.ResetColor();
                            temp = "";
                            temp += ch;
                            continue;
                        }
                    }

                    foreach (Pitch p in selected)
                        if (Keyboard.TryGetValue(p.PitchID, out value))
                        {
                            if (temp == value)
                            {
                                //Note is selected
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.Write("   ");
                                Console.ResetColor();
                                temp = "";
                                temp += ch;
                                exit = true;
                            }
                            if (exit) break;
                        }
                    if (exit) continue;

                    //Note is empty
                    Console.Write("   ");
                    temp = "";
                }

                if (ch is not '│' or ' ' && (temp.Contains('│') || temp.Contains(' ')))
                {
                    //temp is piano drawing, char is note digit, 
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(temp);
                    Console.ResetColor();
                    temp = "";
                }

                temp += ch;
            }

            //finish drawing the piano & empty space
            Console.Write(temp + rightPad + "\n");
        }
    }

    public static readonly string[] FretBox = [
        "e ...──┬──e1─┬──e2─┬──e3─┬──e4─┬──e5─┬──...",
        "B ...──┼──B1─┼──B2─┼──B3─┼──B4─┼──B5─┼──...",
        "G ...──┼──G1─┼──G2─┼──G3─┼──G4─┼──G5─┼──...",
        "D ...──┼──D1─┼──D2─┼──D3─┼──D4─┼──D5─┼──...",
        "A ...──┼──A1─┼──A2─┼──A3─┼──A4─┼──A5─┼──...",
        "E ...──┴──E1─┴──E2─┴──E3─┴──E4─┴──E5─┴──..."];

    public static readonly string[] FretboardOneOctave = [
        "      1           3           5           7           9                 12    ",
        "      ●           ●           ●           ●           ●                 ●●    ",
        "",
        "e─┬┬──F──┬─────┬──G──┬─────┬──A──┬─────┬──B──┬──C──┬─────┬──D──┬─────┬──E──┬──",
        "B─┤├──C──┼─────┼──D──┼─────┼──E──┼──F──┼─────┼──G──┼─────┼──A──┼─────┼──B──┼──",
        "G─┤├─────┼──A──┼─────┼──B──┼──C──┼─────┼──D──┼─────┼──E──┼──F──┼─────┼──G──┼──",
        "D─┤├─────┼──E──┼──F──┼─────┼──G──┼─────┼──A──┼─────┼──B──┼──C──┼─────┼──D──┼──",
        "A─┤├─────┼──B──┼──C──┼─────┼──D──┼─────┼──E──┼──F──┼─────┼──G──┼─────┼──A──┼──",
        "E─┴┴──F──┴─────┴──G──┴─────┴──A──┴─────┴──B──┴──C──┴─────┴──D──┴─────┴──E──┴──",
        "",
        "      ●           ●           ●           ●           ●                 ●●    ",
        "      1           3           5           7           9                 12    ",];




    public static readonly string[] TrebleStaff = [
       @"      /▔\                                                           ",
        "┌┬────|─|─────────────────────────────────────────────────────────┬┐",
        "││    │/                                                          ││",
        "│├────│───────────────────────────────────────────────────────────┤│",
        "││   /│                                                           ││",
        "│├──/─│───────────────────────────────────────────────────────────┤│",
        "││ |  │ _                                                         ││",
        "│├─|─(@)─)────────────────────────────────────────────────────────┤│",
       @"││  \ │ /                                                         ││",
        "└┴────│───────────────────────────────────────────────────────────┴┘",
        "      |                                                             ",
        "    (_|                                                             "];


    public static readonly string[] BassStaff = [
        "┌┬────────────────────────────────────────────────────────────────┬┐",
       @"││  /▔▔▔▔▔\  @                                                    ││",
       @"│├─|──\────\──────────────────────────────────────────────────────┤│",
       @"││  \_/    | @                                                    ││",
        "│├─────────|──────────────────────────────────────────────────────┤│",
        "││        /                                                       ││",
        "│├──────/─────────────────────────────────────────────────────────┤│",
       @"││   _/                                                           ││",
        "└┴────────────────────────────────────────────────────────────────┴┘",];

    public static readonly string[] TrebleSpaces = [
        "┌┬────────────────────────┬┐",
        "││                   E    ││",
        "│├────────────────────────┤│",
        "││              C         ││",
        "│├────────────────────────┤│",
        "││         A              ││",
        "│├────────────────────────┤│",
        "││    F                   ││",
        "└┴────────────────────────┴┘",];



    public static readonly string[] SkinnyTreble4LedgerTop = [
     "     -G6     ",
     "      F6     "];
    public static readonly string[] SkinnyTreble3LedgerTop = [
     "     -E6     ",
     "      D6     "];
    public static readonly string[] SkinnyTreble2LedgerTop = [
     "     -C6     ",
     "      B5     "];
    public static readonly string[] SkinnyTreble1LedgerTop = [
     "     -A5     ",
     "      G5     "];
    static readonly string[] SkinnyTreble = [
     "┌┬────F5───┬┐",
     "││    E5   ││",
     "│├────D5───┤│",
     "││    C5   ││",
     "│├────B4───┤│",
     "││    A4   ││",
     "│├────G4───┤│",
     "││    F4   ││",
     "└┴────E4───┴┘",];
    static readonly string[] SkinnyTreble1LedgerBottom = [
     "      D4     ",
     "     -C4     ",];
    static readonly string[] SkinnyTreble2LedgerBottom = [
     "      B3     ",
     "     -A3     ",];
    static readonly string[] SkinnyTreble3LedgerBottom = [
     "      G3     ",
     "     -F3     ",];
    static readonly string[] SkinnyTreble4LedgerBottom = [
     "      E3     ",
     "     -D3     ",];


    static readonly string[] TrebleLines = [
    "┌┬────────────────────────F────┬┐",
    "││                             ││",
    "│├───────────────────D─────────┤│",
    "││                             ││",
    "│├──────────────B──────────────┤│",
    "││                             ││",
    "│├─────────G───────────────────┤│",
    "││                             ││",
    "└┴────E────────────────────────┴┘",];


    static readonly string[] BassSpaces = [
    "┌┬────────────────────────┬┐",
    "││                   G    ││",
    "│├────────────────────────┤│",
    "││              E         ││",
    "│├────────────────────────┤│",
    "││         C              ││",
    "│├────────────────────────┤│",
    "││    A                   ││",
    "└┴────────────────────────┴┘",];


    static readonly string[] BassLines = [
    "┌┬────────────────────────A────┬┐",
    "││                             ││",
    "│├───────────────────F─────────┤│",
    "││                             ││",
    "│├──────────────D──────────────┤│",
    "││                             ││",
    "│├─────────B───────────────────┤│",
    "││                             ││",
    "└┴────G────────────────────────┴┘",];



    static readonly string[] GrandStaff = [
    "                                                                                     -C-     ",
    "                                                                                 B           ",
    "                                                                           ─A─  ───  ───     ",
   @"      /▔\                                                              G                     ",
    "┌┬────|─|─────────────────────────────────────────────────────────F────────────────────────┬┐",
    "││    │/                                                     E                             ││",
    "│├────│─────────────────────────────────────────────────D──────────────────────────────────┤│",
    "││   /│                                            C                                       ││",
    "│├──/─│───────────────────────────────────────B────────────────────────────────────────────┤│",
    "││ |  │ _                                A                                                 ││",
    "│├─|─(@)─)──────────────────────────G──────────────────────────────────────────────────────┤│",
   @"││  \ │ /                      F                                                           ││",
    "└┴────│───────────────────E────────────────────────────────────────────────────────────────┴┘",
    "      |              D                                                                       ",
    "    (_|  middle -C-                                                                          ",
    "                     B                                                                       ",
    "┌┬────────────────────────A────────────────────────────────────────────────────────────────┬┐",
   @"││  /▔▔▔▔▔\  @                 G                                                           ││",
   @"│├─|──\────\────────────────────────F──────────────────────────────────────────────────────┤│",
   @"││  \_/    | @                           E                                                 ││",
    "│├─────────|──────────────────────────────────D────────────────────────────────────────────┤│",
    "││        /                                        C                                       ││",
    "│├──────/───────────────────────────────────────────────B──────────────────────────────────┤│",
    "││   _/                                                      A                             ││",
    "└┴────────────────────────────────────────────────────────────────G────────────────────────┴┘",
    "                                                                       F                     ",
    "                                                                           -E-  ───  ───     ",
    "                                                                                 D           ",
    "                                                                                     ─C─     ",];

    static readonly string[] SkinnyGrandStaff = [
    "     -C-     ",
    "      B      ",
    "     ─A─     ",
    "      G      ",
    "┌┬────F────┬┐",
    "││    E    ││",
    "│├────D────┤│",
    "││    C    ││",
    "│├────B────┤│",
    "││    A    ││",
    "│├────G────┤│",
    "││    F    ││",
    "└┴────E────┴┘",
    "      D      ",
    "     -C-     ",
    "      B      ",
    "┌┬────A────┬┐",
    "││    G    ││",
    "│├────F────┤│",
    "││    E    ││",
    "│├────D────┤│",
    "││    C    ││",
    "│├────B────┤│",
    "││    A    ││",
    "└┴────G────┴┘",
    "      F      ",
    "     ─E─     ",
    "      D      ",
    "     ─C─     ",];


    public static void DrawStaves()
    {
        Console.WriteLine("");
        foreach (string s in TrebleStaff) s.WriteLineCentered();
        Console.WriteLine("");
        foreach (string s in TrebleLines) s.WriteLineCentered();
        Console.WriteLine("");
        foreach (string s in TrebleSpaces) s.WriteLineCentered();
        Console.WriteLine("");
        foreach (string s in BassLines) s.WriteLineCentered();
        Console.WriteLine("");
        foreach (string s in BassSpaces) s.WriteLineCentered();
        Console.WriteLine("");
        foreach (string s in GrandStaff) s.WriteLineCentered();
        Console.WriteLine("");
    }

    public static void Draw(string[] thing)
    {
        Console.WriteLine("");
        foreach (string s in thing) s.WriteLineCentered();
        Console.WriteLine("");
    }

    public static void DrawGuitarOneOctave()
    {
        Console.WriteLine("");
        foreach (string s in FretboardOneOctave) s.WriteLineCentered();
        Console.WriteLine("");
    }

    public static void DrawGuitarBox()
    {
        Console.WriteLine("");
        foreach (string s in FretBox) s.WriteLineCentered();
        Console.WriteLine("");
    }

    public static void DrawTwoOctavePiano()
    {
        Console.WriteLine("");
        foreach (string s in TwoOctaveWithLetters)
            s.WriteLineCentered();
        Console.WriteLine("");
    }

    public static void DrawOneOctavePiano()
    {
        Console.WriteLine("");
        foreach (string s in OneOctaveWithLetters)
            s.WriteLineCentered();
        Console.WriteLine("");
    }

    public static void DrawOneOctavePiano(Pitch[] notes)
    {
        if (notes == null) throw new System.Exception();

        Console.WriteLine();
        foreach (string s in OneOctaveQuestion)
        {
            var newString = s;
            foreach (var kvp in Keyboard)
            {
                bool match = false;
                foreach (var note in notes)
                {
                    if (note.PitchID == kvp.Key)
                    {
                        match = true;
                    }
                    if (match)
                    {
                        newString = newString.Replace(kvp.Value,
                            note.PitchClass.Name + (note.PitchClass.Name.Length == 1 ? " " : ""));
                        break;
                    }
                }
                if (!match) newString = newString.Replace(kvp.Value, "  ");
            }
            newString.WriteLineCentered();
        }
        Console.WriteLine();
    }

    static readonly Dictionary<int, string> Keyboard = new(){
        { Pitch.GetPitchID(new C(),3),   "000" },
        { Pitch.GetPitchID(new Db(),3),  "001" },
        { Pitch.GetPitchID(new D(),3),   "002" },
        { Pitch.GetPitchID(new Eb(),3),  "003" },
        { Pitch.GetPitchID(new E(),3),   "004" },
        { Pitch.GetPitchID(new F(),3),   "005" },
        { Pitch.GetPitchID(new Gb(),3),  "006" },
        { Pitch.GetPitchID(new G(),3),   "007" },
        { Pitch.GetPitchID(new Ab(),3),  "008" },
        { Pitch.GetPitchID(new A(),3),   "009" },
        { Pitch.GetPitchID(new Bb(),3),  "010" },
        { Pitch.GetPitchID(new B(),3),   "011" },
        { Pitch.GetPitchID(new C(),4),   "012" },
        { Pitch.GetPitchID(new Db(),4),  "013" },
        { Pitch.GetPitchID(new D(),4),   "014" },
        { Pitch.GetPitchID(new Eb(),4),  "015" },
        { Pitch.GetPitchID(new E(),4),   "016" },
        { Pitch.GetPitchID(new F(),4),   "017" },
        { Pitch.GetPitchID(new Gb(),4),  "018" },
        { Pitch.GetPitchID(new G(),4),   "019" },
        { Pitch.GetPitchID(new Ab(),4),  "020" },
        { Pitch.GetPitchID(new A(),4),   "021" },
        { Pitch.GetPitchID(new Bb(),4),  "022" },
        { Pitch.GetPitchID(new B(),4),   "023" },
    };



}

/*
 ╔  ╗  ║  ╚  ╝ ═ ╦  ╩  ╠  ╣  ╬
 ╔═╦═╗  
 ║ ║ ║
 ╠═╬═╣ 
 ║ ║ ║
 ╚═╩═╝ 
         
 ┐ ┌  ┘ └ ─ │ ┴ ┬ ├ ┼ ┤
 ┌─┬─┐
 │ │ │
 ├─┼─┤
 │ │ │
 └─┴─┘
 
*/


// public static readonly string[] TwoOctaveQuestion = [
//     "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┬──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
//     "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
//     "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
//     "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
//     "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
//     "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
//     "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
//     "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
//     "│  │ 01│   │ 03│  │  │ 06│  │ 08│  │ 10│  │  │ 13│   │ 15│  │  │ 18│  │ 20│  │ 22│  │",
//     "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
//     "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
//     "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
//     "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
//     "│  00 │  02 │  04 │  05 │  07 │  09 │  11 │  12 │  14 │  16 │  17 │  19 │  21 │  23 │",
//     "└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];
// /// <summary>
// /// Pitches must range from C3 to B4 (any note with a chromatic value 0-11 and octave 3-4).
// /// </summary>
// public static void DrawTwoOctaveQuestion(Pitch[]? pitches)
// {
//     if (pitches == null) throw new System.Exception();

//     Console.WriteLine();
//     foreach (string s in TwoOctaveQuestion)
//     {
//         var newString = s;
//         foreach (var kvp in Keyboard)
//         {
//             if (pitches.Any(p => p.PitchID == kvp.Key))
//                 newString = newString.Replace(kvp.Value, "? ");

//             else newString = newString.Replace(kvp.Value, "  ");
//         }

//         newString.WriteLineCentered();
//     }
//     Console.WriteLine();
// }
