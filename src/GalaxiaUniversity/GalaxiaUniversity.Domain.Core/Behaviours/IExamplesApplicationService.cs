namespace GalaxiaUniversity.Domain.Core.Behaviours
{
    using GalaxiaUniversity.Domain.Core.Behaviours.ExamplesApplicationService;

    public interface IExamplesApplicationService
    {
        AddNewCountry.Response AddNewCountry(AddNewCountry.Request request);
    }
}
