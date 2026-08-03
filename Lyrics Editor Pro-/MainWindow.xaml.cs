using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Lyrics_Editor_Pro_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Container.Children.Add(new WelcomeUC());
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //for some fucking reason desired size isn't what it PROMISES to be and fucking twice as small
            this.MinHeight = Container.Children[0].DesiredSize.Height;
            this.MinWidth = Container.Children[0].DesiredSize.Width;
        }
    }
}