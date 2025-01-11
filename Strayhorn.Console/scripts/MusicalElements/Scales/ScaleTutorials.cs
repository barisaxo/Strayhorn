using MusicTheory.Notes;
using Strayhorn.Utility;
using Strayhorn.Systems.Display;

namespace Strayhorn.Tutorials;

public class ScalesTutorialP1 : ITutorial
{
    public ITutorial? PrevPage() => null;
    public ITutorial? NextPage() => new ScalesTutorialP2();
    public IDisplay Display { get; }

    public ScalesTutorialP1()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine("(p1 of 3)");
        Console.WriteLine();

        Console.WriteLine("A scale is a series of steps from a key center to its octave.");
        Console.WriteLine("99% of the concepts in Music theory are based off of the major scale.");
        Console.WriteLine("Other scales are considered alterations thereof.");
        Console.WriteLine("The stepwise makeup of the major scale is: W W H W W W H");
        Console.WriteLine();
        Console.WriteLine("Scale Degrees are a key agnostic abstraction made by numbering the notes of a scale:");
        Console.WriteLine("The major scale is: 1 2 3 4 5 6 7 1");
        Console.WriteLine("It doesn't matter what key the scale is, the pattern of scale degrees never changes");
        Console.WriteLine("This also mirrors the pattern of Solfege: Do Ro Me Fa So La Ti Do");
        Console.WriteLine("Do = 1, Re = 2, Mi = 3, Fa = 4, So = 5, La = 6, Ti = 7.");

    }
}

public class ScalesTutorialP2 : ITutorial
{
    public ITutorial? PrevPage() => new ScalesTutorialP1();
    public ITutorial? NextPage() => new ScalesTutorialP3();
    public IDisplay Display { get; }

    public ScalesTutorialP2()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine("(p2 of 3)");
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.Major Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("This is how scale degrees and the stepwise makeup fit together:");
        Console.WriteLine();
        Utils.WriteLineCentered(@"C   D   E F   G   A   B C");
        Utils.WriteLineCentered(@"1   2   3 4   5   6   7 1");
        Utils.WriteLineCentered(@" \ / \ / ‾ \ / \ / \ / ‾ ");
        Utils.WriteLineCentered(@"  W   W  H  W   W   W  H ");
    }
}
public class ScalesTutorialP3 : ITutorial
{
    public ITutorial? PrevPage() => new ScalesTutorialP2();
    public ITutorial? NextPage() => null;
    public IDisplay Display { get; }

    public ScalesTutorialP3()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine("(p3 of 3)");
        Console.WriteLine();
        Console.WriteLine("Rules for building major scales:");
        Console.WriteLine("Use all letters of the musical alphabet (A-G) once, and only once.");
        Console.WriteLine("Don't mix sharps and flats.");
    }
}

public class MoreScalesTutorialP1 : ITutorial
{
    public ITutorial? PrevPage() => null;
    public ITutorial? NextPage() => new MoreScalesTutorialP2();
    public IDisplay Display { get; }

    public MoreScalesTutorialP1()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.Chromatic Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        int octave = 3;
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("The Chromatic Scale, all 12 keys, all half steps:");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C Db E Eb E F Gb G Ab A Bb B C");
        Utils.WriteLineCentered(@"1 b2 2 b3 3 4 b5 5 b6 6 b7 7 1");
        Utils.WriteLineCentered(@" ‾  ‾ ‾  ‾ ‾ ‾  ‾ ‾  ‾ ‾  ‾ ‾ ");
        Utils.WriteLineCentered(@" H  H H  H H H  H H  H H  H H ");
    }
}

public class MoreScalesTutorialP2 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP1();
    public ITutorial? NextPage() => new MoreScalesTutorialP3();
    public IDisplay Display { get; }

    public MoreScalesTutorialP2()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.Minor Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("The Natural Minor Scale:");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C   D Eb   F   G Ab   Bb C");
        Utils.WriteLineCentered(@"1   2 b3   4   5 b6   b7 1");
        Utils.WriteLineCentered(@" \ / ‾  \ / \ / ‾  \ /  ‾ ");
        Utils.WriteLineCentered(@"  W  H   W   W  H   W   H ");
    }
}

public class MoreScalesTutorialP3 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP2();
    public ITutorial? NextPage() => new MoreScalesTutorialP4();
    public IDisplay Display { get; }

    public MoreScalesTutorialP3()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.JazzMinor Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("The Melodic 'Jazz' Minor Scale:");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C   D Eb   F   G   A   B C");
        Utils.WriteLineCentered(@"1   2 b3   4   5   6   7 1");
        Utils.WriteLineCentered(@" \ / ‾  \ / \ / \ / \ / ‾ ");
        Utils.WriteLineCentered(@"  W  H   W   W   W   W  H ");
    }
}

public class MoreScalesTutorialP4 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP3();
    public ITutorial? NextPage() => new MoreScalesTutorialP5();
    public IDisplay Display { get; }

    public MoreScalesTutorialP4()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.HarmonicMinor Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("The Harmonic Minor Scale:");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C   D Eb   F   G Ab     B C");
        Utils.WriteLineCentered(@"1   2 b3   4   5 b6     7 1");
        Utils.WriteLineCentered(@" \ / ‾  \ / \ / ‾  \ _ / ‾ ");
        Utils.WriteLineCentered(@"  W  H   W   W  H    S   H ");
    }
}

public class MoreScalesTutorialP5 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP4();
    public ITutorial? NextPage() => new MoreScalesTutorialP6();
    public IDisplay Display { get; }

    public MoreScalesTutorialP5()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.Diminished Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("The Diminished Scale:\na type of symmetrical Octatonic (8-note) scale with alternating W & H steps");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C   D Eb   F Gb   Ab  A   B C");
        Utils.WriteLineCentered(@"1   2 b3   4 b5   b6 º7   7 1");
        Utils.WriteLineCentered(@" \ / ‾  \ / ‾  \ /  ‾  \ / ‾ ");
        Utils.WriteLineCentered(@"  W  H   W  H   W   H   W  H ");
    }
}

public class MoreScalesTutorialP6 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP5();
    public ITutorial? NextPage() => new MoreScalesTutorialP7();
    public IDisplay Display { get; }

    public MoreScalesTutorialP6()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.WholeTone Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("The WholeTone Scale:\na type of symmetrical 6-note scale composed of only W steps");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C   D   E   F#   G#   Bb   C");
        Utils.WriteLineCentered(@"1   2   3   #4   #5   b7   1");
        Utils.WriteLineCentered(@" \ / \ / \ /  \ /  \ /  \ / ");
        Utils.WriteLineCentered(@"  W   W   W    W    W    W  ");
    }
}

public class MoreScalesTutorialP7 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP6();
    public ITutorial? NextPage() => new MoreScalesTutorialP8();
    public IDisplay Display { get; }

    public MoreScalesTutorialP7()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        Console.WriteLine("And there are Pentatonic scales.");
        Console.WriteLine("• Penta [greek] 'five' ");
        Console.WriteLine("• tonic [greek] 'tone {note}' ");
        Console.WriteLine();
        Console.WriteLine("We derive pentatonic scales from the major scale by removing the 4th and 7th scale degrees. ");
        Console.WriteLine("We can also find them in the unused notes of the major scale (or all 5 black keys on the piano)");
    }
}

public class MoreScalesTutorialP8 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP7();
    public ITutorial? NextPage() => new MoreScalesTutorialP9();
    public IDisplay Display { get; }

    public MoreScalesTutorialP8()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.Pentatonic Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("The Pentatonic Scale:");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C   D   E     G   A     C");
        Utils.WriteLineCentered(@"1   2   3     5   6     1");
        Utils.WriteLineCentered(@" \ / \ / \ _ / \ / \ _ / ");
        Utils.WriteLineCentered(@"  W   W    S    W    S   ");
    }
}


public class MoreScalesTutorialP9 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP8();
    public ITutorial? NextPage() => new MoreScalesTutorialP10();
    public IDisplay Display { get; }

    public MoreScalesTutorialP9()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();
        int octave = 3;

        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.MinorPentatonic Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();
        Console.WriteLine("The Pentatonic Minor Scale:");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C     Eb   F   G     Bb   C");
        Utils.WriteLineCentered(@"1     b3   4   5     b7   1");
        Utils.WriteLineCentered(@" \ _ /  \ / \ / \ _ /  \ / ");
        Utils.WriteLineCentered(@"   S     W   W    S     W  ");
    }
}


public class MoreScalesTutorialP10 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP9();
    public ITutorial? NextPage() => new MoreScalesTutorialP11();
    public IDisplay Display { get; }

    public MoreScalesTutorialP10()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.Blues Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("Now we can add in a 'blue' note with a chromatic passing tone, and get the Blues Scale:");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C     Eb   F Gb G     Bb   C");
        Utils.WriteLineCentered(@"1     b3   4 b5 5     b7   1");
        Utils.WriteLineCentered(@" \ _ /  \ / ‾  ‾ \ _ /  \ / ");
        Utils.WriteLineCentered(@"   S     W  H  H   S     W  ");
    }
}

public class MoreScalesTutorialP11 : ITutorial
{
    public ITutorial? PrevPage() => new MoreScalesTutorialP10();
    public ITutorial? NextPage() => null;
    public IDisplay Display { get; }

    public MoreScalesTutorialP11()
    {
        Display = new Display(PrintTutorial);
    }

    static void PrintTutorial()
    {
        Console.Clear();
        Console.WriteLine();

        int octave = 3;
        IPitchClass C = new MusicTheory.Notes.C();
        MusicTheory.Scales.MajorBlues Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(C, octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();

        Console.WriteLine("The Major Blues Scale:");

        Console.WriteLine();
        Utils.WriteLineCentered(@"C   D Eb E     G   A     C");
        Utils.WriteLineCentered(@"1   2 b3 3     5   6     1");
        Utils.WriteLineCentered(@" \ / ‾  ‾ \ _ / \ / \ _ / ");
        Utils.WriteLineCentered(@"  W  H  H   S    W    S   ");
    }
}
