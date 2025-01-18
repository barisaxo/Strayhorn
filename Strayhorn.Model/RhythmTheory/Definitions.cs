
namespace MusicTheory.Rhythms
{

    //
    // when you quantize something, it undergoes quantization, and is now quantized.
    // 
    // quantizement is a things current state, or resolution, of quantization.
    // 
    // quanta (plural;  singular: quantum) is the smallest amount something possible can be measured at.
    //
    //     While technically the quantum of rhythmic resolution is infinite,
    //     the use of 64th notes (4 beams) is not unheard of, and 1024th notes have been used by beethoven and mozart.
    //     Those rhythms only make sense at very slow tempos, and almost always seen a straight runs - no syncopation.
    //     For realistic reading and playback reasons with a console controller,
    //     16th notes will be the smallest unit used in this game.


    //    4/4 designations           /                       abstract designations                         
    //    Whole               = 240 / BPM  =  (beat * 4)     M2 (multiples level 2)            
    //    Dotted Half         = 180 / BPM  =  (M1 + beat)    M1  (multiples level 1)              
    //    Half                = 120 / BPM  =  (beat * 2)     M1  (multiples level 1) 
    //    Dotted Quarter      = 90 / BPM   =  (beat + D1)    .Beat (dotted beat) 
    //    Triplet Half        = 80 / BPM   =  (M1 * 2/3)   M1T 
    //    Quarter             = 60 / BPM   =  (beat * 1)     Beat Level  
    //    Dotted eighth       = 45 / BPM   =  (D1 + D2)      .D1  (Dotted 1st division)  
    //    Trip quarter        = 40 / BPM   =  (beat * 2/3)   BT    (Triplet Beat)
    //    Eighth note         = 30 / BPM   =  (beat * 1/2)   D1    (1st division)       
    ////    Dotted Sixteenth    = 22.5 / BPM =  (D2 + D3)      .D2    (2nd division)                
    //    Trip eighth         = 20 / BPM   =  (D1 * 2/3)   D1T   (Triplet 1st division)  
    //    Sixteenth           = 15 / BPM   =  (beat * 1/4)   D2    (2nd division)         
    ////    Trip Sixteenth      = 10 / BPM   =  (beat * 1/6)   D2t  (triplet 2nd division)          
    ////    ThirtySecond        = 7.5 / BPM   =  (beat * 1/8)  D3   (3rd division)       

    //    Cardinal designations : starting at 1 (12 quantum spaces per beat needed to accommodate 16ths and trip8ths)
    //    One = 01 + 00, OneE = 04 + 00, OneT = 05 + 00, OneN = 07 + 00, OneL = 09 + 00, OneA = 10 + 00,
    //    Two = 01 + 12, TwoE = 04 + 12, TwoT = 05 + 12, TwoN = 07 + 12, TwoL = 09 + 12, TwoA = 10 + 12,
    //    Thr = 01 + 24, ThrE = 04 + 24, ThrT = 05 + 24, ThrN = 07 + 24, ThrL = 09 + 24, ThrA = 10 + 24,
    //    For = 01 + 36, ForE = 04 + 36, ForT = 05 + 36, ForN = 07 + 36, ForL = 09 + 36, ForA = 10 + 36
    //    
    //              WHOLE ||1 . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .|| WHOLE
    //               HALF ||1 . . . . . . . . . . . . . . . . . . . . . . . 3 . . . . . . . . . . . . . . . . . . . . . . .|| HALF
    //          TRIP HALF ||1 . . . . . . . . . . . . . . . T . . . . . . . . . . . . . . . L . . . . . . . . . . . . . . .|| TRIP HALF
    //            QUARTER ||1 . . . . . . . . . . . 2 . . . . . . . . . . . 3 . . . . . . . . . . . 4 . . . . . . . . . . .|| QUARTER
    //       TRIP QUARTER ||1 . . . . . . . T . . . . . . . L . . . . . . . 3 . . . . . . . T . . . . . . . L . . . . . . .|| TRIP QUARTER
    //             EIGHTH ||1 . . . . . + . . . . . 2 . . . . . + . . . . . 3 . . . . . + . . . . . 4 . . . . . + . . . . .|| EIGHTH
    //        TRIP EIGHTH ||1 . . . T . . . L . . . 2 . . . T . . . L . . . 3 . . . T . . . L . . . 4 . . . T . . . L . . .|| TRIP EIGHTH
    //          SIXTEENTH ||1 . . e . . + . . a . . 2 . . e . . + . . a . . 3 . . e . . + . . a . . 4 . . e . . + . . a . .|| SIXTEENTH
    //                ALL ||1 . . e T . + . L a . . 2 . . e T . + . L a . . 3 . . e T . + . L a . . 4 . . e T . + . L a . .|| ALL
    // //  TRIP SIXTEENTH ||1 . T . L . + . T . L . 2 . T . L . + . T . L . 3 . T . L . + . T . L . 4 . T . L . + . T . L .|| TRIP SIXTEENTh
    //      quantum space ||1 . . . 5 . . . . 10. . . . 5 . . . . 20. . . . 5 . . . . 30. . . . 5 . . . . 40. . . . 5 . . .|| quantum space


    public enum Quantizement { Half, Quarter, QuarterTrips, Eighth, EighthTrips, Sixteenth }


    // Rhythm Cell Shapes:
    // Duple has 2 shapes: L & LL(or SS relatively)
    // Triple has 4 shapes: TL, TLS, TSL, TSSS
    // Quadruple has 8 shapes: L, LL, SL, LSS, SSL, SLS, SSSS.
    // The first two quadruple cells are not unique as they overlap with the duple cells.
    // public enum CellShape { L, LL, LS, SL, LSS, SSL, SLS, SSSS, TLS, TSL, TSSS, TL, DLL, DL }



    //todo I believe this is where the problem was with different time signatures

    ///<summary> 12 * (2 ^ MetricLevel) * triplet * dot </summary>
    ///<remarks> 12 is arbitrarily the quantum spacing minimum for 16ths </remarks>
    public enum RhythmicValue
    {
        Whole = 48, Half = 24, Quarter = 12, Eighth = 6, Sixteenth = 3,
        DotWhole = 72, DotHalf = 36, DotQuarter = 18, DotEighth = 9,
        TripHalf = 16, TripQuarter = 8, TripEighth = 4,
    }


    /// <summary> Duration modifiers, Triplet = 2/3, augmentation dot = 3/2 </summary>
    public enum DurationModifier { None, Triplet, Dot }


    public enum NoteFunction { Attack, Hold, Rest, Ignore }


    /// <summary>
    /// Beat Level, eg quarters in 4/4 is Beat Level. Eighths is D1 etc.
    /// </summary> 
    public enum MetricLevel { D2 = -2, D1 = -1, Beat = 0, M1 = 1, M2 = 2 }
    //// Unnecessary to define is the 
    //'Multiple Levels' as in the combined beat level eg in 4/4 half = M1 & whole = M2.
    // D1 is the fist division level, eg 8th notes in 4/4
    // D2 is the second division level, eg 16th notes in 4/4.
    // There should be no need to go beyond M2 or D2 in this project, but it can be superimposed.


    /// <summary>
    /// The elements of Metric Structure
    /// </summary>
    public enum PulseStress { Duple = 2, Triple = 3, Quadruple = 4 }


    /// <summary>
    /// Is the first beat division duplet (simple), or triple (compound). All beat levels below first division are duple.
    /// </summary>
    /// <remarks> Unnecessary to define is 'Irregular' as it is a combination of simple and compound, and is implied as such.</remarks>
    public enum BeatDivisor { Simple, Compound }

    /// <summary>
    ///The Top number of a time signature - "How Many".
    /// </summary> 
    public enum Count
    {
        One = 1, Two = 2, Thr = 3, For = 4,
        Fiv = 5, Six = 6, Sev = 7, Eht = 8,
        Nin = 9, Ten = 10, Elv = 11, Tlv = 12
    }


    /// <summary>
    ///The bottom number of a time signature - "Of What".
    /// </summary>
    /// <remarks>Continue on in powers of 2, going beyond 8th notes in this project, but could be superimposed.</remarks>
    public enum SubCount { One = 1, Two = 2, For = 4, Eht = 8 }


    //SubCount * Math.Pow(2, MetricLevel) * CompoundModifier


    // public static class RhythmUtilities
    // {

    // public enum RhythmOption { Ties, Rests, SomeTrips, TripsOnly }
    // public enum SubDivisionTier { BeatOnly, BeatAndD1, D1Only, D1AndD2, D2Only, }
    //     public static Quantizement GetQuantizement(this Time time)
    //     {
    //         return time switch
    //         {
    //             // TwoTwo or
    //             // ThreeTwo => Quantizement.Half,
    //             SixEight or
    //             NineEight or
    //             TwelveEight => Quantizement.EighthTrips,
    //             // ThreeEight or
    //             // FiveEight23 or
    //             // FiveEight32 or
    //             // SevenEight34 or
    //             // SevenEight43 
    //             // => Quantizement.Eighth,
    //             _ => Quantizement.Quarter,
    //         };
    //     }
    // }

}



