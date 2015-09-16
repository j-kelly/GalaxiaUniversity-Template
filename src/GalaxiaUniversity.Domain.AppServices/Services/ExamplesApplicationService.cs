namespace GalaxiaUniversity.Domain.AppServices.Services
{
    using Core.Behaviours.ExamplesApplicationService;
    using ExamplesHandlers;
    using GalaxiaUniversity.Core.Annotations;
    using GalaxiaUniversity.Core.Logging;
    using GalaxiaUniversity.Domain.Core.Behaviours;
    using NRepository.Core;
    using Utility.Logging;

    [GenerateTestFactory]
    public class ExamplesApplicationService : IExamplesApplicationService
    {
        private static readonly ILogger Logger = LogManager.CreateLogger(typeof(ExamplesApplicationService));
        private readonly IRepository _Repository;

        public ExamplesApplicationService(IRepository repository)
        {
            _Repository = repository;
        }

        public AddToShoppingCart.Response AddToShoppingCart(AddToShoppingCart.Request request)
        {
            var retVal = Logger.TraceCall(() =>
            {
                var requestHandler = new AddToShoppingCartHandler(_Repository);
                var response = requestHandler.Handle(request);
                return response;
            });

            return retVal;
        }
    }
}
