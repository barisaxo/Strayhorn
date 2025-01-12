using Strayhorn.Systems.State;
using MusicTheory.Notes;
namespace Strayhorn.Practice;

public class PracticeState(Func<IPractice> getPractice, Func<IState> getState) : IState
{
    public IState GetState = getState();
    public IPractice Practice = getPractice();

    public IState Engage()
    {
        Practice.PrintDesc();

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.LeftArrow:
                if (Practice.Caret.PitchID - 1 == Practice.Bottom.PitchID ||
                    Practice.Caret.PitchID - 1 < Pitch.GetPitchID(new C(), 3))
                    return this;

                int newChromaticValue = (Practice.Caret.Chromatic.Value == 0) ? 11 : (Practice.Caret.Chromatic.Value - 1);
                Practice.Caret = new(IPitchClass.GetAll().First(p => p.Chromatic.Value == newChromaticValue),
                            Practice.Caret.Octave + (newChromaticValue > Practice.Caret.Chromatic.Value ? -1 : 0));
                return this;

            case ConsoleKey.RightArrow:
                if (Practice.Caret.PitchID + 1 > Pitch.GetPitchID(new B(), 4))
                    return this;

                newChromaticValue = (Practice.Caret.Chromatic.Value + 1) % MusicTheory.Chromatic.Gamut;
                Practice.Caret = new(IPitchClass.GetAll().First(p => p.Chromatic.Value == newChromaticValue),
                            Practice.Caret.Octave + (newChromaticValue < Practice.Caret.Chromatic.Value ? 1 : 0));
                return this;

            case ConsoleKey.Spacebar:
                if (Practice.Selected.Count > 0) PlayAll();
                return this;

            case ConsoleKey.UpArrow:
                PlayCaret();
                return this;

            case ConsoleKey.DownArrow:
                foreach (var p in Practice.Selected)
                {
                    if (p.PitchID == Practice.Caret.PitchID)
                    {
                        Practice.Selected.Remove(p);
                        return this;
                    }
                }
                if (Practice.Selected.Count < Practice.NumOfNotes) Practice.Selected.Add(Practice.Caret);
                return this;

            case ConsoleKey.H:
                Practice.HintFlag = !Practice.HintFlag;
                break;

            case ConsoleKey.Tab:
                PlayQuestion();
                return this;

            case ConsoleKey.Q:
                return GetState;

            case ConsoleKey.Enter:
                if (!Practice.ValidateAnswer())
                {
                    Console.Beep();
                    return this;
                }

                Practice.PracticeComplete = true;
                PlayAnswer();
                Practice.PrintDesc();
                Logos.PressAnyKeyToContinue();
                return GetState;
        }

        return this;
    }

    void PlayCaret()
    {
        StateMachine.BlockInput = true;
        Practice.Playing = [Practice.Caret];
        AudioGenerator.PlayAudio([([Practice.Caret], 750, .5f)],
          async () =>
          {
              Practice.PrintDesc();
              await Task.Delay(750);
              Practice.Playing = null;
          });
        StateMachine.BlockInput = false;
    }

    void PlayAll()
    {
        StateMachine.BlockInput = true;
        var notes = Practice.GetSelectedNotesToPlay();
        AudioGenerator.PlayAudio(notes, async () =>
        {
            foreach (var (pitches, durationMS, amp) in notes)
            {
                Practice.Playing = pitches;
                Practice.PrintDesc();
                await Task.Delay(durationMS);
            }
            Practice.Playing = null;
        });
        StateMachine.BlockInput = false;
    }

    void PlayQuestion()
    {
        StateMachine.BlockInput = true;
        AudioGenerator.PlayAudio(Practice.GetAnswerNotesToPlay(), () =>
        {
            Practice.Playing = null;
        });
        StateMachine.BlockInput = false;
    }

    void PlayAnswer()
    {
        StateMachine.BlockInput = true;
        var notes = Practice.GetAnswerNotesToPlay();
        AudioGenerator.PlayAudio(notes, async () =>
        {
            foreach (var (pitches, durationMS, amp) in notes)
            {
                Practice.Playing = pitches;
                Practice.PrintDesc();
                await Task.Delay(durationMS);
            }
            Practice.Playing = null;
        });
        StateMachine.BlockInput = false;
    }

}
