using LyricsEditorPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LyricsEditorPro.ViewModels
{
    public class SimpleLyricsVM : BaseVM
    {
        private LyricsText _lyrics;
        private ObservableCollection<SyncedLineVM> syncedLyrics = new ObservableCollection<SyncedLineVM>();
        public SimpleLyricsVM(string? lyrics = null)
        {
            SetLyrics(lyrics);
        }
        public string LyricsText
        {  
            get => string.Join("\r\n", _lyrics.PlainLyrics);
            set
            {
                _lyrics.PlainLyrics = value.Split("\r\n").ToList();
                OnPropertyChanged();
            } 
        }
        public void SetLyrics(string? lyrics)
        {
            if (lyrics == null) return;
            _lyrics = new LyricsText(lyrics);
        }
        public void SetLyrics(List<string> lyrics)
        {
            if (lyrics == null) return;
            _lyrics = new LyricsText(lyrics);
        }
    }
}
