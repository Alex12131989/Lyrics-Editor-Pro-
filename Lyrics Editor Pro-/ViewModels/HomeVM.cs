using LyricsEditorPro.Model;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Drawing;

namespace LyricsEditorPro.ViewModels
{
    public class HomeVM : BaseVM
    {
        private int currentTrackIndex = 0;
        private int lyricsFontSize = 16;
        private List<string> filepaths = new List<string>();

        private static TrackVM cityOfEvil = new TrackVM(new Track("C:\\Lossless music\\Avenged Sevenfold\\City of Evil\\Blinded in Chains.flac"));

        public ObservableCollection<TrackVM> Tracks { get; } = new ObservableCollection<TrackVM>() { cityOfEvil };
        public Track CurrentTrack => Tracks[currentTrackIndex].Source;
		public PlayerVM PlayerVM { get; } = new PlayerVM();

		public string LyricsText 
        { 
            get => CurrentTrack.tags.Lyrics;
            set
            {
                CurrentTrack.tags.Lyrics = value;
                OnPropertyChanged(nameof(LyricsText));
            }
        }
        public int LyricsFontSize { get => lyricsFontSize; set => lyricsFontSize = value; }

        public BaseCommand SelectFilesCommand => new BaseCommand(execute => SelectFiles());

        void SelectFiles()
        {
            var ofd = new OpenFileDialog();
            ofd.DefaultExt = ".*";
            ofd.Filter = "All files (flac or mp3)|*.*|Flac files|*.flac|Mp3 files|*.mp3";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == true && ofd.FileName != string.Empty)
                foreach (string filepath in ofd.FileNames)
                    filepaths.Add(filepath);
        }
        
        void ImportTracks(string[] filepaths)
        {
            foreach (string filepath in filepaths)
                Tracks?.Add(new TrackVM(new Track(filepath)));
        }
    }
}
