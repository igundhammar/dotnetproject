using Microsoft.EntityFrameworkCore;
using musicshop.Models.API;

namespace musicshop.Data;

    public class MusicDb : DbContext
    {
        public MusicDb(DbContextOptions<MusicDb> options)
            : base(options)
        {
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
