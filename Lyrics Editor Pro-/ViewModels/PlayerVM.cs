using LyricsEditorPro.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using TagLib.Riff;

namespace LyricsEditorPro.ViewModels
{
    internal class PlayerVM
    {
        TimeSpan timePassed = TimeSpan.Zero;
        TrackVM _currentTrack;
        PlayerVM(TrackVM currentTrack)
        {
            _currentTrack = currentTrack;
        }
        public string Artists { get => string.Join(", ", _currentTrack.Artists); }
        public string TrackName { get => _currentTrack.Name; }
        public string Album { get => _currentTrack.Album; }
        public string ProgressTime 
        { 
            get
            {
                if (_currentTrack.Duration.Hours > 0) return $"{timePassed.Hours}:{timePassed.Minutes}:{timePassed.Seconds}/{_currentTrack.Duration.Hours}:{_currentTrack.Duration.Minutes}:{_currentTrack.Duration.Seconds}"; 
                else return $"{timePassed.Minutes}:{timePassed.Seconds}/{_currentTrack.Duration.Minutes}:{_currentTrack.Duration.Seconds}";
            }
        }

        private float _volume;
        public BaseCommand PreviousInQueue => new BaseCommand(execute => MovePositionInQueue(0));
        public BaseCommand NextInQueue => new BaseCommand(execute => MovePositionInQueue(1));
        public BaseCommand TogglePlay => new BaseCommand(execute => TogglePlayCommand());
        public BaseCommand ToggleVolume => new BaseCommand(execute => ToggleVolumeCommand());
        public BaseCommand TrackProgress => new BaseCommand(execute => SetTrackPosition(TimeSpan.Zero/*!!!!*/));


        void MovePositionInQueue(byte direction)
        {
            //if (direction == 0)

        }
        void TogglePlayCommand()
        {

        }
        void ToggleVolumeCommand()
        {

        }
        void SetTrackPosition(TimeSpan newPosition)
        {

        }
    }
}
