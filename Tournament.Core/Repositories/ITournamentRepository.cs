﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<TournamentEntity>> GetAllAsync();
        Task<TournamentEntity?> GetAsync(int id); 
        Task<bool> AnyAsync(int id);    
        void Add(TournamentEntity tournament);
        void Update(TournamentEntity tournament);
        void Remove(TournamentEntity tournament);
        Task<int> SaveChangesAsync();
    }
}
