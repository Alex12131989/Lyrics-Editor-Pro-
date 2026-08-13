using LyricsEditorPro.Stores;
using System.Collections.ObjectModel;

namespace LyricsEditorPro.ViewModels
{
    internal class HomeVM(NavigationStore navigationStore) : BaseVM
    {
		readonly NavigationStore _navigationStore = navigationStore;
		ObservableCollection<TrackVM> _tracks;
		public IEnumerable<TrackVM > Tracks => _tracks;

		private string _lyrics = String.Empty;

		public string LyricsText
		{
			get { return _lyrics; }
			set { _lyrics = value; }
		}
    }
}
