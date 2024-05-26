using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options)
            : base(options)
        {
        }

        public DbSet<TournamentEntity> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Tournament)
                .WithMany(t => t.Games)
                .HasForeignKey(g => g.TournamentId);
        }
    }
}
