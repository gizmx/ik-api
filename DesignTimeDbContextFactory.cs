using InsanKaynaklariAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InsanKaynaklariAPI {

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrnekVeriTabaniContext> {
        public OrnekVeriTabaniContext CreateDbContext(string[] args) {
            DbContextOptionsBuilder<OrnekVeriTabaniContext> dbContextOptionsBuilder = new();
   dbContextOptionsBuilder.UseNpgsql("Host=localhost;Database=IK;Username=postgres;Password=2389");
            return new(dbContextOptionsBuilder.Options);

        }
    }
}
