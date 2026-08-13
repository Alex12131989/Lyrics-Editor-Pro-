using LyricsEditorPro.ViewModels;
using System.Linq.Expressions;

namespace LyricsEditorPro.Stores
{
    internal class NavigationStore
    {
		private BaseVM _currentVM;

		public BaseVM CurrentVM	
		{
			get { return _currentVM; }
			set 
			{
				_currentVM = value;
				OnCurrentVMChanged();
			}
		}

        private void OnCurrentVMChanged()
        {
			CurrentVMChanged?.Invoke();
        }

        public event Action CurrentVMChanged;
	}
}
