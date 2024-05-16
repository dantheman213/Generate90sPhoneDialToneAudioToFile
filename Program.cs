using System;
using NAudio.Wave;

class Program
{
    static void Main()
    {
        int sampleRate = 44100; // Sample rate
        double duration = 15.0; // Duration in seconds
        double frequency1 = 350.0; // First frequency (Hz)
        double frequency2 = 440.0; // Second frequency (Hz)
        int amplitude = 32760; // Max amplitude for 16-bit audio

        int samples = (int)(sampleRate * duration);
        using (WaveFileWriter writer = new WaveFileWriter("dialtone.wav", new WaveFormat(sampleRate, 16, 1)))
        {
            for (int i = 0; i < samples; i++)
            {
                double time = (double)i / sampleRate;
                double sampleValue = amplitude * (Math.Sin(2 * Math.PI * frequency1 * time) + Math.Sin(2 * Math.PI * frequency2 * time)) / 2;
                writer.WriteSample((float)sampleValue / amplitude); // Normalize sample value
            }
        }

        Console.WriteLine("Dial tone generated and saved as dialtone.wav");
    }
}
