using Strayhorn.Systems.State;
using MusicTheory.Notes;
namespace Strayhorn.Puzzles;

public class PuzzleState(Func<IPuzzle> getPuzzle, Func<IState> getState) : IState
{
    public Func<IState> GetState = getState;
    public IPuzzle Puzzle = getPuzzle();

    public IState Engage()
    {
        Puzzle.PrintDesc();

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.LeftArrow:

                Pitch lowest = new(new C(), 3);
                if (Puzzle.Carat.PitchID - 1 == Puzzle.Bottom.PitchID || Puzzle.Carat.PitchID - 1 < lowest.PitchID)
                    return this;

                int newChromaticValue = (Puzzle.Carat.Chromatic.Value == 0) ? 11 : (Puzzle.Carat.Chromatic.Value - 1);
                Puzzle.Carat = new(IPitchClass.GetAll().First(p => p.Chromatic.Value == newChromaticValue),
                            Puzzle.Carat.Octave + (newChromaticValue > Puzzle.Carat.Chromatic.Value ? -1 : 0));
                return this;

            case ConsoleKey.RightArrow:

                Pitch highest = new(new B(), 4);
                if (Puzzle.Carat.PitchID + 1 > highest.PitchID) return this;

                newChromaticValue = (Puzzle.Carat.Chromatic.Value + 1) % MusicTheory.Chromatic.Gamut;
                Puzzle.Carat = new(IPitchClass.GetAll().First(p => p.Chromatic.Value == newChromaticValue),
                            Puzzle.Carat.Octave + (newChromaticValue < Puzzle.Carat.Chromatic.Value ? 1 : 0));
                return this;

            case ConsoleKey.Spacebar:
                if (Puzzle.Selected.Count > 0) PlayAll();
                return this;

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

            case ConsoleKey.UpArrow:
                PlaySingle();
                return this;

                void PlaySingle()
                {
                    StateMachine.BlockInput = true;
                    Puzzle.Playing = [Puzzle.Carat];
                    AudioGenerator.PlayAudio([([Puzzle.Carat], 750, .5f)],
                      async () =>
                      {
                          Puzzle.PrintDesc();
                          await Task.Delay(750);
                          Puzzle.Playing = null;
                      });
                    StateMachine.BlockInput = false;
                }

            case ConsoleKey.DownArrow:
                bool contains = false;
                foreach (var p in Puzzle.Selected)
                {
                    if (p.PitchID == Puzzle.Carat.PitchID)
                    {
                        Puzzle.Selected.Remove(p);
                        contains = true;
                        break;
                    }
                }

                if (Puzzle.Selected.Count < Puzzle.NumOfNotes && !contains) Puzzle.Selected.Add(Puzzle.Carat);
                return this;

            case ConsoleKey.Enter:
                if (!Puzzle.ValidateAnswer()) { Console.Beep(); return this; }

                Puzzle.PuzzleComplete = true;
                PlayAnswer();
                Puzzle.PrintDesc();
                Logos.PressAnyKeyToContinue();
                return GetState();

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

            case ConsoleKey.H:
                Puzzle.HintFlag = !Puzzle.HintFlag;
                break;

            case ConsoleKey.Tab:
                PlayQuestion();
                return this;

                void PlayQuestion()
                {
                    StateMachine.BlockInput = true;
                    AudioGenerator.PlayAudio(Puzzle.GetAnswerNotesToPlay(), () =>
                    {
                        Puzzle.Playing = null;
                    });
                    StateMachine.BlockInput = false;
                }

            case ConsoleKey.Q:
                return GetState();

        }

        return this;
    }
}
