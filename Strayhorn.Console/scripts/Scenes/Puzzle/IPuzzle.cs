using System;
using MusicTheory;
using MusicTheory.Notes;
using Strayhorn.Utility;

namespace Strayhorn.Practice;

public enum PuzzleType { Theory, Aural }

public interface IPuzzle
{
    /// <summary> The <c>IMusicalElement</c> puzzle-type, ie <c>Note</c>, <c>Interval</c>, <c>Chord</c>, <c>Scale</c>, etc.</summary>
    /// <remarks>
    /// Gamut: a complete scale of musical notes; the compass or range of a voice or instrument. 
    /// (From Latin: gamma ut (later 'Do'). Low G (gamma), lowest note to the highest note (ut / Do) in the medieval musical scale - devised by Guido d'Arezzo.)
    /// </remarks>
    public IMusicalElement Gamut { get; }

    /// <summary>Theory or Aural puzzle types. Aural types you have to solve by ear.</summary>
    public PuzzleType PuzzleType { get; }

    /// <summary>How many notes must be selected to have a valid answer.</summary> 
    public int NumOfNotes { get; }

    /// <summary>The question/answer notes of the puzzle.</summary>
    public Pitch[] PuzzleNotes { get; }

    /// <summary>Notes that the user has selected, including any bottom note the puzzle may have.</summary>
    public List<Pitch> SelectedNotes { get; }

    /// <summary>Most puzzles need a bottom note to provide context.</summary>
    public Pitch BottomNote { get; }

    /// <summary>Notes that are currently being audibly played, and animated on the piano.</summary>
    public Pitch[]? ActiveNotes { get; set; }

    /// <summary>Formats currently selected notes for the audio generator and piano animations.</summary>
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay();

    /// <summary>Formats the question/answer notes for the audio generator and piano animations.</summary>
    public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay();

    /// <summary>The users current position on the keyboard - the cursor. </summary>
    /// <remarks>Yellow for position, green for position and note is selected.</remarks>
    public Pitch Caret { get; set; }

    /// <summary>Puzzle description / instructions.</summary>
    public string Desc { get; }

    /// <summary>Provide the user with a puzzle hint.</summary>
    public string Hint { get; }

    /// <summary>When true, the hint is displayed.</summary>
    public bool ShouldHintDisplay { get; set; }

    /// <summary>Flags the state that the puzzle is complete.</summary>
    public bool PuzzleIsComplete { get; set; }

    /// <summary>Must be true for user to submit their answer. </summary>
    public bool AnswerIsValid => SelectedNotes.Count == NumOfNotes;

    /// <summary>Checks the users submitted answer.</summary>
    public bool CheckAnswer();

    /// <summary>Display the question on screen.</summary>
    public void DrawQuestion() =>
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(BottomNote, [.. SelectedNotes], Caret, ActiveNotes);

    public void PrintDesc()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine(Desc);

        Console.WriteLine("\n");
        Console.ResetColor();
        DrawQuestion();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("use ← → to navigate caret");
        Console.WriteLine("press ↑ to play caret note");
        Console.WriteLine("press ↓ to select/unselect note");
        Console.WriteLine("press 'space' to play selected notes");
        Console.WriteLine("press 'tab' to listen to the question");
        Console.WriteLine("press 'h' for a hint");
        Console.WriteLine("press 'q' to quit Practice");

        if (AnswerIsValid)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("press 'enter' to submit answer");
        }

        if (ShouldHintDisplay)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Hint:\n" + Hint);
        }

        if (PuzzleIsComplete)
        {
            if (CheckAnswer())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("That is correct!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"That is incorrect.");
            }
        }
        Console.ResetColor();
    }
}
