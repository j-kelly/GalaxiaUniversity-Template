namespace GalaxiaUniversity.Domain.Core.Behaviours
{
    using GalaxiaUniversity.Domain.Core.Behaviours.ExamplesApplicationService;
    using System.Threading.Tasks;

    public interface IExamplesApplicationService
    {
        Task<AddNewCountry.Response> AddNewCountryAsync(AddNewCountry.Request request);

        AddNewCountry.Response AddNewCountry(AddNewCountry.Request request);

    }
}
