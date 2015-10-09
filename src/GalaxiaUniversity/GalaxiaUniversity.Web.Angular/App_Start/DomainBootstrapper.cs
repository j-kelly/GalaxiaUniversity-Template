using GalaxiaUniversity.Core.Domain;
namespace GalaxiaUniversity.Web.Angular.App_Start
{
    using GalaxiaUniversity.Core.Domain.Services;
    using GalaxiaUniversity.Core.Logging;
    using GalaxiaUniversity.Domain.AppServices.Handlers;
    using GalaxiaUniversity.Domain.Core.Behaviours.Country;
    using GalaxiaUniversity.Domain.Core.Repository;
    using NRepository.Core;
    using NRepository.EntityFramework;
    using System;
    using System.Linq.Expressions;

    public class DomainBootstrapper
    {
        public static void Initialise()
        {
            // create repository
            Func<IRepository> CreateRepository = () => new EntityFrameworkRepository(new GalaxiaUniversityDbContext());

            // Country
            DomainServices.AddService<CountryCreate.Request>(request => DefaultDecorator(request, p => CountryHandlers.Handle(CreateRepository(), request)));
            //DomainServices.AddService<CountryCreate.Request>(request => p => CountryHandlers.Handle(CreateRepository(), request));
        }

        private static IDomainResponse DefaultDecorator<T>(T command, Expression<Func<T, IDomainResponse>> handler) where T : class, IDomainRequest
        {
            // create chain (last to first)
            Expression<Func<T, IDomainResponse>> autoDispose = p => Decorators.AutoDispose(handler);
            Expression<Func<T, IDomainResponse>> log = p => Decorators.Log(command, autoDispose);

            // Run it
            return log.Compile().Invoke(command);
        }
    }
}