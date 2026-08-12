using LyricsEditorPro.Model;
using System.Drawing;

namespace LyricsEditorPro.ViewModels
{
    internal class TrackVM : BaseVM
    {
        readonly Track _track;
        public string Name => _track.tags.Title;
        public string Album => _track.tags.Album;
        public string[] Artists => _track.tags.Performers;
        string[] AlbumArtists => _track.tags.AlbumArtists;
        public TagLib.IPicture[] Cover => _track.tags.Pictures;
        public string Length => _track.tags.Length;
        public TrackVM(Track track)
        {
            _track = track;
        }
    }
}
