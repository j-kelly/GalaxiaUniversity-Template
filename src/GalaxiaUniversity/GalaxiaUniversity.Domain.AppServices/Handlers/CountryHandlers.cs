namespace GalaxiaUniversity.Domain.AppServices.Handlers
{
    using Core.Behaviours.Country;
    using Core.Repository.Entities;
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using NRepository.Core;

    public static class CountryHandlers
    {
        public static CountryCreate.Response Handle(IRepository repository, CountryCreate.Request request)
        {
            var validationDetails = Validator.ValidateRequest(request);
            if (validationDetails.HasValidationIssues)
                return new CountryCreate.Response(validationDetails: validationDetails);

            var country = new Country(request.CommandModel.Name, request.CommandModel.Population);
            repository.Add(country);
            repository.Save();

            return new CountryCreate.Response(country.Id);
        }
    }
}
