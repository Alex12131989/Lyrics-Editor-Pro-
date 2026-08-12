namespace LyricsEditorPro.Model
{
    internal class Track
    {
        string filepath = string.Empty;
        TagLib.File file;
        public TagLib.Tag tags;

        public Track(string filename)
        {
            filepath = (filename != "") ? filename : throw new ArgumentNullException("File path was not specified");
            file = TagLib.File.Create(filename);
            tags = file.Tag;
        }
        
    }
}
