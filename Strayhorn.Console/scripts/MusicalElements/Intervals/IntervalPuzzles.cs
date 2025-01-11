using MusicTheory.Notes;
using MusicTheory.Letters;
using MusicTheory;

namespace Strayhorn.Puzzles;

public class IntervalPuzzle1 : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();
    public int NumOfNotes => 1;
    public List<Pitch> Selected { get; set; } = [];
    public Pitch Bottom { get; }
    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        Selected.Sort();
        foreach (var n in Selected) notes.Add(([n], 750, .7f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetAnswerNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in Notes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.C(), 4);
    public Pitch[]? Playing { get; set; } = null;
    public Pitch[] Notes { get; }
    public string Desc => $"Identify the {Note.PitchClass.Name} note";
    public string Answer => Note.PitchClass.Name;
    public bool HintFlag { get; set; }
    public bool PuzzleComplete { get; set; }
    public string Hint =>
        "D is always between the group with two black keys." +
        "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B";// +

    public IntervalPuzzle1()
    {
        Random random = new();

        var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
        IAccidental accidental = new Natural();

        IPitchClass pitchClass = IPitchClass.Get(letter, accidental);
        int octave = random.Next(3, 5);

        Pitch newPitch = new(pitchClass, octave);

        Gamut = newPitch;
        Notes = [newPitch];
    }

    public void DrawQuestion()
    {
        PianoScroll.DrawTwoOctavePianoQuestionWithCarat(Bottom, [.. Selected], Caret, Playing);
    }

    public bool CheckAnswer()
    {
        if (Selected.Count == 1) return Selected[0].Chromatic == Note.Chromatic;
        return Caret.Chromatic == Note.Chromatic;
    }
}
