using LyricsEditorPro.Model;
using System.Windows.Controls;

//System.Diagnostics.Process.Start(e.Uri.AbsoluteUri) -> to open links from the web
namespace LyricsEditorPro.Views
{
    /// <summary>
    /// Interaction logic for HomeUC.xaml
    /// </summary>
    public partial class HomeUC : UserControl
    {
        public HomeUC()
        {
            //temporary
            filenames = new string[1];
            filenames[0] = "C:\\Lossless music\\Avenged Sevenfold\\City of Evil\\Blinded in Chains.flac";
            InitializeComponent();
        }

        byte[] fontSizes = new byte[2]; //0-lyrics_window, 1-queue_window
        string[] filenames = { };
        public HomeUC(string[] filenames)
        {
            this.filenames = filenames;
            InitializeComponent();
            //OpenLyricsView();
            //fontSizes[0] = (byte)tbLyrics.FontSize;
            //fontSizes[1] = (byte)lvQueue.FontSize;
        }

        void OpenLyricsView()
        {
            foreach (string filename in filenames)
            {
                var track = new Track(filename);
                //tbLyrics.Text = track.tags.Lyrics;
            }
        }

        private void SaveFile_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void SaveAll_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void Change_Font_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Font_Size_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Control_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }
    }
}
