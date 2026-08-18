using LyricsEditorPro.Model;
using System.IO;
using System.Windows.Media.Imaging;

namespace LyricsEditorPro.ViewModels
{
    public class TrackVM : BaseVM 
    {
        readonly Track _track;
        public Track Source => _track;
        public string Name => _track.tags.Title;
        public string Album => _track.tags.Album;
        public string Artists => string.Join(", ", _track.tags.Performers);
        public string AlbumArtists => string.Join(", ", _track.tags.AlbumArtists);
        public string Lyrics => _track.tags.Lyrics;
        private BitmapImage bitmap;
        public BitmapImage Cover => bitmap;

        public TimeSpan Duration => _track.Duration;
        public TrackVM(Track track)
        {
            _track = track;

            var picture = _track.tags.Pictures[0]; 
            MemoryStream ms = new MemoryStream(picture.Data.Data);
            ms.Seek(0, SeekOrigin.Begin);

            bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

        }
    }
}
