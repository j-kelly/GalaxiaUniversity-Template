namespace GalaxiaUniversity.Web.Core.Repository.Projections
{
    using NRepository.Core.Query;
    using NRepository.Core.Query.Interceptors.Factories;
    using NRepository.EntityFramework;
    using System.Linq;

    public class CountryBySql
    {
        public class FactoryQuery : FactoryQuery<CountryBySql>
        {
            public override IQueryable<object> Query<TEntity>(IQueryRepository repository, object additionalQueryData)
            {
                string sql = "SELECT Id, Name, Population FROM dbo.COUNTRY";
                var countryBySql = repository.ExecuteSqlQuery<CountryBySql>(sql);
                return countryBySql.AsQueryable();
            }
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int Population { get; private set; }
    }
}
