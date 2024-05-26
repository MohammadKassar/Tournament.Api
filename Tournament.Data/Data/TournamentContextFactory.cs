using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tournament.Data.Data;

namespace Tournament.Data.Data
{
    public class TournamentContextFactory : IDesignTimeDbContextFactory<TournamentContext>
    {
        public TournamentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TournamentContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQllocaldb;Database=TournamentDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new TournamentContext(optionsBuilder.Options);
        }
    }
}
