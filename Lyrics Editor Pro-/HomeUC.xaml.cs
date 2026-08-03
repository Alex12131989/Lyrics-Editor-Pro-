using System.Windows.Controls;

//System.Diagnostics.Process.Start(e.Uri.AbsoluteUri) -> to open links from the web
namespace Lyrics_Editor_Pro_
{
    /// <summary>
    /// Interaction logic for HomeUC.xaml
    /// </summary>
    public partial class HomeUC : UserControl
    {
        string[] filenames = { };
        public HomeUC(string[] filenames)
        {
            this.filenames = filenames;
            InitializeComponent();
            InvalidateMeasure();
            OpenLyricsView();
        }

        void OpenLyricsView()
        {

        }

        private void SaveFile_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void SaveAll_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
