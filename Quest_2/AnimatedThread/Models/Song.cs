namespace AnimatedThread
{
    public class Song
    {
        public Song(int id, string name, int year, int artistId)
        {
            Id = id;
            Name = name;
            Year = year;
            ArtistId = artistId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int ArtistId { get; set; }
    }
}
