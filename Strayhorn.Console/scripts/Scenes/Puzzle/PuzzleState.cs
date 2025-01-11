using Strayhorn.Systems.State;
using MusicTheory.Notes;
namespace Strayhorn.Puzzles;

public class PuzzleState(Func<IPuzzle> getPuzzle, Func<IState> getState) : IState
{
    public IState GetState = getState();
    public IPuzzle Puzzle = getPuzzle();

    public IState Engage()
    {
        Puzzle.PrintDesc();

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.LeftArrow:
                if (Puzzle.Caret.PitchID - 1 == Puzzle.Bottom.PitchID ||
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
                if (Puzzle.Selected.Count > 0) PlayAll();
                return this;

            case ConsoleKey.UpArrow:
                PlayCaret();
                return this;

            case ConsoleKey.DownArrow:
                foreach (var p in Puzzle.Selected)
                {
                    if (p.PitchID == Puzzle.Caret.PitchID)
                    {
                        Puzzle.Selected.Remove(p);
                        return this;
                    }
                }
                if (Puzzle.Selected.Count < Puzzle.NumOfNotes) Puzzle.Selected.Add(Puzzle.Caret);
                return this;

            case ConsoleKey.H:
                Puzzle.HintFlag = !Puzzle.HintFlag;
                break;

            case ConsoleKey.Tab:
                PlayQuestion();
                return this;

            case ConsoleKey.Q:
                return GetState;

            case ConsoleKey.Enter:
                if (!Puzzle.ValidateAnswer())
                {
                    Console.Beep();
                    return this;
                }

                Puzzle.PuzzleComplete = true;
                PlayAnswer();
                Puzzle.PrintDesc();
                Logos.PressAnyKeyToContinue();
                return GetState;
        }

        return this;
    }

    void PlayCaret()
    {
        StateMachine.BlockInput = true;
        Puzzle.Playing = [Puzzle.Caret];
        AudioGenerator.PlayAudio([([Puzzle.Caret], 750, .5f)],
          async () =>
          {
              Puzzle.PrintDesc();
              await Task.Delay(750);
              Puzzle.Playing = null;
          });
        StateMachine.BlockInput = false;
    }

    void PlayAll()
    {
        StateMachine.BlockInput = true;
        var notes = Puzzle.GetSelectedNotesToPlay();
        AudioGenerator.PlayAudio(notes, async () =>
        {
            foreach (var (pitches, durationMS, amp) in notes)
            {
                Puzzle.Playing = pitches;
                Puzzle.PrintDesc();
                await Task.Delay(durationMS);
            }
            Puzzle.Playing = null;
        });
        StateMachine.BlockInput = false;
    }

    void PlayQuestion()
    {
        StateMachine.BlockInput = true;
        AudioGenerator.PlayAudio(Puzzle.GetAnswerNotesToPlay(), () =>
        {
            Puzzle.Playing = null;
        });
        StateMachine.BlockInput = false;
    }

    void PlayAnswer()
    {
        StateMachine.BlockInput = true;
        var notes = Puzzle.GetAnswerNotesToPlay();
        AudioGenerator.PlayAudio(notes, async () =>
        {
            foreach (var (pitches, durationMS, amp) in notes)
            {
                Puzzle.Playing = pitches;
                Puzzle.PrintDesc();
                await Task.Delay(durationMS);
            }
            Puzzle.Playing = null;
        });
        StateMachine.BlockInput = false;
    }

}
