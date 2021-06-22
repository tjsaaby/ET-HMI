using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HMI.Models;

namespace HMI.Data
{
    public class HMIContext : DbContext
    {
        public HMIContext (DbContextOptions<HMIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sheet>()
                .Property(s => s.SheetID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Names>()
                .Property(n=>n.NameID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sheet>()
            .HasMany(s => s.Names)
            .WithOne(n => n.Sheet)
            .IsRequired();
            //.OnDelete(DeleteBehavior.SetNull); // sets the foreign key value of the dependent entity to null in the event that the principal is deleted:
        }

        public DbSet<HMI.Models.Names> Names { get; set; }

        public DbSet<HMI.Models.Sheet> Sheet { get; set; }

       

    }
}
