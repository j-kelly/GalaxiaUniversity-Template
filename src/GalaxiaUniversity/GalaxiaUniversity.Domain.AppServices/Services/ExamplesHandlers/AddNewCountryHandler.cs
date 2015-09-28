namespace GalaxiaUniversity.Domain.AppServices.Services.ExamplesHandlers
{
    using Core.Behaviours.ExamplesApplicationService;
    using Core.Repository.Entities;
    using GalaxiaUniversity.Core.Annotations;
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using NRepository.Core;

    [GenerateTestFactory]
    public class AddNewCountryHandler
    {
        private readonly IRepository _Repository;

        public AddNewCountryHandler(IRepository repository)
        {
            _Repository = repository;
        }

        public AddNewCountry.Response Handle(AddNewCountry.Request request)
        {
            var validationDetails = Validator.ValidateRequest(request);
            if (validationDetails.HasValidationIssues)
                return new AddNewCountry.Response(validationDetails: validationDetails);

            var country = new Country(request.CommandModel.Name, request.CommandModel.Population);
            _Repository.Add(country);
            _Repository.Save();

            return new AddNewCountry.Response(country.Id);
        }
    }
}
