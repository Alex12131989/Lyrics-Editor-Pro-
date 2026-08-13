using LyricsEditorPro.Stores;

namespace LyricsEditorPro.ViewModels
{
    internal class MainVM : BaseVM
    {
        readonly NavigationStore _navigationStore;
        public BaseVM CurrentVM => _navigationStore.CurrentVM;
        public MainVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentVMChanged += OnCurrentVMChanged;
        }
        void OnCurrentVMChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }
    }
}
 