using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
    public class AnimeRepository : BaseRepository<Anime, int>
    {
        public AnimeRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
