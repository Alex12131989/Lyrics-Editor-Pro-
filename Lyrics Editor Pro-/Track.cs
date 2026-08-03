using System;
using System.Collections.Generic;
using System.Text;
using TagLib;

namespace Lyrics_Editor_Pro_
{
    internal class Track
    {
        string filepath = string.Empty;

        public Track(string filename)
        {
            filepath = (filename != "") ? filename : throw new ArgumentNullException("File path was not specified");
        }
    
    }
}
