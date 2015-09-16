namespace GalaxiaUniversity.Domain.Core.Repository
{
    using GalaxiaUniversity.Domain.Core.Repository.Entities;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class GalaxiaUniversityDbContext : DbContext
    {
        static GalaxiaUniversityDbContext()
        {
            Database.SetInitializer(new GalaxiaUniversityDbInitializer());
        }

        public GalaxiaUniversityDbContext()
            : base("Name=GalaxiaUniversity")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }
    }
}