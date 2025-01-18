namespace MusicTheory;
using MusicTheory.Notes;

public static class Frequencies
{
    const double A440 = 440;

    public static double GetFrequency(this Pitch pitch)
    {
        Pitch A4 = new(new A(), 4);
        double offset = pitch.PitchID - A4.PitchID;
        return A440 * Math.Pow(2, offset / 12.0);
    }

    public const double C0 = 16.35;
    public const double Cs0 = 17.32;
    public const double Db0 = 17.32;
    public const double D0 = 18.35;
    public const double Ds0 = 19.45;
    public const double Eb0 = 19.45;
    public const double E0 = 20.60;
    public const double F0 = 21.83;
    public const double Fs0 = 23.12;
    public const double Gb0 = 23.12;
    public const double G0 = 24.50;
    public const double Gs0 = 25.96;
    public const double Ab0 = 25.96;
    public const double A0 = 27.50;
    public const double As0 = 29.14;
    public const double Bb0 = 29.14;
    public const double B0 = 30.87;

    public const double C1 = 32.70;
    public const double Cs1 = 34.65;
    public const double Db1 = 34.65;
    public const double D1 = 36.71;
    public const double Ds1 = 38.89;
    public const double Eb1 = 38.89;
    public const double E1 = 41.20;
    public const double F1 = 43.65;
    public const double Fs1 = 46.25;
    public const double Gb1 = 46.25;
    public const double G1 = 49.00;
    public const double Gs1 = 51.91;
    public const double Ab1 = 51.91;
    public const double A1 = 55.00;
    public const double As1 = 58.27;
    public const double Bb1 = 58.27;
    public const double B1 = 61.74;

    public const double C2 = 65.41;
    public const double Cs2 = 69.30;
    public const double Db2 = 69.30;
    public const double D2 = 73.42;
    public const double Ds2 = 77.78;
    public const double Eb2 = 77.78;
    public const double E2 = 82.41;
    public const double F2 = 87.31;
    public const double Fs2 = 92.50;
    public const double Gb2 = 92.50;
    public const double G2 = 98.00;
    public const double Gs2 = 103.83;
    public const double Ab2 = 103.83;
    public const double A2 = 110.00;
    public const double As2 = 116.54;
    public const double Bb2 = 116.54;
    public const double B2 = 123.47;

    public const double C3 = 130.81;
    public const double Cs3 = 138.59;
    public const double Db3 = 138.59;
    public const double D3 = 146.83;
    public const double Ds3 = 155.56;
    public const double Eb3 = 155.56;
    public const double E3 = 164.81;
    public const double F3 = 174.61;
    public const double Fs3 = 185.00;
    public const double Gb3 = 185.00;
    public const double G3 = 196.00;
    public const double Gs3 = 207.65;
    public const double Ab3 = 207.65;
    public const double A3 = 220.00;
    public const double As3 = 233.08;
    public const double Bb3 = 233.08;
    public const double B3 = 246.94;

    /// <summary> Middle C </summary>
    public const double C4 = 261.63;
    public const double Cs4 = 277.18;
    public const double Db4 = 277.18;
    public const double D4 = 293.66;
    public const double Ds4 = 311.13;
    public const double Eb4 = 311.13;
    public const double E4 = 329.63;
    public const double F4 = 349.23;
    public const double Fs4 = 369.99;
    public const double Gb4 = 369.99;
    public const double G4 = 392.00;
    public const double Gs4 = 415.30;
    public const double Ab4 = 415.30;
    public const double A4 = 440.00;
    public const double As4 = 466.16;
    public const double Bb4 = 466.16;
    public const double B4 = 493.88;

    public const double C5 = 523.25;
    public const double Cs5 = 554.37;
    public const double Db5 = 554.37;
    public const double D5 = 587.33;
    public const double Ds5 = 622.25;
    public const double Eb5 = 622.25;
    public const double E5 = 659.25;
    public const double F5 = 698.46;
    public const double Fs5 = 739.99;
    public const double Gb5 = 739.99;
    public const double G5 = 783.99;
    public const double Gs5 = 830.61;
    public const double Ab5 = 830.61;
    public const double A5 = 880.00;
    public const double As5 = 932.33;
    public const double Bb5 = 932.33;
    public const double B5 = 987.77;

    public const double C6 = 1046.50;
    public const double Cs6 = 1108.73;
    public const double Db6 = 1108.73;
    public const double D6 = 1174.66;
    public const double Ds6 = 1244.51;
    public const double Eb6 = 1244.51;
    public const double E6 = 1318.51;
    public const double F6 = 1396.91;
    public const double Fs6 = 1479.98;
    public const double Gb6 = 1479.98;
    public const double G6 = 1567.98;
    public const double Gs6 = 1661.22;
    public const double Ab6 = 1661.22;
    public const double A6 = 1760.00;
    public const double As6 = 1864.66;
    public const double Bb6 = 1864.66;
    public const double B6 = 1975.53;

    public const double C7 = 2093.00;
    public const double Cs7 = 2217.46;
    public const double Db7 = 2217.46;
    public const double D7 = 2349.32;
    public const double Ds7 = 2489.02;
    public const double Eb7 = 2489.02;
    public const double E7 = 2637.02;
    public const double F7 = 2793.83;
    public const double Fs7 = 2959.96;
    public const double Gb7 = 2959.96;
    public const double G7 = 3135.96;
    public const double Gs7 = 3322.44;
    public const double Ab7 = 3322.44;
    public const double A7 = 3520.00;
    public const double As7 = 3729.31;
    public const double Bb7 = 3729.31;
    public const double B7 = 3951.07;

    public const double C8 = 4186.01;
}