using LyricsEditorPro.Model;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Drawing;

namespace LyricsEditorPro.ViewModels
{
    public class HomeVM : BaseVM
    {
        readonly Navigation lyricsNavigation;
        public BaseVM CurrentVM => lyricsNavigation.CurrentVM;
        public SimpleLyricsVM simpleLyricsViewModel = new SimpleLyricsVM();
        public SyncedLyricsVM syncedLyricsViewModel = new SyncedLyricsVM();
        public HomeVM()
        {
            lyricsNavigation = new Navigation(); 
            lyricsNavigation.CurrentVM = syncedLyricsViewModel;//make some log file later (that means in the very end)
            lyricsNavigation.CurrentVMChanged += OnCurrentVMChanged;

            syncedLyricsViewModel.SetLyrics(Tracks[currentTrackIndex].Lyrics);
        }
        private int currentTrackIndex = 0;
        private int lyricsFontSize = 16;
        private List<string> filepaths = new List<string>();

        private static TrackVM cityOfEvil = new TrackVM(new Track("C:\\Lossless music\\Avenged Sevenfold\\City of Evil\\Blinded in Chains.flac"));
        private static TrackVM spitItOut = new TrackVM(new Track("C:\\Lossless music\\Slipknot\\Slipknot\\Spit It Out.flac"));
        private static TrackVM eyeless = new TrackVM(new Track("C:\\Lossless music\\Slipknot\\Slipknot\\Eyeless.flac"));
        private static TrackVM lwymmd = new TrackVM(new Track("C:\\Lossless music\\Taylor Swift\\reputation\\Look What You Made Me Do.flac"));
        private static TrackVM theEmptinessMachine = new TrackVM(new Track("C:\\Lossless music\\Linkin Park\\From Zero\\The Emptiness Machine.flac"));
        public ObservableCollection<TrackVM> Tracks { get; } = new ObservableCollection<TrackVM>() { cityOfEvil, spitItOut, eyeless, lwymmd, theEmptinessMachine };
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
        public BaseCommand OnSwitchLyricsViewMode => new BaseCommand(execute => SwitchLyricsViewMode());

        private void SwitchLyricsViewMode()
        {
            if (lyricsNavigation.CurrentVM == simpleLyricsViewModel)
            {
                syncedLyricsViewModel.SetLyrics((lyricsNavigation.CurrentVM as SimpleLyricsVM)?.LyricsText);
                lyricsNavigation.CurrentVM = syncedLyricsViewModel;
            }
            else
            {
                simpleLyricsViewModel.SetLyrics((lyricsNavigation.CurrentVM as SyncedLyricsVM)?.LyricsText);
                lyricsNavigation.CurrentVM = simpleLyricsViewModel;
            }
        }

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
        void OnCurrentVMChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }
    }
}
