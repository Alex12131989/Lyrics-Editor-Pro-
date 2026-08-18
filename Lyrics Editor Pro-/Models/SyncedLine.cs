using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LyricsEditorPro.Models
{
    public class SyncedLine
    {
        private string _line;
        private string _textLine;
        public string Text { get => _textLine; set => _line = value; }
        private string _timeStampLine;
        public string TimeStampString { get => _timeStampLine; set {  _timeStampLine = value; _timeStamp = Convert(value); } }
        private TimeSpan _timeStamp;
        public TimeSpan TimeStamp { get => _timeStamp; set { _timeStamp = value; _timeStampLine = Convert(value); } }
        public SyncedLine(string line)
        {
            _line = line;
            SplitLine();
        }

        private void SplitLine()
        {
            string[] parts = _line.Split("]");
            if (parts.Length <= 1) return;
            _textLine = parts[1];
            _timeStampLine = parts[0].Remove(0, 1);
            _timeStamp = Convert(_timeStampLine);
        }
        private TimeSpan Convert(string tStr)
        {
            string[] regex = { @"^\d{1,2}:\d{2}\.\d*$", @"^\d{1,2}:\d{1,2}:\d{2}\.\d*$" };
            if (Regex.IsMatch(tStr, regex[0]))
            {
                string[] shortFormats = { @"mm\:ss\.FFFFFFF", @"m\:ss\.FFFFFFF" };
                return TimeSpan.ParseExact(tStr, shortFormats, null);

            }
            else if (Regex.IsMatch(tStr, regex[1]))
            {
                string[] longFormats = { @"hh\:mm\:ss\.FFFFFFF", @"h\:mm\:ss\.FFFFFFF", @"hh\:m\:ss\.FFFFFFF", @"hh\:m\:ss\.FFFFFFF", };
                return TimeSpan.ParseExact(tStr, longFormats, null);
            }
            else throw new Exception("I'm incompetent, sue me");
        }
        private string Convert(TimeSpan ts)
        {
            if (ts.Hours == 0) return ts.ToString(@"mm\:ss\.fff");
            else return ts.ToString(@"hh\:mm\:ss\.fff");
        }
    }
}
