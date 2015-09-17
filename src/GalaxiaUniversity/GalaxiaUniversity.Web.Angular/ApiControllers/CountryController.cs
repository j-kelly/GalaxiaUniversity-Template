namespace GalaxiaUniversity.Web.Angular.Controllers
{
    using Domain.Core.Behaviours;
    using Domain.Core.Repository.Entities;
    using GalaxiaUniversity.Core.Annotations;
    using GalaxiaUniversity.Core.Logging;
    using NRepository.Core.Query;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Utility.Logging;

    [GenerateTestFactory]
    public class CountryController : ApiController
    {
        private static readonly ILogger Logger = LogManager.CreateLogger<CountryController>();

        private readonly IQueryRepository _QueryRepository;
        private readonly IExamplesApplicationService _ExamplesService;
        public CountryController(IQueryRepository queryRepository, IExamplesApplicationService examplesService)
        {
            _ExamplesService = examplesService;
            _QueryRepository = queryRepository;
        }

        // GET: api/Country
        [ActionName("GetAllCountries")]
        public async Task<IEnumerable<object>> GetAllCountries()
        {
            Logger.Debug("CountryController::GetAllCountries() called.");

            return await _QueryRepository
                .GetEntities<Country>()
                .Select(p => new
                {
                    country = p.Name,
                    population = p.Population
                }).AsAsync();
        }
    }
}
