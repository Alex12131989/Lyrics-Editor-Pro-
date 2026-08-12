using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace LyricsEditorPro.Views
{
    /// <summary>
    /// Interaction logic for WelcomeUC.xaml
    /// </summary>
    public partial class WelcomeUC : UserControl
    {
        public WelcomeUC()
        {
            InitializeComponent();
        }
        
        private void btnSelectFiles_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.DefaultExt = ".*";
            ofd.Filter = "Flac files|*.flac|Mp3 files|*.mp3";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == true && ofd.FileName != string.Empty)
            {
                this.Visibility = Visibility.Hidden;
                var container = this.Parent as Grid;
                container.Children.Add(new HomeUC(ofd.FileNames));
                container.Children.Remove(this);
                (container.Parent as Window).Width -= -1; //to set the Window_SizeChanged method in case (most certaintly actually) windows is smaller than homeUC
            }
        }
    }
}
