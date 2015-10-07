namespace GalaxiaUniversity.Web.Angular
{
    using Core.Repository;
    using Microsoft.Practices.Unity;
    using NRepository.Core.Query;
    using System.Web.Http;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            // Queries only
            container.RegisterType<IQueryRepository, GalaxiaUniversityWebQueryRepository>();
        }
    }
}