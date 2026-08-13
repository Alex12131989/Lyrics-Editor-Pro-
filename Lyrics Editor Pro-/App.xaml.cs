using LyricsEditorPro.Stores;
using LyricsEditorPro.ViewModels;
using System.Windows;

namespace LyricsEditorPro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    partial class App : Application
    {
        readonly NavigationStore _navigationStore; 
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentVM = new HomeVM(_navigationStore);//change primary VM here (for quicker testing)
            MainWindow = new MainWindow()
            {
                DataContext = new MainVM(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
