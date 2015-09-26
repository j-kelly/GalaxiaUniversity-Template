namespace GalaxiaUniversity.Domain.Core.Repository
{
    using Entities;
    using NRepository.EntityFramework;
    using System.Data.Entity.Migrations;

    internal sealed class GalaxiaUniversityDbInitializer : DbMigrationsConfiguration<GalaxiaUniversityDbContext>
    {
        protected override void Seed(GalaxiaUniversityDbContext context)
        {
            var countries = new[]
            {
                new Country ("Spain", 12345),
                new Country ("Uk", 42345),
                new Country ("Italy", 145),
                new Country ("France", 1),
                new Country ("Holland", 32),
                new Country ("Sweden", 133),
                new Country ("Denmark", 1244345),
            };

            var repository = new EntityFrameworkRepository(context);
            repository.AddRange(countries);
            repository.Save();
        }
    }
}
