using Strayhorn.Systems.State;
using MusicTheory.Notes;
namespace Strayhorn.Practice;

public class PracticeState : IState
{
    private readonly Func<IState> _getState;
    public IState GetState => _getState();
    public IPuzzle Puzzle { get; }

    public PracticeState(Func<IPuzzle> getPuzzle, Func<IState> getState)
    {
        _getState = getState;
        Puzzle = getPuzzle();

        if (Puzzle.PuzzleType == PuzzleType.Theory) return;

        Puzzle.PrintDesc();
        PlayQuestion();
    }

    public IState Engage()
    {
        Puzzle.PrintDesc();

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.LeftArrow:
                if (Puzzle.Caret.PitchID - 1 == Puzzle.BottomNote.PitchID ||
                    Puzzle.Caret.PitchID - 1 < Pitch.GetPitchID(new C(), 3))
                    return this;

                int newChromaticValue = (Puzzle.Caret.Chromatic.Value == 0) ? 11 : (Puzzle.Caret.Chromatic.Value - 1);
                Puzzle.Caret = new(IPitchClass.GetAll().First(p => p.Chromatic.Value == newChromaticValue),
                            Puzzle.Caret.Octave + (newChromaticValue > Puzzle.Caret.Chromatic.Value ? -1 : 0));
                return this;

            case ConsoleKey.RightArrow:
                if (Puzzle.Caret.PitchID + 1 > Pitch.GetPitchID(new B(), 4))
                    return this;

                newChromaticValue = (Puzzle.Caret.Chromatic.Value + 1) % MusicTheory.Chromatic.Gamut;
                Puzzle.Caret = new(IPitchClass.GetAll().First(p => p.Chromatic.Value == newChromaticValue),
                            Puzzle.Caret.Octave + (newChromaticValue < Puzzle.Caret.Chromatic.Value ? 1 : 0));
                return this;

            case ConsoleKey.Spacebar:
                if (Puzzle.SelectedNotes.Count > 0) PlaySelectedNotes();
                return this;

            case ConsoleKey.UpArrow:
                PlayCaretNote();
                return this;

            case ConsoleKey.DownArrow:
                foreach (var p in Puzzle.SelectedNotes)
                {
                    if (p.PitchID == Puzzle.Caret.PitchID)
                    {
                        Puzzle.SelectedNotes.Remove(p);
                        return this;
                    }
                }

                if (Puzzle.SelectedNotes.Count < Puzzle.NumOfNotes) Puzzle.SelectedNotes.Add(Puzzle.Caret);
                return this;

            case ConsoleKey.H:
                Puzzle.ShouldHintDisplay = !Puzzle.ShouldHintDisplay;
                break;

            case ConsoleKey.Tab:
                PlayQuestion();
                return this;

            case ConsoleKey.Q:
                return GetState;

            case ConsoleKey.Enter:
                if (!Puzzle.AnswerIsValid)
                {
                    Console.Beep();
                    return this;
                }
                Puzzle.ShouldHintDisplay = true;
                Puzzle.PuzzleIsComplete = true;
                PlayAnswer();
                Puzzle.PrintDesc();
                Logos.PressAnyKeyToContinue();
                return GetState;
        }

        return this;
    }

    void PlayCaretNote()
    {
        StateMachine.BlockInput = true;
        Puzzle.ActiveNotes = [Puzzle.Caret];
        AudioGenerator.PlayAudio([([Puzzle.Caret], 750, .5f)],
          async () =>
          {
              Puzzle.PrintDesc();
              await Task.Delay(750);
              Puzzle.ActiveNotes = null;
          });
        StateMachine.BlockInput = false;
    }

    void PlaySelectedNotes()
    {
        StateMachine.BlockInput = true;
        var notes = Puzzle.GetSelectedNotesToPlay();
        AudioGenerator.PlayAudio(notes, async () =>
        {
            foreach (var (pitches, durationMS, amp) in notes)
            {
                Puzzle.ActiveNotes = pitches;
                Puzzle.PrintDesc();
                await Task.Delay(durationMS);
            }
            Puzzle.ActiveNotes = null;
        });
        StateMachine.BlockInput = false;
    }

    /// <summary>
    /// Play the puzzle audio, but do not play the animation as to not give away the answer.
    /// </summary>
    void PlayQuestion()
    {
        StateMachine.BlockInput = true;
        AudioGenerator.PlayAudio(Puzzle.GetPuzzleNotesToPlay(), () =>
        {
            Puzzle.ActiveNotes = null;
        });
        StateMachine.BlockInput = false;
    }

    /// <summary>
    /// Play answer at the end of every puzzle.
    /// </summary>
    void PlayAnswer()
    {
        StateMachine.BlockInput = true;
        var notes = Puzzle.GetPuzzleNotesToPlay();
        AudioGenerator.PlayAudio(notes, async () =>
        {
            foreach (var (pitches, durationMS, amp) in notes)
            {
                Puzzle.ActiveNotes = pitches;
                Puzzle.PrintDesc();
                await Task.Delay(durationMS);
            }
            Puzzle.ActiveNotes = null;
        });
        StateMachine.BlockInput = false;
    }

}
