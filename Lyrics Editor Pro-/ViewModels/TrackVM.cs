using LyricsEditorPro.Model;

namespace LyricsEditorPro.ViewModels
{
    public class TrackVM : BaseVM
    {
        readonly Track _track;
        public string Name => _track.tags.Title;
        public string Album => _track.tags.Album;
        public string Artists => string.Join(", ", _track.tags.Performers);
        string AlbumArtists => string.Join(", ", _track.tags.AlbumArtists);
        public TagLib.IPicture[] Cover => _track.tags.Pictures; 
        public TimeSpan Duration => _track.Duration;
        public TrackVM(Track track)
        {
            _track = track;
        }
    }
}
