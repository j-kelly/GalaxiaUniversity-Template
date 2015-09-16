namespace GalaxiaUniversity.Web.Angular.Controllers
{
    using Core.Annotations;
    using Domain.Core.Behaviours;
    using NRepository.Core.Query;
    using System.Collections.Generic;
    using System.Web.Http;

    [GenerateTestFactory]
    public class CountryController : ApiController
    {
        private readonly IQueryRepository _QueryRepository;
        private readonly IExamplesApplicationService _ExamplesService;
        public CountryController(IQueryRepository queryRepository, IExamplesApplicationService examplesService)
        {
            _ExamplesService = examplesService;
            _QueryRepository = queryRepository;
        }

        // GET: api/Country
        [ActionName("GetAllCountries")]
        public IEnumerable<object> GetAllCountries()
        {
            return new object[] {
                new {country="Spain", population=1234},
                new {country="Spain", population=1234},
                new {country="Spain", population=1234},
                new {country="Spain", population=1234},
                new {country="Spain", population=1234},
                new {country="Spain", population=1234},
                new {country="Spain", population=1234},
                new {country="Spain", population=1234},
                new {country="Uk", population=1534},
                new {country="Canada", population=67234},
                new {country="Mexico", population=123},
            };

        }
    }
}
