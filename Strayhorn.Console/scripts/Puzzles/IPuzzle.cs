using System;
using MusicTheory;
using MusicTheory.Notes;
using Strayhorn.Systems.Commands;

namespace Strayhorn.Puzzles;

public interface IPuzzle
{/*Gamut: a complete scale of musical notes; the compass or range of a voice or instrument.*/
    public IMusicalElement Gamut { get; }
    public int NumOfNotes { get; }
    public string Desc { get; }
    public string PuzzleGamut { get; }
    public string Question { get; }
    public string Hint { get; }
    public Pitch[] Notes { get; }

    public string Arg { get; set; }
    public string ValidationError { get; }
    public static string CorrectAnswer => "That is correct!";
    public string IncorrectAnswer => $"That is incorrect. The answer is {Question}";

    // public bool AllowPlayQuestion { get; }
}

public class PuzzleState : ICommand
{
    readonly IPuzzle Puzzle;

    public PuzzleState(IPuzzle puzzle,
        ICommand prev,
        string desc = "",
        string triggerString = "",
        ConsoleKey triggerKey = ConsoleKey.None)
    {
        Puzzle = puzzle;
        Finish = finish;
        prev.TriggerKey = ConsoleKey.LeftArrow;
        Commands = [
            prev,
            new NotesPuzzleTutorialP2(Finish, this, "", "", ConsoleKey.RightArrow)
        ];

        Desc = desc;
        TriggerString = triggerString;
        TriggerKey = triggerKey;
    }

    public bool DisplayInput { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public ICommand[] Commands => throw new NotImplementedException();

    public TriggerType TriggerType => throw new NotImplementedException();

    public string Desc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string TriggerString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ConsoleKey TriggerKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Execute()
    {
        throw new NotImplementedException();
    }
}