using LyricsEditorPro.Model;
using System.Windows;

namespace LyricsEditorPro.ViewModels
{
    public class PlayerVM
    {
        private bool IsMuted { get; set; } = false;
        private double currentVolume = 0.15;
        Track currentTrack;
        TrackVM? currentTrackTags;

        public string Artist { get => string.Join(", ", currentTrackTags?.Artists); }
        public string? TrackName { get => currentTrackTags?.Name; }
        public string? Album { get => currentTrackTags?.Album; }
        public string ProgressTime 
        { 
            get
            {
                TimeSpan ct = new TimeSpan(Convert.ToInt32(currentTrack.CurrentTime));
                if (ct.Hours > 0) return $"{ct.Hours}:{ct.Minutes}:{ct.Seconds}/{currentTrackTags?.Duration.Hours}:{currentTrackTags?.Duration.Minutes}:{currentTrackTags?.Duration.Seconds}"; 
                else return $"{ct.Minutes}:{ct.Seconds}/{currentTrackTags?.Duration.Minutes}:{currentTrackTags?.Duration.Seconds}";
            }
        }

        public BaseCommand PreviousInQueue => new BaseCommand(execute => MovePositionInQueue(0));
        public BaseCommand NextInQueue => new BaseCommand(execute => MovePositionInQueue(1));
        public BaseCommand TogglePlay => new BaseCommand(_ => TogglePlayCommand());
        public BaseCommand ToggleVolume => new BaseCommand(execute => ToggleVolumeCommand());
        public double Volume { get => currentTrack.Volume; set { currentTrack.Volume = value; currentVolume = value; } }
        public double TrackProgress 
        { 
            get => currentTrack.CurrentTime/currentTrack.Duration.TotalSeconds*MaxProgressSliderValue;//I need to make it do continuously when the track plays
            set 
            { 
                SetTrackPosition((float)(value/MaxProgressSliderValue)); 
                //OnPropertyChanged for ProgressTime
            } 
        }
        public double MaxProgressSliderValue => 1;
        public double MinProgressSliderValue => 0;


        public void SetCurrentTrack(Track currentTrack)
        {
            this.currentTrack = currentTrack;
            currentTrackTags = new TrackVM(currentTrack);
        }


        void MovePositionInQueue(byte direction)
        {
            //if (direction == 0)

        }
        void TogglePlayCommand()
        {
            if (currentTrack.IsPlaying) currentTrack.Stop();
            else currentTrack.Play();
        }
        void ToggleVolumeCommand()
        {
            if (IsMuted) currentTrack.Volume = currentVolume;
            else currentTrack.Volume = 0;
            IsMuted = !IsMuted;
        }
        void SetTrackPosition(TimeSpan newPosition)
        {
            currentTrack.SetTime(new TimeSpan(0, 1, 20));
        }
        void SetTrackPosition(float percent)
        {
            currentTrack.SetTime(currentTrack.Duration*percent);
        }
    }
}
