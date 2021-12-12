using AnimatedThread.Models;
using System.Collections.Generic;

namespace AnimatedThread
{
    public class Output
    {
        public Output(string personName, int personAge, string favoriteSong, string favoriteSongArtist, int favoriteSongYear, IEnumerable<string> otherSongs, IEnumerable<ArtistSongs> artistSongs)
        {
            PersonName = personName;
            PersonAge = personAge;
            FavoriteSong = favoriteSong;
            FavoriteSongArtist = favoriteSongArtist;
            FavoriteSongYear = favoriteSongYear;
            OtherSongs = otherSongs;
            ArtistSongs = artistSongs;
        }

        public string PersonName { get; private set; }
        public int PersonAge { get; private set; }
        public string FavoriteSong { get; private set; }
        public string FavoriteSongArtist { get; private set; }
        public int FavoriteSongYear { get; set; }
        public IEnumerable<string> OtherSongs { get; private set; }
        public IEnumerable<ArtistSongs> ArtistSongs { get; private set; }
       
    }
}
