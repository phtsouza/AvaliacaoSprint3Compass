using Newtonsoft.Json;
using System.Collections;

namespace AnimatedThread
{
    public class Artist
    {
        public Artist(int id, string name)
        {
            Id = id;
            Name = name;
        }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
