using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using Strayhorn.Systems.State;
using Strayhorn.Menus;
// using MusicTheory.Letters;
using MusicTheory.Notes;
using MusicTheory.Intervals;

namespace Strayhorn;

class Program
{
    static void Main()
    {
        // TestPitchID(); return;
        Console.Title = "Strayhorn";
        Console.CursorVisible = false;
        Console.ResetColor();
        Console.Clear();

        if (Console.WindowWidth < PianoScroll.TwoOctaveBlank[0].Length + 4)
        {
            DisplayScreenWarning();
            return;
        }

        Logos.PrintIntroCredits();
        Logos.PressAnyKeyToContinue();
        new StateMachine(new MenuState(new MainMenu())).Initialize();
    }

    static void DisplayScreenWarning()
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(
            "WARNING: your console window is too small to properly display graphics.\n" +
            $"Your window is currently {Console.WindowWidth} columns wide, and {Console.WindowHeight} rows tall.\n" +
            $"Resize your window width to at least {PianoScroll.TwoOctaveBlank[0].Length + 4} to avoid this error." +
            "Preferable minimum size is 100 x 35.\n" +
            $"If the window is already full screen, try changing the console resolution with 'cmd' + '-' or '+'.\n" +
            "These options can also be set in the Settings -> Profiles -> Windows tab from the Terminal app menu.");

        Console.ResetColor();
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nThe program will now terminate.");

        Console.ResetColor();
        Console.WriteLine("\n2025 AuralTechGames");

        Environment.Exit(0);
    }

    static void TestPianoAnimation()
    {
        Pitch bottom = new(new Cs(), 3);
        List<Pitch> selected = [new(new E(), 3), new(new Gs(), 3)];
        Pitch Caret = new(new Cs(), 4);

        while (true)
        {
            Console.Clear();
            PianoScroll.DrawTwoOctavePianoQuestionWithCarat(bottom, [.. selected], Caret);
            // Console.WriteLine(Caret.PitchID);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    Pitch lowest = new(new C(), 3);
                    if (Caret.PitchID - 1 == bottom.PitchID || Caret.PitchID - 1 < lowest.PitchID) { continue; }
                    int newChromaticValue = (Caret.Chromatic.Value == 0) ? 11 : (Caret.Chromatic.Value - 1);

                    Caret = new(IPitchClass.GetAll().First(p => p.Chromatic.Value == newChromaticValue),
                                Caret.Octave + (newChromaticValue > Caret.Chromatic.Value ? -1 : 0));
                    break;

                case ConsoleKey.RightArrow:
                    Pitch highest = new(new B(), 4);
                    if (Caret.PitchID + 1 > highest.PitchID) { continue; }
                    newChromaticValue = (Caret.Chromatic.Value + 1) % MusicTheory.Chromatic.Gamut;
                    Caret = new(IPitchClass.GetAll().First(p => p.Chromatic.Value == newChromaticValue),
                                Caret.Octave + (newChromaticValue < Caret.Chromatic.Value ? 1 : 0));
                    break;

                case ConsoleKey.Enter:
                    bool contains = false;
                    foreach (var p in selected)
                    {
                        if (p.PitchID == Caret.PitchID)
                        {
                            selected.Remove(p);
                            contains = true;
                            break;
                        }
                    }
                    if (!contains) selected.Add(Caret);
                    break;

                default: break;
            }
            Console.WriteLine(Caret.PitchID);
        }

        // foreach (var l in MusicTheory.Notes.IPitchClass.GetAll())
        //     Console.WriteLine(l.Name + " " + l.Chromatic.Value);

        // foreach (ILetter letter in ILetter.GetAll())
        // {
        //     foreach (IInterval interval in IInterval.GetAll())
        //     {
        //         var nextLetter = ILetter.GetLetterAbove(letter, interval);
        //         Console.WriteLine(letter.Name + " + " + interval.IntervalAbbrev + " = " + nextLetter.Name);
        //     }
        // }
    }

    static void TestPitchID()
    {
        for (int octave = 3; octave < 5; octave++)
        {
            foreach (MusicTheory.Letters.ILetter letter in MusicTheory.Letters.ILetter.GetAll())
            {
                foreach (IAccidental accidental in IAccidental.GetAll())
                {
                    IPitchClass pitchClass = IPitchClass.GetAll().Single(pc => pc.Accidental.Equals(accidental) && pc.Letter.Equals(letter));
                    Pitch pitch = new(pitchClass, octave);
                    Console.WriteLine(pitch.Name + ", " + pitch.PitchID);
                    // foreach (IStep step in IStep.GetAll())
                    // {
                    //     IPitchClass topPC = IPitchClass.GetPitchClassAbove(pitch.PitchClass, step);
                    //     Pitch top = new(pitchClass: topPC,
                    //         octave: pitch.Octave + (Pitch.GetPitchID(topPC, pitch.Octave) < pitch.PitchID ? 1 : 0));
                    // }
                }
            }
        }
    }
}
