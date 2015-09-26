namespace GalaxiaUniversity.Domain.Core.Repository
{
    using GalaxiaUniversity.Core.Logging;
    using GalaxiaUniversity.Domain.Core.Repository.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Utility.Logging;

    public class GalaxiaUniversityDbContext : DbContext
    {
        // To log all EF calls update the log config to :
        // <logger name = "EntityFramework" minlevel="Debug" writeTo="Ef" />
        private readonly static ILogger Logger = LogManager.CreateLogger("EntityFramework");

        static GalaxiaUniversityDbContext()
        {
        }

        public GalaxiaUniversityDbContext()
            : base("Name=GalaxiaUniversity")
        {
            Configuration.LazyLoadingEnabled = false;

            if (!Logger.IsDebugEnabled)
                return;

            Database.Log = p =>
            {
                // tidy up the log first
                if (string.IsNullOrWhiteSpace(p)
                    || p.Contains("-- Executing at")
                    || p.Contains("Closed connection")
                    || p.Contains("Opened connection"))
                    return;

                var log = p.Replace(Environment.NewLine, string.Empty)
                           .Replace("    ", string.Empty);

                Logger.Debug(log);
            };
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}