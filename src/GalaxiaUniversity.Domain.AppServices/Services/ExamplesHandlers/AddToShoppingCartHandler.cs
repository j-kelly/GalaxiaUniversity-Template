namespace GalaxiaUniversity.Domain.AppServices.Services.ExamplesHandlers
{
    using Core.Behaviours.ExamplesApplicationService;
    using GalaxiaUniversity.Core.Annotations;
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using NRepository.Core;

    [GenerateTestFactory]
    public class AddToShoppingCartHandler
    {
        private readonly IRepository _Repository;

        public AddToShoppingCartHandler(IRepository repository)
        {
            _Repository = repository;
        }

        public AddToShoppingCart.Response Handle(AddToShoppingCart.Request request)
        {
            var validationDetails = Validator.ValidateRequest(request);
            if (validationDetails.HasValidationIssues)
                return new AddToShoppingCart.Response(validationDetails);


            // ****************************************************************************
            //
            // Add your implementation here
            //
            // *****************************************************************************

            return new AddToShoppingCart.Response();
        }
    }
}
