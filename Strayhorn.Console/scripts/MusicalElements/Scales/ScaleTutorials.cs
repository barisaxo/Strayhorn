using MusicTheory.Notes;
using Strayhorn.Utility;
using Strayhorn.Systems.Display;

namespace Strayhorn.Tutorials;

public class ScalesTutorial : ITutorial
{
    public IDisplay[] Displays => [P1, P2, P3];

    static TutorialPageDisplay P1 => new(() =>
    {
        Console.WriteLine("\nA scale is a series of steps from a key center to its octave.");
        Console.WriteLine("99% of the concepts in Music theory are based off of the major scale.");
        Console.WriteLine("Other scales are considered alterations thereof.");
        Console.WriteLine("The stepwise makeup of the major scale is: W W H W W W H");
        Console.WriteLine();
        Console.WriteLine("Scale Degrees are a key agnostic abstraction made by numbering the notes of a scale:");
        Console.WriteLine("The major scale is: 1 2 3 4 5 6 7 1");
        Console.WriteLine("It doesn't matter what key the scale is, the pattern of scale degrees never changes");
        Console.WriteLine("This also mirrors the pattern of Solfege: Do Ro Me Fa So La Ti Do");
        Console.WriteLine("Do = 1, Re = 2, Mi = 3, Fa = 4, So = 5, La = 6, Ti = 7.");
    });

    static TutorialPageDisplay P2 => new(() =>
    {
        int octave = 3;
        MusicTheory.Scales.Major Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

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
    });

    static TutorialPageDisplay P3 => new(() =>
    {
        Console.WriteLine("\nRules for building major scales:");
        Console.WriteLine("Use all letters of the musical alphabet (A-G) once, and only once.");
        Console.WriteLine("Don't mix sharps and flats.");
    });
}

public class MoreScalesTutorial : ITutorial
{
    public IDisplay[] Displays => [P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11];

    static TutorialPageDisplay P1 => new(() =>
    {
        MusicTheory.Scales.Chromatic Scale = new();
        int octave = 3;
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);
        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nThe Chromatic Scale, all 12 keys, all half steps:\n");
        Utils.WriteLineCentered(@"C Db E Eb E F Gb G Ab A Bb B C");
        Utils.WriteLineCentered(@"1 b2 2 b3 3 4 b5 5 b6 6 b7 7 1");
        Utils.WriteLineCentered(@" ‾  ‾ ‾  ‾ ‾ ‾  ‾ ‾  ‾ ‾  ‾ ‾ ");
        Utils.WriteLineCentered(@" H  H H  H H H  H H  H H  H H ");
    });

    static TutorialPageDisplay P2 => new(() =>
    {
        int octave = 3;
        MusicTheory.Scales.Minor Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nThe Natural Minor Scale:\n");
        Utils.WriteLineCentered(@"C   D Eb   F   G Ab   Bb C");
        Utils.WriteLineCentered(@"1   2 b3   4   5 b6   b7 1");
        Utils.WriteLineCentered(@" \ / ‾  \ / \ / ‾  \ /  ‾ ");
        Utils.WriteLineCentered(@"  W  H   W   W  H   W   H ");
    });

    static TutorialPageDisplay P3 => new(() =>
    {
        int octave = 3;
        MusicTheory.Scales.JazzMinor Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nThe Melodic 'Jazz' Minor Scale:\n");
        Utils.WriteLineCentered(@"C   D Eb   F   G   A   B C");
        Utils.WriteLineCentered(@"1   2 b3   4   5   6   7 1");
        Utils.WriteLineCentered(@" \ / ‾  \ / \ / \ / \ / ‾ ");
        Utils.WriteLineCentered(@"  W  H   W   W   W   W  H ");
    });

    static TutorialPageDisplay P4 => new(() =>
    {
        int octave = 3;
        MusicTheory.Scales.HarmonicMinor Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nThe Harmonic Minor Scale:\n");
        Utils.WriteLineCentered(@"C   D Eb   F   G Ab     B C");
        Utils.WriteLineCentered(@"1   2 b3   4   5 b6     7 1");
        Utils.WriteLineCentered(@" \ / ‾  \ / \ / ‾  \ _ / ‾ ");
        Utils.WriteLineCentered(@"  W  H   W   W  H    S   H ");
    });

    static TutorialPageDisplay P5 => new(() =>
    {
        int octave = 3;

        MusicTheory.Scales.Diminished Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine();
        Console.WriteLine("\nThe Diminished Scale:\na type of symmetrical Octatonic (8-note) scale with alternating W & H steps\n");
        Utils.WriteLineCentered(@"C   D Eb   F Gb   Ab  A   B C");
        Utils.WriteLineCentered(@"1   2 b3   4 b5   b6 º7   7 1");
        Utils.WriteLineCentered(@" \ / ‾  \ / ‾  \ /  ‾  \ / ‾ ");
        Utils.WriteLineCentered(@"  W  H   W  H   W   H   W  H ");
    });

    static TutorialPageDisplay P6 => new(() =>
    {
        int octave = 3;

        MusicTheory.Scales.WholeTone Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nThe WholeTone Scale:\na type of symmetrical 6-note scale composed of only W steps\n");
        Utils.WriteLineCentered(@"C   D   E   F#   G#   Bb   C");
        Utils.WriteLineCentered(@"1   2   3   #4   #5   b7   1");
        Utils.WriteLineCentered(@" \ / \ / \ /  \ /  \ /  \ / ");
        Utils.WriteLineCentered(@"  W   W   W    W    W    W  ");
    });


    static TutorialPageDisplay P7 => new(() =>
    {
        Console.Clear();
        Console.WriteLine();

        Console.WriteLine("And there are Pentatonic scales.");
        Console.WriteLine("• Penta [greek] 'five' ");
        Console.WriteLine("• tonic [greek] 'tone {note}' ");
        Console.WriteLine();
        Console.WriteLine("We derive pentatonic scales from the major scale by removing the 4th and 7th scale degrees. ");
        Console.WriteLine("We can also find them in the unused notes of the major scale (or all 5 black keys on the piano)");
    });


    static TutorialPageDisplay P8 => new(() =>
    {
        int octave = 3;

        MusicTheory.Scales.Pentatonic Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.Clear();
        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nThe Pentatonic Scale:\n");
        Utils.WriteLineCentered(@"C   D   E     G   A     C");
        Utils.WriteLineCentered(@"1   2   3     5   6     1");
        Utils.WriteLineCentered(@" \ / \ / \ _ / \ / \ _ / ");
        Utils.WriteLineCentered(@"  W   W    S    W    S   ");
    });



    static TutorialPageDisplay P9 => new(() =>
    {
        int octave = 3;

        MusicTheory.Scales.MinorPentatonic Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nThe Pentatonic Minor Scale:\n");

        Utils.WriteLineCentered(@"C     Eb   F   G     Bb   C");
        Utils.WriteLineCentered(@"1     b3   4   5     b7   1");
        Utils.WriteLineCentered(@" \ _ /  \ / \ / \ _ /  \ / ");
        Utils.WriteLineCentered(@"   S     W   W    S     W  ");
    });


    static TutorialPageDisplay P10 => new(() =>
    {
        int octave = 3;

        MusicTheory.Scales.Blues Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nNow we can add in a 'blue' note with a chromatic passing tone, and get the Blues Scale:\n");
        Utils.WriteLineCentered(@"C     Eb   F Gb G     Bb   C");
        Utils.WriteLineCentered(@"1     b3   4 b5 5     b7   1");
        Utils.WriteLineCentered(@" \ _ /  \ / ‾  ‾ \ _ /  \ / ");
        Utils.WriteLineCentered(@"   S     W  H  H   S     W  ");
    });

    static TutorialPageDisplay P11 => new(() =>
    {
        int octave = 3;

        MusicTheory.Scales.MajorBlues Scale = new();
        Pitch[] notes = new Pitch[Scale.ScaleDegrees.Length];
        notes[0] = new Pitch(new C(), octave);

        for (int i = 1; i < notes.Length; i++)
        {
            IPitchClass pc = IPitchClass.GetPitchClassAbove(notes[0].PitchClass, Scale.ScaleDegrees[i]);
            notes[i] = new Pitch(pc, octave);
        }

        Console.WriteLine();
        PianoScroll.DrawOneOctavePiano(notes);
        Console.WriteLine("\nThe Major Blues Scale:\n");
        Utils.WriteLineCentered(@"C   D Eb E     G   A     C");
        Utils.WriteLineCentered(@"1   2 b3 3     5   6     1");
        Utils.WriteLineCentered(@" \ / ‾  ‾ \ _ / \ / \ _ / ");
        Utils.WriteLineCentered(@"  W  H  H   S    W    S   ");
    });

}

