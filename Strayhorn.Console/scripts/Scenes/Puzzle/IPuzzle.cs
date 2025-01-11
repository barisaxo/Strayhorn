using System;
using MusicTheory;
using MusicTheory.Notes;
using Strayhorn.Utility;

namespace Strayhorn.Puzzles;

public interface IPuzzle
{
    public int NumOfNotes { get; }
    // public string PuzzleGamut { get; }

    /// <summary>
    /// Gamut: a complete scale of musical notes; the compass or range of a voice or instrument. 
    /// From Latin: gamma ut (later 'Do'). Low G, lowest note in the medieval musical scale - devised by Guido d'Arezzo.
    /// </summary>
    public IMusicalElement Gamut { get; }
    public Pitch[] Notes { get; }
    public List<Pitch> Selected { get; }
    public Pitch Bottom { get; }
    public Pitch[]? Playing { get; set; }
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay();
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay();
    public Pitch Carat { get; set; }
    public string Desc { get; }
    public string Hint { get; }
    public bool HintFlag { get; set; }
    public bool PuzzleComplete { get; set; }

    // public string Answer { get; }
    // public string AnswerFormatValidation { get; }
    // public string ValidationError { get; }

    public bool ValidateAnswer() => Selected.Count == NumOfNotes;
    // public bool CheckAnswer(string arg);
    public bool CheckAnswer();
    public void DrawQuestion();
    public void PrintDesc()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine(Desc);

        Console.WriteLine("\n\n");
        Console.ResetColor();
        DrawQuestion();

        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        // Console.WriteLine(AnswerFormatValidation);
        Console.WriteLine("use ← → to navigate caret");
        Console.WriteLine("press ↑ to play caret note");
        Console.WriteLine("press ↓ to select/unselect note");
        Console.WriteLine("press 'space' to play selected notes");
        Console.WriteLine("press 'tab' to listen to the question");
        Console.WriteLine("press 'h' for a hint");
        Console.WriteLine("press 'q' to quit puzzle");
        if (ValidateAnswer()) Console.WriteLine("press 'enter' to submit answer");

        if (HintFlag)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Hint:\n" + Hint);
        }

        if (PuzzleComplete)
        {
            if (CheckAnswer())//TODO
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
