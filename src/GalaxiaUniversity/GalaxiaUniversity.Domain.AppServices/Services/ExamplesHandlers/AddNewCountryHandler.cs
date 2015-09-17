namespace GalaxiaUniversity.Domain.AppServices.Services.ExamplesHandlers
{
    using Core.Behaviours.ExamplesApplicationService;
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
                return new AddNewCountry.Response(validationDetails);


            // ****************************************************************************
            //
            // Add your implementation here
            //
            // *****************************************************************************

            return new AddNewCountry.Response();
        }
    }
}
