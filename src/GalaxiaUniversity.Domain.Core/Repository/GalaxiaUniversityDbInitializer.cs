namespace GalaxiaUniversity.Domain.Core.Repository
{
    using GalaxiaUniversity.Domain.Core.Repository.Entities;
    using System.Collections.Generic;
    using System.Data.Entity;

    public sealed class GalaxiaUniversityDbInitializer : DropCreateDatabaseIfModelChanges<GalaxiaUniversityDbContext>
    {
        // set to false when running selenium tests
        public static bool AllowDatabaseSeed { get; set; } = true;

        protected override void Seed(GalaxiaUniversityDbContext context)
        {
            var countries = new List<Country>();
        }
    }
}