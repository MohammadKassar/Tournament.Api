using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TournamentContext _context;

        public TournamentRepository(TournamentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TournamentEntity>> GetAllAsync()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public async Task<TournamentEntity?> GetAsync(int id)
        {
            return await _context.Tournaments.FindAsync(id);

        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Tournaments.AnyAsync(t => t.Id == id);
        }

        public void Add(TournamentEntity tournament)
        {
            _context.Tournaments.Add(tournament);
        }

        public void Update(TournamentEntity tournament)
        {
            _context.Tournaments.Update(tournament);
        }

        public void Remove(TournamentEntity tournament)
        {
            _context.Tournaments.Remove(tournament);
        }
        public async Task<int> SaveChangesAsync() 
        {
            return await _context.SaveChangesAsync();
        }
    }
}

