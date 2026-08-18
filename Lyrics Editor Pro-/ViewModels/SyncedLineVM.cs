using LyricsEditorPro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LyricsEditorPro.ViewModels
{
    public class SyncedLineVM : BaseVM
    {
        private SyncedLine _syncedLine;
        public SyncedLineVM(SyncedLine sLine)
        {
            _syncedLine = sLine;
        }
        public string Line { get => _syncedLine.Text; set => _syncedLine.Text = value; }
        public string TimeStamp { get => _syncedLine.TimeStampString; set => _syncedLine.TimeStampString = value; }
    }
}
