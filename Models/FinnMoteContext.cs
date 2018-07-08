using Microsoft.EntityFrameworkCore;

namespace FinnMote.Api.Models
{
    public class FinnMoteContext : DbContext
    {
        public FinnMoteContext(DbContextOptions<FinnMoteContext> options)
            : base(options)
        {
        }

        public DbSet<Arrangement> Arrangementer { get; set; }
        public DbSet<Arrangoer> Arrangoerer { get; set; }

    }
}