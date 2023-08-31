using InsanKaynaklariAPI.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace InsanKaynaklariAPI.Contexts {
    public class OrnekVeriTabaniContext : DbContext  {

        public OrnekVeriTabaniContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>()
                .HasOne(empl => empl.Company)
                .WithMany(comp => comp.Employees);

           
        }



    }
    }

