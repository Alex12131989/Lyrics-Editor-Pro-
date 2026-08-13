namespace LyricsEditorPro.Model
{
    internal class Track
    {
        string filepath = string.Empty;
        TagLib.File file;
        public TagLib.Tag tags;
        public TimeSpan Duration => file.Properties.Duration;

        public Track(string filename)
        {
            filepath = (filename != "") ? filename : throw new ArgumentNullException("File path was not specified");
            file = TagLib.File.Create(filename);
            tags = file.Tag;
        }
        
    }
}
