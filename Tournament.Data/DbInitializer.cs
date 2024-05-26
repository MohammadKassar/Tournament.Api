using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using System.Threading.Tasks;

namespace Tournament.Data.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(TournamentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tournaments.Any())
            {
                return;   
            }

            var tournaments = new TournamentEntity[]
            {
                new TournamentEntity { Title = "Tournament 1", StartDate = DateTime.Now },
                new TournamentEntity { Title = "Tournament 2", StartDate = DateTime.Now }
            };

            foreach (var t in tournaments)
            {
                context.Tournaments.Add(t);
            }
            await context.SaveChangesAsync();

            var games = new Game[]
            {
                new Game { Title = "Game 1", Time = DateTime.Now, TournamentId = tournaments[0].Id },
                new Game { Title = "Game 2", Time = DateTime.Now, TournamentId = tournaments[1].Id }
            };

            foreach (var g in games)
            {
                context.Games.Add(g);
            }
            await context.SaveChangesAsync();
        }
    }
}
