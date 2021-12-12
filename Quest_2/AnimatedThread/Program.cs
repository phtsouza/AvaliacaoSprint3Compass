using AnimatedThread.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AnimatedThread
{
    class Program
    {

        static Dictionary<string, string> frameSprites = new Dictionary<string, string>();
        static IDatabase _database;
        static IDatabase Database
        {
            get
            {
                if (_database == null)
                    _database = new Database();

                return _database;
            }
        }
        static async Task Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            int counter;
            int j = 1;
            var peopleOutpout = new List<Output>();

            while (peopleOutpout.Count < 88)
            {
                counter = 0;

                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(0, 0);

                    DrawLoopMainThread(i, counter);

                    await Task.Delay(200);

                    counter++;
                }

                Console.WriteLine("-- INICIANDO PROCESSAMENTO --");
                //TODO: Iniciar tarefas abaixo desta linha
                Parallel.Invoke(
                    async () =>
                    {
                        Output output = await PreencheOutputAsync(j);
                        peopleOutpout.Add(output);
                        j++;
                    }
                    );

            }
            var dadosJson = JsonConvert.SerializeObject(peopleOutpout, Formatting.Indented);
            Console.WriteLine(dadosJson);


            Console.WriteLine("---- FINALIZADO ---");
            Console.ReadLine();
        }

        public static async Task<Output> PreencheOutputAsync(int IdPerson)
        {
            Database database = new Database();
            var person = database.GetPeople().ToList();
            var artist = database.GetArtists().ToList();
            var songs = database.GetSongs().ToList();
            var personSong = await database.GetPersonSongsAsync(person[IdPerson].Id);

            List<string> listaMusicas = new List<string>();

            for(int i=0; i< personSong.SongsIds.Length; i++)
            {
                listaMusicas.Add(songs[personSong.SongsIds[i]].Name);
            }

            List<Song> musicas = new List<Song>();

            for(int j = 0; j<songs.Count; j++)
            {
                if(artist[IdPerson].Id == songs[j].ArtistId)
                {
                    musicas.Add(songs[j]);
                }
            }

            var musicArtist = new ArtistSongs(artist[IdPerson], musicas);

            List<ArtistSongs> musicasArtistas = new List<ArtistSongs>();
            musicasArtistas.Add(musicArtist);

            Output output = new Output(person[IdPerson].Name,
                person[IdPerson].Age,
                songs[personSong.FavoriteSongId].Name,
                artist[songs[IdPerson].ArtistId].Name,
                songs[personSong.FavoriteSongId].Year,
                listaMusicas,
                musicasArtistas
                );

            return output;
        }

        static void DrawLoopMainThread(int i, int counter)
        {

            switch (counter % (i + 1))
            {
                case 0:
                    {
                        const string frameName = nameof(Animations.frame8);

                        Console.Write(GetFrameLines(frameName, Animations.frame8));

                        break;
                    };
                case 1:
                    {
                        const string frameName = nameof(Animations.frame7);

                        Console.Write(GetFrameLines(frameName, Animations.frame7));
                        break;
                    };
                case 2:
                    {
                        const string frameName = nameof(Animations.frame6);

                        Console.Write(GetFrameLines(frameName, Animations.frame6));
                        break;
                    };
                case 3:
                    {
                        const string frameName = nameof(Animations.frame5);

                        Console.Write(GetFrameLines(frameName, Animations.frame5));
                        break;
                    };
                case 4:
                    {
                        const string frameName = nameof(Animations.frame4);

                        Console.Write(GetFrameLines(frameName, Animations.frame4));
                        break;
                    };
                case 5:
                    {
                        const string frameName = nameof(Animations.frame3);

                        Console.Write(GetFrameLines(frameName, Animations.frame3));
                        break;
                    };
                case 6:
                    {
                        const string frameName = nameof(Animations.frame2);

                        Console.Write(GetFrameLines(frameName, Animations.frame2));
                        break;
                    };
                case 7:
                    {
                        const string frameName = nameof(Animations.frame1);

                        Console.Write(GetFrameLines(frameName, Animations.frame1));
                        break;
                    }
                case 8:
                    {
                        const string frameName = nameof(Animations.frame0);

                        Console.Write(GetFrameLines(frameName, Animations.frame0));
                        break;
                    }

            }

        }

        static string GetFrameLines(string frameName, string frame)
        {
            if (!frameSprites.ContainsKey(frameName))
            {
                var frameLines = frame.Split("<br>");
                var sb = new StringBuilder();
                foreach (var item in frameLines)
                {
                    sb.AppendLine(item);
                }
                frameSprites.Add(frameName, sb.ToString());
            }

            return frameSprites[frameName];
        }



    }
}
