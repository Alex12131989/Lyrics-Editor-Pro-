using LyricsEditorPro.Model;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace LyricsEditorPro.ViewModels
{
    public class HomeVM : BaseVM
    {
        private int currentTrackIndex = 0;
        private List<string> filepaths = new List<string> { "C:\\Lossless music\\Avenged Sevenfold\\City of Evil\\Blinded in Chains.flac" };
        public ObservableCollection<Track> Tracks { get; } = new ObservableCollection<Track>() { new Track("C:\\Lossless music\\Avenged Sevenfold\\City of Evil\\Blinded in Chains.flac") };//little shit cost me 3 hours of sleep - it was null the whole time and I thought I passed properties incorrectly
        public Track CurrentTrack => Tracks[currentTrackIndex];
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
                Tracks?.Add(new Track(filepath));
        }
    }
}
