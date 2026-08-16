using System;
using System.Windows;
using NAudio.Wave;

namespace LyricsEditorPro.Model
{
    public class Track
    {
        private bool isPlaying = false;
        public bool IsPlaying => isPlaying;
        private WaveOut wo;
        private MediaFoundationReader mf;
        private string filepath = string.Empty;
        private TagLib.File file;
        public TagLib.Tag tags;
        public TimeSpan Duration => file.Properties.Duration;
        public float CurrentTime => mf.Position / mf.WaveFormat.AverageBytesPerSecond;

        public Track(string filename)
        {
            filepath = (filename != "") ? filename : throw new ArgumentNullException("File path was not specified");
            file = TagLib.File.Create(filename);
            tags = file.Tag;
            mf = new MediaFoundationReader(filepath);
            wo = new WaveOut();
            wo.Init(mf);
            Volume = 0.3f;
        }
        public Track() { }

        public void Play()
        {
            wo.Play();
            isPlaying = true;
        }

        public void Stop()
        {
            wo.Stop();
            isPlaying = false;
        }

        public void SetTime(TimeSpan time)
        {
            mf.Position = (long)(time.TotalSeconds*mf.WaveFormat.AverageBytesPerSecond);
        }

        public double Volume
        {
            get => wo.Volume;
            set
            {
                if (value < 0 || value > 1) throw new ArgumentOutOfRangeException("Value exceeds the range");
                    wo.Volume = (float)value;
            }
        }
    }
}
