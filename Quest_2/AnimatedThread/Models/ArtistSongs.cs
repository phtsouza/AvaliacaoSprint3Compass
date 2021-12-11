using System.Collections.Generic;

namespace AnimatedThread.Models
{
    public class ArtistSongs
    {
        public ArtistSongs(Artist artist, IEnumerable<Song> songs)
        {
            Artist = artist;
            Songs = songs;
        }

        public Artist Artist { get; private set; }
        public IEnumerable<Song> Songs { get; private set; }
    }
}
