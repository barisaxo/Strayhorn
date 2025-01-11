using MusicTheory.Notes;

enum WaveformType { Sine, Square, Triangle, Sawtooth }

static class AudioGenerator
{
    static void CreateAudioFile(string filePath, (Pitch[] notes, int duration, float amp)[] noteStacks, WaveformType waveform)
    {
        int sampleRate = 44100;
        int totalSamples = noteStacks.Sum(stack => (int)(stack.duration * sampleRate / 1000.0));

        short[] buffer = new short[totalSamples];
        double maxAmp = 32760; // Max amplitude for 16-bit audio
        int bufferPos = 0;

        foreach (var (notes, duration, amp) in noteStacks)
        {
            int noteSamples = (int)(duration * sampleRate / 1000.0);
            int fadeDurationSamples = (int)(sampleRate * 0.05); // 50 milliseconds fade-in/fade-out to prevent loud popping
            double volume = maxAmp * Math.Clamp(amp, 0, 1);

            // Generate waveform for this homophone (simultaneously for all notes in the stack)
            for (int i = 0; i < noteSamples; i++)
            {
                double fadeInFactor = i < fadeDurationSamples ? (i / (double)fadeDurationSamples) : 1.0;
                double fadeOutFactor = i > noteSamples - fadeDurationSamples ? ((noteSamples - i) / (double)fadeDurationSamples) : 1.0;
                double currentAmplitude = volume * fadeInFactor * fadeOutFactor;

                double sample = 0;

                // Add all frequencies together to create homophony - I know, it seems like the wrong term, but look it up ~(-.-)~
                foreach (var note in notes)
                {
                    double time = i / (double)sampleRate;
                    short noteSample = 0;

                    switch (waveform)
                    {
                        case WaveformType.Sine:
                            noteSample = (short)(currentAmplitude * (Math.Sin(2 * Math.PI * note.Frequency * time) / notes.Length));
                            break;
                        case WaveformType.Square:
                            noteSample = (short)(currentAmplitude * ((Math.Sign(Math.Sin(2 * Math.PI * note.Frequency * time)) * 0.5 + 0.5) / notes.Length));
                            break;
                        case WaveformType.Triangle:
                            noteSample = (short)(currentAmplitude * ((2 * Math.Abs(2 * (time * note.Frequency % 1) - 1) - 1) / notes.Length));
                            break;
                        case WaveformType.Sawtooth:
                            noteSample = (short)(currentAmplitude * ((2 * (time * note.Frequency % 1) - 1) / notes.Length));
                            break;
                    }

                    sample += noteSample;
                }

                buffer[bufferPos] = (short)Math.Clamp(sample, short.MinValue, short.MaxValue);//Clamp to prevent clipping
                bufferPos++;
            }
        }

        // Write the audio data to a WAV file
        using var writer = new BinaryWriter(File.Open(filePath, FileMode.Create));

        // RIFF header
        writer.Write(['R', 'I', 'F', 'F']);
        writer.Write(36 + totalSamples * 2); // Chunk size
        writer.Write(['W', 'A', 'V', 'E']);

        // Format subchunk
        writer.Write(['f', 'm', 't', ' ']);
        writer.Write(16); // Subchunk size for PCM format
        writer.Write((short)1); // Audio format (PCM)
        writer.Write((short)1); // Number of channels (Mono)
        writer.Write(sampleRate); // Sample rate
        writer.Write(sampleRate * 2); // Byte rate
        writer.Write((short)2); // Block align (2 bytes per sample)
        writer.Write((short)16); // Bits per sample

        // Data subchunk
        writer.Write(['d', 'a', 't', 'a']);
        writer.Write(totalSamples * 2); // Data size

        foreach (var sample in buffer)
        {
            writer.Write(sample);
        }
    }

    public static bool PlayAudio(this (Pitch[] notes, int durationMS, float amp)[] noteStacks, Action callback, WaveformType waveform = WaveformType.Sine)
    {
        string filePath = noteStacks.GetHashCode() + "_audio.wav";
        string player = "afplay"; // Default player for macOS (Unix)

        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            // Windows system
            player = "wmplayer"; // Or use SoundPlayer for direct playback
        }
        else if (Environment.OSVersion.Platform == PlatformID.Other)
        {
            // linux system? I'm not sure what 'Other' could be, or what player it uses
            player = "aplay";
        }

        // Start the external player
        var playerProcess = new System.Diagnostics.Process
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = player,
                Arguments = filePath,
                CreateNoWindow = true
            }
        };

        CreateAudioFile(filePath, noteStacks, waveform);
        playerProcess.Start();
        callback();//used in this project for playback animation
        playerProcess.WaitForExit();
        File.Delete(filePath);
        return true;
    }
}
