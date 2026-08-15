using LyricsEditorPro.Model;
using LyricsEditorPro.ViewModels;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace LyricsEditorPro.Views
{
    public partial class PlayerUC : UserControl
    {
        public static readonly DependencyProperty PlayerContentDP = DependencyProperty.Register( 
            nameof(PlayerContent), 
            typeof(Track), 
            typeof(PlayerUC), 
            new PropertyMetadata(null, OnPlayerContentChanged));

        public Track PlayerContent 
        { 
            get => (Track)GetValue(PlayerContentDP);
            set { SetValue(PlayerContentDP, value); }
        }
        public PlayerUC()
        {
            InitializeComponent();
        }
        private static void OnPlayerContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (PlayerUC)d;
            (control.DataContext as PlayerVM)?.SetCurrentTrack((Track)e.NewValue);
        }
       
    }
}
