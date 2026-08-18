using LyricsEditorPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LyricsEditorPro.ViewModels
{
    public class SyncedLyricsVM : BaseVM
    {
        private LyricsText _lyrics;
        private ObservableCollection<SyncedLineVM> syncedLyrics = new ObservableCollection<SyncedLineVM>();
        public SyncedLyricsVM(string? lyrics = null)
        {
            SetLyrics(lyrics);
        }
        public ObservableCollection<SyncedLineVM> Lyrics { get => syncedLyrics; set => syncedLyrics = value; }
        public List<string> LyricsText => _lyrics.PlainLyrics;
        public void SetLyrics(string? lyrics)
        {
            if (lyrics == null) return;
            _lyrics = new LyricsText(lyrics);
            foreach (var line in _lyrics.SyncedLyrics) syncedLyrics.Add(new SyncedLineVM(line));
        }
        public void SetLyrics(List<string>? lyrics)
        {
            if (lyrics == null) return;
            _lyrics = new LyricsText(lyrics);
            foreach (var line in _lyrics.SyncedLyrics) syncedLyrics.Add(new SyncedLineVM(line));
        }
    }
}
