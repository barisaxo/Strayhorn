using MusicTheory.Notes;
using MusicTheory;

namespace Strayhorn.Practice;

public class NotePuzzle : IPuzzle
{
    public IMusicalElement Gamut { get; }
    public Pitch Note => Gamut is Pitch note ? note : throw new System.ArgumentNullException();

    public PuzzleType PuzzleType { get; }
    public int NumOfNotes => 1;
    public List<Pitch> SelectedNotes { get; set; } = [];
    public Pitch BottomNote { get; }
    public Pitch Caret { get; set; } = new(new MusicTheory.Notes.D(), 4);
    public Pitch[]? ActiveNotes { get; set; }
    public Pitch[] PuzzleNotes { get; }

    public (Pitch[] pitches, int durationMS, float amp)[] GetSelectedNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        SelectedNotes.Sort();
        foreach (var n in SelectedNotes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }
    public (Pitch[] pitches, int durationMS, float amp)[] GetPuzzleNotesToPlay()
    {
        List<(Pitch[], int, float)> notes = [];
        foreach (var n in PuzzleNotes) notes.Add(([n], 750, .7f));
        return [.. notes];
    }

    public string Desc => $"Identify the{(PuzzleType is PuzzleType.Theory ? " " + Note.PitchClass.Name + " " : " ")}note";
    public bool PuzzleIsComplete { get; set; }
    public bool ShouldHintDisplay { get; set; }
    public string Hint => "D is always between the group with two black keys." +
                        "\nThe notes of the keyboard: C_D_EF_G_A_BC_D_EF_G_A_B" +
                        "\nSharp (#) = +1.   Flat (b) = -1.";

    public bool CheckAnswer()
    {
        return SelectedNotes[0].Chromatic == Note.Chromatic;
    }

    public NotePuzzle(PuzzleType puzzleType, IPitchClass pitchClass)
    {
        PuzzleType = puzzleType;
        int octave;
        if (pitchClass.Letter is MusicTheory.Letters.C && pitchClass.Accidental is Flat or DoubleFlat) octave = 4;
        else if (pitchClass.Letter is MusicTheory.Letters.B && pitchClass.Accidental is Sharp or DoubleSharp) octave = 3;
        else octave = new Random().Next(3, 5);
        Gamut = new Pitch(pitchClass: pitchClass, octave);
        PuzzleNotes = [Note];
    }
}