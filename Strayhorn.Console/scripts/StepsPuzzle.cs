// using MusicTheory.Intervals;
// using MusicTheory.Notes;
// using MusicTheory.Letters;
// using Strayhorn.Menus;

// namespace Strayhorn.Puzzles.Steps;

// public class StepsPuzzle //: IMenu
// {
//     // public MenuItem[] MenuItems => [
//     //     new("0", "About Notes", AboutSteps),
//     //     new("1", "White Keys, H & W", () => Level1(null, null)),
//     //     new("2", "All Keys, H & W", () => Level2(null, null)),
//     //     new("3", "All Keys, H, W, & S",() => Level2(null, null)),
//     //     // new("4", "Natural and Accidentals", HardNotes),
//     //     new("x", "Back to menu",() => MenuSystems.ActivateMenu(new MainMenu(), null)),
//     //     ];


//     void AboutSteps()
//     {
//         Console.Clear();

//         PianoScroll.DrawTwoOctavePiano();
//         Console.WriteLine("");
//         Console.WriteLine("A Step is a type of interval for adjacent letters.");
//         Console.WriteLine("Stepwise motion is defined as moving melodically up or down by letter.");
//         Console.WriteLine("The type of step is determined by the distance of the two notes");
//         Console.WriteLine("There are three types of steps: Half-Step (+1), Whole-Step (+2), and Skip-Step (+3).");
//         Console.WriteLine("To abbreviate, we use 'H', 'W', and 'S' respectively.");
//         Console.WriteLine("");

//         Console.WriteLine("(press any key to continue...)");
//         Console.ReadKey(true);
//         Console.WriteLine("");

//         Console.WriteLine("The letters 'B & C', and 'E & F' make Half-Steps.");
//         Console.WriteLine("You should remember from the Notes lesson that 'B & C',");
//         Console.WriteLine("and 'E & F' are the keys on the piano that do not have a black key between them.");
//         Console.WriteLine("All other adjacent letters make Whole-Steps.");
//         Console.WriteLine("Steps are used in succession to make up scales like this:");
//         Console.WriteLine("W W H W W W H (the major scale)");
//         Console.WriteLine("");
//         Console.WriteLine("Skips are used with Pentatonic scales, and some other scales like Harmonic Minor.");
//         Console.WriteLine("");
//         Console.WriteLine("(press any key to continue...)");
//         Console.ReadKey(true);
//         MenuSystems.ActivateMenu(this, null);
//     }

//     void Level1((Pitch[]? notes, IStep? step)? question, string? answer)
//     {
//         //Generate a new question
//         if (question == null)
//         {
//             Random random = new();

//             var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//             Pitch bottom = new(pitchClass: IPitchClass.Get(letter, new Natural()), octave: 3);

//             letter = ILetter.GetNextLetter(bottom.PitchClass.Letter);
//             Pitch top = new(pitchClass: IPitchClass.Get(letter, new Natural()),
//                 octave: letter is MusicTheory.Letters.C ? 4 : 3);

//             var step = IStep.GetStep(bottom.PitchClass.Letter, top.PitchClass.Letter);
//             question = ([bottom, top], step);
//         }


//         //Print the question & get user answer
//         PrintQuestion(question);
//         if (answer == null)
//         {
//             //Recursion here for cleaner presentation
//             Level1(question, Console.ReadLine());
//             return;
//         }
//         Console.WriteLine($"You answered: {answer}");


//         //Validate answer format
//         if (answer != "H" && answer != "W" && answer != "h" && answer != "w")
//         {
//             Console.WriteLine("Invalid answer. Please answer 'H' or 'W'.");
//             Level1(question, Console.ReadLine());
//             return;
//         }


//         //Check if the answer is correct and finish
//         bool result = answer switch
//         {
//             "H" or "h" => question?.step is H,
//             "W" or "w" => question?.step is W,
//             _ => false
//         };

//         FinishPuzzle(result, question?.step?.Name);
//     }

//     void Level2((Pitch[]? notes, IStep? step)? question, string? answer)
//     {
//         //Generate a new question
//         if (question == null)
//         {
//             Random random = new();
//             IAccidental[] accidentals = [new Sharp(), new Flat(), new Natural()];
//             var letter = ILetter.GetAll().ToList()[random.Next(0, ILetter.GetAll().Count())];
//             IAccidental accidental = accidentals[random.Next(0, 3)];
//             Pitch bottom = new(
//                 pitchClass: IPitchClass.Get(letter, accidental),
//                 octave: letter is MusicTheory.Letters.C && accidental is Flat ? 4 : 3);

//             var step = IStep.GetAll().ToList()[random.Next(0, 2)];

//             IPitchClass topPC = IPitchClass.GetStepAbove(bottom.PitchClass, step);
//             Pitch top = new(
//                 pitchClass: topPC,
//                 octave: topPC.Chromatic.Value < bottom.Chromatic.Value ? bottom.Octave + 1 : bottom.Octave);

//             question = ([bottom, top], step);
//         }


//         //Print the question & get user answer
//         PrintQuestion(question);
//         if (answer == null)
//         {
//             //Recursion here for cleaner presentation
//             Level2(question, Console.ReadLine());
//             return;
//         }
//         Console.WriteLine($"You answered: {answer}");


//         //Validate answer format
//         if (answer != "H" && answer != "W" && answer != "h" && answer != "w")
//         {
//             Console.WriteLine("Invalid answer. Please answer 'H' or 'W'.");
//             Level2(question, Console.ReadLine());
//             return;
//         }


//         //Check if the answer is correct and finish
//         bool result = answer switch
//         {
//             "H" or "h" => question?.step is H,
//             "W" or "w" => question?.step is W,
//             _ => false
//         };

//         FinishPuzzle(result, question?.step?.Name);
//     }


//     static void PrintQuestion((Pitch[]? notes, IStep? step)? question, bool withSkips = false)
//     {
//         Console.Clear();
//         Console.WriteLine("");
//         Console.WriteLine($"What type of step is {question?.notes?[0].PitchClass.Name} to {question?.notes?[1].PitchClass.Name}?"); // shown
//         Console.WriteLine("H: (Half-Step = +1)");
//         Console.WriteLine("W: (Whole-Step = +2)");
//         if (withSkips) Console.WriteLine("S: (Skip-Step = +3)");
//         PianoScroll.DrawTwoOctaveQuestion(question?.notes);
//         Console.WriteLine("");
//     }

//     // void FinishPuzzle(bool result = true, string? message = null)
//     // {
//     //     Console.WriteLine("");
//     //     Console.WriteLine(result ? "That is correct!" : $"That is incorrect. The answer is {message}");
//     //     Console.WriteLine("(press any key to continue...)");
//     //     Console.ReadKey(true);
//     //     MenuSystems.ActivateMenu(this, null);
//     // }

//     // void MediumSteps()
//     // {
//     //     Console.WriteLine("");
//     //     Console.WriteLine("Not Yet Implemented (press any key to continue...)");
//     //     Console.ReadKey(true);
//     //     MenuSystems.ActivateMenu(this, null);
//     // }

//     // void HardSteps()
//     // {
//     //     Console.WriteLine("");
//     //     Console.WriteLine("Not Yet Implemented (press any key to continue...)");
//     //     Console.ReadKey(true);
//     //     MenuSystems.ActivateMenu(this, null);
//     // }


// }
