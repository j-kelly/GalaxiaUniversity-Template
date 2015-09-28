namespace GalaxiaUniversity.Web.Angular.ApiControllers
{
    using GalaxiaUniversity.Domain.Core.Behaviours;
    using GalaxiaUniversity.Domain.Core.Behaviours.ExamplesApplicationService;
    using NRepository.Core.Query;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class CountryController : ApiController
    {
        private readonly IExamplesApplicationService _AppService;
        private readonly IQueryRepository _QueryRepository;

        public CountryController(IQueryRepository queryRepository, IExamplesApplicationService appService)
        {
            _QueryRepository = queryRepository;
            _AppService = appService;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddCountry(AddNewCountry.CommandModel commandModel)
        {
            var response = await _AppService.AddNewCountryAsync(new AddNewCountry.Request(
                SystemPrincipal.Name,
                commandModel));

            var keyPairs = response.ValidationDetails.AsKeyValuePairs();
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                response.Id,
                ErrorMessages = keyPairs,
                BigErrorMessage = keyPairs.Any()
                    ? keyPairs.Select(p => p.Value).Aggregate((l, r) => $"{l}{Environment.NewLine}{r}")
                    : null,
            });
        }
    }
}
