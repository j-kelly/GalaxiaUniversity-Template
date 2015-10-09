namespace GalaxiaUniversity.Web.Angular.ApiControllers
{
    using Domain.Core.Behaviours.Country;
    using GalaxiaUniversity.Core.Domain;
    using GalaxiaUniversity.Core.Domain.Services;
    using NRepository.Core.Query;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class CountryController : ApiController
    {
        private readonly IQueryRepository _QueryRepository;

        public CountryController(IQueryRepository queryRepository)
        {
            _QueryRepository = queryRepository;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddCountry(CountryCreate.CommandModel commandModel)
        {
            var request = new CountryCreate.Request(SystemPrincipal.Name, commandModel);
            var response = await DomainServices.CallServiceAsync<CountryCreate.Response>(request);

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
