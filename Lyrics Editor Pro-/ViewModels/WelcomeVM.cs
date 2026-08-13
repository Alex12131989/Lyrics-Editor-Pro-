using LyricsEditorPro.Stores;
using Microsoft.Win32;

namespace LyricsEditorPro.ViewModels
{
    internal class WelcomeVM(NavigationStore navigationStore) : BaseVM
    {
        readonly NavigationStore _navigationStore = navigationStore;
        public BaseCommand SelectFilesCommand => new BaseCommand(execute => SelectFiles());
        void SelectFiles()
        {

            var ofd = new OpenFileDialog();
            ofd.DefaultExt = ".*";
            ofd.Filter = "All files (flac or mp3)|*.*|Flac files|*.flac|Mp3 files|*.mp3";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == true && ofd.FileName != string.Empty) _navigationStore.CurrentVM = new HomeVM(_navigationStore);
        }

    }
}
