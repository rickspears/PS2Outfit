namespace PS2Outfit.Data.Services
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using PS2Outfit.Entities;

    public class AppContext : DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }

        public AppContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
