namespace GalaxiaUniversity.Web.Angular
{
    using GalaxiaUniversity.Domain.AppServices.Services;
    using GalaxiaUniversity.Domain.Core.Behaviours;
    using GalaxiaUniversity.Domain.Core.Repository;
    using Core.Repository.Interceptors;
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
            container.RegisterType<IQueryRepository, EntityFrameworkQueryRepository>();
            container.RegisterType<EntityFrameworkQueryRepository>(new InjectionConstructor(
                typeof(GalaxiaUniversityDbContext),
                typeof(GalaxiaUniversityQueryInterceptor)));

            // Queries and commands
            container.RegisterType<IRepository, EntityFrameworkRepository>();
            container.RegisterType<EntityFrameworkRepository>(new InjectionConstructor(
                typeof(GalaxiaUniversityDbContext)));

            // Domain application services
            container.RegisterType<IExamplesApplicationService, ExamplesApplicationService>();
        }
    }
}