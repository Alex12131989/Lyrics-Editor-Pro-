using LyricsEditorPro.Model;
using System.Windows;

namespace LyricsEditorPro.ViewModels
{
    public class PlayerVM
    {
        TimeSpan timePassed = TimeSpan.Zero;
        TrackVM? currentTrackTags;

        public string Artist { get => string.Join(", ", currentTrackTags?.Artists); }
        public string? TrackName { get => currentTrackTags?.Name; }
        public string? Album { get => currentTrackTags?.Album; }
        public string ProgressTime 
        { 
            get
            {
                if (currentTrackTags?.Duration.Hours > 0) return $"{timePassed.Hours}:{timePassed.Minutes}:{timePassed.Seconds}/{currentTrackTags?.Duration.Hours}:{currentTrackTags?.Duration.Minutes}:{currentTrackTags?.Duration.Seconds}"; 
                else return $"{timePassed.Minutes}:{timePassed.Seconds}/{currentTrackTags?.Duration.Minutes}:{currentTrackTags?.Duration.Seconds}";
            }
        }

        public int Volume { get; set; }
        public BaseCommand PreviousInQueue => new BaseCommand(execute => MovePositionInQueue(0));
        public BaseCommand NextInQueue => new BaseCommand(execute => MovePositionInQueue(1));
        public BaseCommand TogglePlay => new BaseCommand(_ => TogglePlayCommand());
        public BaseCommand ToggleVolume => new BaseCommand(execute => ToggleVolumeCommand());
        //public BaseCommand TrackProgress => new BaseCommand(execute => SetTrackPosition(TimeSpan.Zero/*!!!!*/));



        Track currentTrack;
        public void SetCurrentTrack(Track currentTrack)
        {
            this.currentTrack = currentTrack;
        }


        void MovePositionInQueue(byte direction)
        {
            //if (direction == 0)

        }
        void TogglePlayCommand()
        {
            MessageBox.Show($"You are playing {currentTrack.tags.Title}");
        }
        void ToggleVolumeCommand()
        {

        }
        void SetTrackPosition(TimeSpan newPosition)
        {

        }
    }
}
