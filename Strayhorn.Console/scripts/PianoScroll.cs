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




    public static readonly string[] TwoOctaveQuestion = [
        "┌──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┬──┬───┬───┬───┬──┬──┬───┬──┬───┬──┬───┬──┐",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │   │   │   │  │  │   │  │   │  │   │  │  │   │   │   │  │  │   │  │   │  │   │  │",
        "│  │ 01│   │ 03│  │  │ 06│  │ 08│  │ 10│  │  │ 13│   │ 15│  │  │ 18│  │ 20│  │ 22│  │",
        "│  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │  └──┬┘   └┬──┘  │  └──┬┘  └─┬─┘  └┬──┘  │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│     │     │     │     │     │     │     │     │     │     │     │     │     │     │",
        "│  00 │  02 │  04 │  05 │  07 │  09 │  11 │  12 │  14 │  16 │  17 │  19 │  21 │  23 │",
        "└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┘"];


    public static readonly string[] FretBox = [
        "e ...──┬──e1─┬──e2─┬──e3─┬──e4─┬──e5─┬──...",
        "B ...──┼──B1─┼──B2─┼──B3─┼──B4─┼──B5─┼──...",
        "G ...──┼──G1─┼──G2─┼──G3─┼──G4─┼──G5─┼──...",
        "D ...──┼──D1─┼──D2─┼──D3─┼──D4─┼──D5─┼──...",
        "A ...──┼──A1─┼──A2─┼──A3─┼──A4─┼──A5─┼──...",
        "E ...──┴──E1─┴──E2─┴──E3─┴──E4─┴──E5─┴──..."];

    public static readonly string[] FretboardOneOctave = [
        "e─┬┬──F──┬─────┬──G──┬─────┬──A──┬─────┬──B──┬──C──┬─────┬──D──┬─────┬──E──┬──",
        "B─┤├──C──┼─────┼──D──┼─────┼──E──┼──F──┼─────┼──G──┼─────┼──A──┼─────┼──B──┼──",
        "G─┤├─────┼──A──┼─────┼──B──┼──C──┼─────┼──D──┼─────┼──E──┼──F──┼─────┼──G──┼──",
        "D─┤├─────┼──E──┼──F──┼─────┼──G──┼─────┼──A──┼─────┼──B──┼──C──┼─────┼──D──┼──",
        "A─┤├─────┼──B──┼──C──┼─────┼──D──┼─────┼──E──┼──F──┼─────┼──G──┼─────┼──A──┼──",
        "E─┴┴──F──┴─────┴──G──┴─────┴──A──┴─────┴──B──┴──C──┴─────┴──D──┴─────┴──E──┴──",
        "      ○           ○           ○           ○           ○                 ○○    ",
        "      1           3           5           7           9                 12    ",];


    public static readonly string[] Staff = [
       @"      /^\                                                           ",
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
    "                                                                         -C-     ",
    "                                                                     B           ",
    "                                                               ─A─  ───  ───     ",
    "                                                           G                     ",
    "┌┬────────────────────────────────────────────────────F────────────────────────┬┐",
    "││                                               E                             ││",
    "│├──────────────────────────────────────────D──────────────────────────────────┤│",
    "││                                     C                                       ││",
    "│├────────────────────────────────B────────────────────────────────────────────┤│",
    "││                           A                                                 ││",
    "│├──────────────────────G──────────────────────────────────────────────────────┤│",
    "││                 F                                                           ││",
    "└┴────────────E────────────────────────────────────────────────────────────────┴┘",
    "         D                                                                       ",
    "   -C-       (aka middle C)                                                      ",
    "         B                                                                       ",
    "┌┬────────────A────────────────────────────────────────────────────────────────┬┐",
    "││                 G                                                           ││",
    "│├──────────────────────F──────────────────────────────────────────────────────┤│",
    "││                           E                                                 ││",
    "│├────────────────────────────────D────────────────────────────────────────────┤│",
    "││                                     C                                       ││",
    "│├──────────────────────────────────────────B──────────────────────────────────┤│",
    "││                                               A                             ││",
    "└┴────────────────────────────────────────────────────G────────────────────────┴┘",
    "                                                           F                     ",
    "                                                               -E-  ───  ───     ",
    "                                                                     D           ",
    "                                                                         ─C─     ",];

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
        foreach (string s in Staff) s.WriteLineCentered();
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

    // public static void DrawOneOctaveQuestion(Pitch pitch)
    // {
    //     string toReplace =
    //         pitch.Chromatic.Value == 10 ? "A" :
    //         pitch.Chromatic.Value == 11 ? "B" :
    //         pitch.Chromatic.Value.ToString();

    //     Console.WriteLine(" ");
    //     string[] replace = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B"];
    //     foreach (string s in OneOctaveQuestion)
    //     {
    //         var newString = s;

    //         foreach (string r in replace)
    //             newString = newString.Replace(r, r == toReplace ? "?" : " ");

    //         Console.WriteLine(newString);
    //     }
    //     Console.WriteLine(" ");
    // }

    /// <summary>
    /// Pitches must range from C3 to B4 (any note with a chromatic value 0-12 and octave 3-4).
    /// </summary>
    public static void DrawTwoOctaveQuestion(Pitch[]? pitches)
    {
        if (pitches == null) throw new System.Exception();

        Console.WriteLine(" ");
        foreach (string s in TwoOctaveQuestion)
        {
            var newString = s;
            foreach (var kvp in Keyboard)
            {
                if (pitches.Any(p => p.PitchID == kvp.Key))
                    newString = newString.Replace(kvp.Value, "??");

                else newString = newString.Replace(kvp.Value, "  ");
            }

            newString.WriteLineCentered();
        }
        Console.WriteLine(" ");
    }

    static readonly Dictionary<int, string> Keyboard = new(){
        { Pitch.GetPitchID(new C(),3), "00" },
        { Pitch.GetPitchID(new Db(),3), "01" },
        { Pitch.GetPitchID(new D(),3), "02" },
        { Pitch.GetPitchID(new Eb(),3), "03" },
        { Pitch.GetPitchID(new E(),3), "04" },
        { Pitch.GetPitchID(new F(),3), "05" },
        { Pitch.GetPitchID(new Gb(),3), "06" },
        { Pitch.GetPitchID(new G(),3), "07" },
        { Pitch.GetPitchID(new Ab(),3), "08" },
        { Pitch.GetPitchID(new A(),3), "09" },
        { Pitch.GetPitchID(new Bb(),3),  "10" },
        { Pitch.GetPitchID(new B(),3),  "11" },
        { Pitch.GetPitchID(new C(),4),  "12" },
        { Pitch.GetPitchID(new Db(),4), "13" },
        { Pitch.GetPitchID(new D(),4),  "14" },
        { Pitch.GetPitchID(new Eb(),4), "15" },
        { Pitch.GetPitchID(new E(),4),  "16" },
        { Pitch.GetPitchID(new F(),4),  "17" },
        { Pitch.GetPitchID(new Gb(),4), "18" },
        { Pitch.GetPitchID(new G(),4),  "19" },
        { Pitch.GetPitchID(new Ab(),4), "20" },
        { Pitch.GetPitchID(new A(),4),  "21" },
        { Pitch.GetPitchID(new Bb(),4),  "22" },
        { Pitch.GetPitchID(new B(),4),   "23" },
    };

}

/*
 ╔  ╗  ║  ╚  ╝  ╦  ╩  ╠  ╣  ╬
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