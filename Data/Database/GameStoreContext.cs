using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.Entities;

namespace GameStore.Data.Database
{
    public class GameStoreContext : DbContext{
        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options){
        }

        public DbSet<Game> Games => Set<Game>();

        
    }
}