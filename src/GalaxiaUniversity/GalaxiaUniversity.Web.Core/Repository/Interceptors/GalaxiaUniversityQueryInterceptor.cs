namespace GalaxiaUniversity.Web.Core.Repository.Interceptors
{
    using Cache;
    using NRepository.Core.Query.Interceptors.Factories;
    using System.Collections.Generic;

    public class GalaxiaUniversityQueryInterceptor : FactoryQueryInterceptor
    {
        private static readonly IEnumerable<IFactoryQuery> AllQueryFactories = new IFactoryQuery[]
        {
            // Caching
            new EfCacheableFactoryQuery(),
            new CacheableProjectionFactoryQuery(),

            // Projections

            // Filters
        };

        public GalaxiaUniversityQueryInterceptor()
            : base(AllQueryFactories)
        {
        }
    }
}
