namespace GalaxiaUniversity.Web.Core.Repository
{
    using Domain.Core.Repository;
    using Interceptors;
    using NRepository.EntityFramework;

    public class GalaxiaUniversityWebQueryRepository : EntityFrameworkQueryRepository
    {
        public GalaxiaUniversityWebQueryRepository()
            : base(
                  new GalaxiaUniversityDbContext(),
                  new GalaxiaUniversityQueryInterceptor())
        {
        }
    }
}
