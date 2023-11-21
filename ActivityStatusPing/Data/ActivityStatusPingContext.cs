using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActivityStatusPing.Models;

namespace ActivityStatusPing.Data
{
    public class ActivityStatusPingContext : DbContext
    {
        public ActivityStatusPingContext (DbContextOptions<ActivityStatusPingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    Username = "Josh",
                    LastActive = DateTime.UtcNow
                },
                new User()
                {
                    Id = 2,
                    Username = "Michelle",
                    LastActive = DateTime.UtcNow
                },
                new User()
                {
                    Id = 3,
                    Username = "Shane",
                    LastActive = DateTime.UtcNow
                }
                );
        }

        public DbSet<ActivityStatusPing.Models.User> User { get; set; } = default!;
    }
}
