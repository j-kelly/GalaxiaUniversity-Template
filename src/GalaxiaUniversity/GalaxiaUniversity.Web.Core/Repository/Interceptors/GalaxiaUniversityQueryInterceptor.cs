namespace GalaxiaUniversity.Web.Core.Repository.Interceptors
{
    using Cache;
    using NRepository.Core.Query.Interceptors.Factories;
    using Projections;
    using System.Collections.Generic;

    public class GalaxiaUniversityQueryInterceptor : FactoryQueryInterceptor
    {
        private static readonly IEnumerable<IFactoryQuery> AllQueryFactories = new IFactoryQuery[]
        {
            // Caching
            new EfCacheableFactoryQuery(),
            new CacheableProjectionFactoryQuery(),

            // Projections
            new CountryBySql.FactoryQuery()

            // Filters
        };

        public GalaxiaUniversityQueryInterceptor()
            : base(AllQueryFactories)
        {
        }
    }
}
