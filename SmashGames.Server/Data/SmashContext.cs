using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmashGames.Server.Models;

namespace SmashGames.Server.Data
{
    public class SmashContext : DbContext
    {
        public SmashContext (DbContextOptions<SmashContext> options)
            : base(options)
        {
        }

        public DbSet<Studio> Studio { get; set; } = default!;
        public DbSet<Game> Games { get; set; } = default!;
        public DbSet<GameFeature> GameFeatures { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Studio>().Navigation(m => m.Games).AutoInclude();
            modelBuilder.Entity<Game>().Navigation(g => g.Features).AutoInclude();
        }
    }
}
