using LyricsEditorPro.ViewModels;
using System.Windows;

namespace LyricsEditorPro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainVM()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
