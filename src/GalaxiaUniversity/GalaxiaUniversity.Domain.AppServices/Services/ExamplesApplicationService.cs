namespace GalaxiaUniversity.Domain.AppServices.Services
{
    using Core.Behaviours.ExamplesApplicationService;
    using ExamplesHandlers;
    using GalaxiaUniversity.Core.Annotations;
    using GalaxiaUniversity.Core.Logging;
    using GalaxiaUniversity.Domain.Core.Behaviours;
    using NRepository.Core;
    using System.Threading.Tasks;
    using Utility.Logging;

    [GenerateTestFactory]
    public class ExamplesApplicationService : IExamplesApplicationService
    {
        private static readonly ILogger Logger = LogManager.CreateLogger(typeof(ExamplesApplicationService));
        private readonly IRepository _Repository;

        public ExamplesApplicationService(IRepository repository)
        {
            _Repository = repository;
        }

        public async Task<AddNewCountry.Response> AddNewCountryAsync(AddNewCountry.Request request)
        {
            return await Task.Run(() => AddNewCountry(request));
        }

        public AddNewCountry.Response AddNewCountry(AddNewCountry.Request request)
        {
            var retVal = Logger.TraceCall(() =>
            {
                var requestHandler = new AddNewCountryHandler(_Repository);
                var response = requestHandler.Handle(request);
                return response;
            });

            return retVal;
        }
    }
}
