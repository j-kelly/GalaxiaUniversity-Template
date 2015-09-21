namespace GalaxiaUniversity.Web.Angular.Controllers
{
    using Core.Repository.Projections;
    using Domain.Core.Behaviours;
    using Domain.Core.Repository.Entities;
    using GalaxiaUniversity.Core.Annotations;
    using GalaxiaUniversity.Core.Logging;
    using NRepository.Core.Query;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Utility.Logging;

    [RoutePrefix("api/Main")]
    [GenerateTestFactory]
    public class MainController : ApiController
    {
        private static readonly ILogger Logger = LogManager.CreateLogger<MainController>();

        private readonly IQueryRepository _QueryRepository;
        private readonly IExamplesApplicationService _ExamplesService;

        public MainController(IQueryRepository queryRepository, IExamplesApplicationService examplesService)
        {
            _ExamplesService = examplesService;
            _QueryRepository = queryRepository;
        }

        [Route("LoadDetails")]
        public async Task<HttpResponseMessage> GetPageDetails()
        {
            Logger.Debug("GetPageDetails called");

            var data = new
            {
                countries = await _QueryRepository.GetEntities<Country>().Select(p => new { name = p.Name, population = p.Population }).AsAsync(),
                countriesBySql = await _QueryRepository.GetEntities<CountryBySql>().Select(p => new { name = p.Name, population = p.Population }).AsAsync(),
                whatsTrending = new[] { "B&W TVs", "MS DOS", "45rpm records", "ZX81" }
            };

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}

