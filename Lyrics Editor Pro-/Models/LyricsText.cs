using System;
using System.Collections.Generic;
using System.Text;

namespace LyricsEditorPro.Models
{
    public class LyricsText
    {
        private List<string> _lyricsText;
        public List<string> PlainLyrics { get => _lyricsText; set=> _lyricsText = value; }
        private List<SyncedLine> _syncedText = new List<SyncedLine>();
        public List<SyncedLine> SyncedLyrics => _syncedText;
        public LyricsText(string lyricsText)
        {
            _lyricsText = lyricsText.Split("\r\n").ToList();
            SetSyncedLyrics();
        }
        public LyricsText(string[] lyricsText)
        {
            _lyricsText = lyricsText.ToList();
            SetSyncedLyrics();
        }
        public LyricsText(List<string> lyricsText)
        {
            _lyricsText = lyricsText;
            SetSyncedLyrics();
        }

        private void SetSyncedLyrics()
        {
            foreach (string? line in _lyricsText) _syncedText.Add(new SyncedLine(line));
        }
    }
}
