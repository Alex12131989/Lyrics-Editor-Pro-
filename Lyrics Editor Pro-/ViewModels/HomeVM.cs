using System.Collections.ObjectModel;

namespace LyricsEditorPro.ViewModels
{
    internal class HomeVM : BaseVM
    {
		ObservableCollection<TrackVM> _tracks;
		public IEnumerable<TrackVM > Tracks => _tracks;

		private string _lyrics;

		public string LyricsText
		{
			get { return _lyrics; }
			set { _lyrics = value; }
		}



		public HomeVM()
		{

		}
	}
}
