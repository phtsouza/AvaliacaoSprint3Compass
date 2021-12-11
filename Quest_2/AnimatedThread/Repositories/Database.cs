using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AnimatedThread
{
    public interface IDatabase
    {
        IEnumerable<Person> GetPeople();
        IEnumerable<Artist> GetArtists();
        IEnumerable<Song> GetSongs();
        Task<PersonSong> GetPersonSongsAsync(int personId);
    }
    public class Database : IDatabase
    {
        

        public IEnumerable<Person> GetPeople()
        {
            /********* Não Remover. Porém, pode alterar valores para debug *********/
            Thread.Sleep(3000);
            var peopleData = File.ReadAllText("JsonData/people_info.json");
            /********* *************************************************** *********/

            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(peopleData);

            return people;
        }

        public IEnumerable<Artist> GetArtists()
        {
            /********* Não Remover. Porém, pode alterar valores para debug *********/
            Thread.Sleep(5000); 
            var artistsData = File.ReadAllText("JsonData/artists.json");
            /********* *************************************************** *********/

            var artists = JsonConvert.DeserializeObject<IEnumerable<Artist>>(artistsData);

            return artists;
        }

        public IEnumerable<Song> GetSongs()
        {
            /********* Não Remover. Porém, pode alterar valores para debug *********/
            Thread.Sleep(2000);
            var songsData = File.ReadAllText("JsonData/songs.json");
            /********* *************************************************** *********/

            var songs = JsonConvert.DeserializeObject<IEnumerable<Song>>(songsData);

            return songs;
        }

        public async Task<PersonSong> GetPersonSongsAsync(int personId)
        {
            /********* Não Remover. Porém, pode alterar valores para debug *********/
            var peopleSongsData = await File.ReadAllTextAsync("JsonData/people_songs.json");
            /********* *************************************************** *********/

            var personSongs = JsonConvert.DeserializeObject<IEnumerable<PersonSong>>(peopleSongsData);

            return personSongs.FirstOrDefault(x => x.PersonId == personId);
        }

    }
}
