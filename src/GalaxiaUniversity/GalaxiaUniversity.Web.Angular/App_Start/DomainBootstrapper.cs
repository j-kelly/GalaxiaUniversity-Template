using GalaxiaUniversity.Core.Domain;
namespace GalaxiaUniversity.Web.Angular.App_Start
{
    using GalaxiaUniversity.Core.Logging;
    using GalaxiaUniversity.Domain.AppServices.Handlers;
    using GalaxiaUniversity.Domain.Core.Behaviours.Country;
    using GalaxiaUniversity.Domain.Core.Repository;
    using NRepository.Core;
    using NRepository.EntityFramework;
    using System;

    public class DomainBootstrapper
    {
        public static void Initialise()
        {
            // create repository
            Func<IRepository> CreateRepository = () => new EntityFrameworkRepository(new GalaxiaUniversityDbContext());

            // Country
            DomainServices.AddService<CountryCreate.Request>(request => Log(request, p => CountryHandlers.Handle(CreateRepository(), request)));
            //DomainServices.AddService<CountryCreate.Request>(request => p => CountryHandlers.Handle(CreateRepository(), request));
        }

        private static IDomainResponse Log<T>(T command, Func<T, IDomainResponse> next) where T : class, IDomainRequest
        {
            var logger = LogManager.CreateLogger<T>();
            var retVal = logger.TraceCall(() => next(command));
            return retVal;
        }
    }
}