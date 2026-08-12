using System.Windows;
using System.Windows.Controls;

namespace LyricsEditorPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Container.Children.Count <= 1) return;
            Container.Children[1].Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
            this.MinHeight = Container.Children[0].DesiredSize.Height + Container.Children[1].DesiredSize.Height;
            this.MinWidth = Container.Children[0].DesiredSize.Width > Container.Children[1].DesiredSize.Width ? Container.Children[0].DesiredSize.Width : Container.Children[1].DesiredSize.Width;
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                (sender as Button)?.Content = "🗗";
            }
            else
            {
                WindowState = WindowState.Maximized;
                (sender as Button)?.Content = "🗖";
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}