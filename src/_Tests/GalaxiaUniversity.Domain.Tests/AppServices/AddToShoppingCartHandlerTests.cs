namespace GalaxiaUniversity.Domain.Tests.AppServices
{
    using Core.Behaviours.ExamplesApplicationService;
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using TestKit.Factories;
    using NRepository.TestKit;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class AddToShoppingCartHandlerTests
    {
        // Prefer to leave this class at the top so easy to see what contistutes a valid command object
        public AddToShoppingCart.Request CreateValidRequest(params Action<AddToShoppingCart.Request>[] updates)
        {
            var commandModel = EntityGenerator.Create<AddToShoppingCart.CommandModel>();

            var request = new AddToShoppingCart.Request("UserId", commandModel);
            updates.ToList().ForEach(func => func(request));
            return request;
        }

        [Test]
        public void CheckInvariantValidation()
        {
            Action<AddToShoppingCart.Request> CallSut = request =>
            {
                var serviceUnderTest = new AddToShoppingCartHandlerFactory().Object;
                serviceUnderTest.Handle(request);
            };

            // Assert2.CheckInvariantValidation("[ErrorMessage]", () => CallSut(CreateValidRequest(p => p.CommandModel. )));
        }

        [Test]
        public void CheckValidationRules()
        {
            Func<AddToShoppingCart.Request, ValidationMessageCollection> CallSut = request =>
            {
                var serviceUnderTest = new AddToShoppingCartHandlerFactory().Object;
                var reponse = serviceUnderTest.Handle(request);
                return reponse.ValidationDetails;
            };

            // Assert2.CheckValidation( "[ExpectedMessage]", "[PropertyName]", () => CallSut(CreateValidRequest(p => p.CommandModel.DummyValue = "1")));           
        }

        [Test]
        public void WhenAddToShoppingCartIsCalledThenIExpectItToDoSomething()
        {
        }
    }
}
