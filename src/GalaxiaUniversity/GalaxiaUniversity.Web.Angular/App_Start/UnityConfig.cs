namespace GalaxiaUniversity.Web.Angular
{
    using Core.Repository;
    using GalaxiaUniversity.Domain.AppServices.Services;
    using GalaxiaUniversity.Domain.Core.Behaviours;
    using GalaxiaUniversity.Domain.Core.Repository;
    using Microsoft.Practices.Unity;
    using NRepository.Core;
    using NRepository.Core.Query;
    using NRepository.EntityFramework;
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

            // Queries and commands
            container.RegisterType<IRepository, EntityFrameworkRepository>();
            container.RegisterType<EntityFrameworkRepository>(new InjectionConstructor(
                typeof(GalaxiaUniversityDbContext)));

            // Domain application services
            container.RegisterType<IExamplesApplicationService, ExamplesApplicationService>();
        }
    }
}