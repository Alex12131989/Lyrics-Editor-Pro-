using LyricsEditorPro.Model;
using NAudio.Wave;
using System.Windows;

namespace LyricsEditorPro.ViewModels
{
    public class PlayerVM : BaseVM
    {
        private System.Timers.Timer timer;
        public PlayerVM()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000; //it breaks the playback if it's anything less for some reason 0_o
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        ~PlayerVM()
        {
            timer.Elapsed -= Timer_Elapsed;
            timer.Stop();
        }
        private double currentVolume;
        private Track currentTrack;
        private TrackVM? currentTrackTags;

        private bool IsMuted { get; set; } = false;
        public string Artist { get => string.Join(", ", currentTrackTags?.Artists); }
        public string? TrackName { get => currentTrackTags?.Name; }
        public string? Album { get => currentTrackTags?.Album; }
        public string ProgressTime 
        { 
            get
            {
                TimeSpan ct = TimeSpan.FromSeconds(Convert.ToInt32(currentTrack.CurrentTime));
                if (ct.Hours > 0) return $"{ct.Hours}:{ct.Minutes.ToString("D2")}:{ct.Seconds.ToString("D2")}/" +
                        $"{currentTrackTags?.Duration.Hours.ToString("D2")}:{currentTrackTags?.Duration.Minutes.ToString("D2")}:{currentTrackTags?.Duration.Seconds.ToString("D2")}"; 
                else return $"{ct.Minutes.ToString("D2")}:{ct.Seconds.ToString("D2")}/{currentTrackTags?.Duration.Minutes.ToString("D2")}:{currentTrackTags?.Duration.Seconds.ToString("D2")}";
            }
        }

        public BaseCommand PreviousInQueue => new BaseCommand(execute => MovePositionInQueue(0));
        public BaseCommand NextInQueue => new BaseCommand(execute => MovePositionInQueue(1));
        public BaseCommand TogglePlay => new BaseCommand(_ => TogglePlayCommand());
        public BaseCommand ToggleVolume => new BaseCommand(execute => ToggleVolumeCommand());
        public double Volume { get => currentTrack.Volume; set { currentTrack.Volume = value; currentVolume = value; OnPropertyChanged(); } }
        public double TrackProgress 
        { 
            get => currentTrack.CurrentTime/currentTrack.Duration.TotalSeconds*MaxProgressSliderValue;
            set 
            { 
                //Set boundary in case the track ends
                SetTrackPosition((float)(value/MaxProgressSliderValue));
                OnPropertyChanged();
            } 
        }
        public double MaxProgressSliderValue => 1;
        public double MinProgressSliderValue => 0;


        public void SetCurrentTrack(Track currentTrack)
        {
            this.currentTrack = currentTrack;
            currentTrackTags = new TrackVM(currentTrack);
            Volume = 0.05;
        }


        private void MovePositionInQueue(byte direction)
        {
            //if (direction == 0)

        }
        private void TogglePlayCommand()
        {
            if (currentTrack.IsPlaying)
            {
                currentTrack.Stop();
                timer.Stop();
            }
            else
            {
                currentTrack.Play();
                timer.Start();
            }
            ChangeTogglePlayStopButtonCanvasImage();
        }

        private void ChangeTogglePlayStopButtonCanvasImage()
        {
            if (currentTrack.IsPlaying)
            {

            }
            else
            {

            }
        }

        private void ToggleVolumeCommand()
        {
            if (IsMuted) currentTrack.Volume = currentVolume;
            else currentTrack.Volume = 0;
            IsMuted = !IsMuted;
            OnPropertyChanged(nameof(Volume));
        }
        private void SetTrackPosition(TimeSpan newPosition)//for syncing lyrics, DO NOT DELETE (YOU WILL USE IT BAFFOON)
        {
            currentTrack.SetTime(new TimeSpan(0, 1, 20));
        }
        private void SetTrackPosition(float percent)
        {
            currentTrack.SetTime(currentTrack.Duration*percent);
        }
        private void UpdateTime()
        {
            if (currentTrack == null) return;
            if (currentTrack.IsPlaying)
            {
                OnPropertyChanged(nameof(TrackProgress));
                OnPropertyChanged(nameof(ProgressTime));
            }
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateTime();
        }
    }
}
