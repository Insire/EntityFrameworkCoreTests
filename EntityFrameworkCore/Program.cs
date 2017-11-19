using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EntityFrameworkCore
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var options = new DbContextOptions<AnimeContext>();
            using (var repo = new AnimeRepository(new AnimeContext(options)))
            {
                await repo.Create(new Anime()
                {
                    Title = Guid.NewGuid().ToString(),
                    Description = DateTime.UtcNow.ToShortTimeString()
                }).ConfigureAwait(false);

                Console.WriteLine("Animes in the sqlite file:");
                foreach (var anime in await repo.GetAll().ConfigureAwait(false))
                    Console.WriteLine(anime.Title + " " + anime.Description);
            }

            Console.ReadKey();
        }
    }
}
