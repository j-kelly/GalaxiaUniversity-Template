namespace GalaxiaUniversity.Domain.Tests.AppServices
{
    using Core.Behaviours.ExamplesApplicationService;
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using NRepository.TestKit;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using TestKit.Factories;

    [TestFixture]
    public class AddNewCountryHandlerTests
    {
        // I Prefer to leave this class at the top so easy to see what contistutes a valid request object
        private AddNewCountry.Request CreateValidRequest(params Action<AddNewCountry.Request>[] updates)
        {
            var commandModel = EntityGenerator.Create<AddNewCountry.CommandModel>();

            var request = new AddNewCountry.Request("UserId", commandModel);
            updates.ToList().ForEach(func => func(request));
            return request;
        }

        [Test]
        public void CheckInvariantValidation()
        {
            Action<AddNewCountry.Request> CallSut = request =>
            {
                var serviceUnderTest = new AddNewCountryHandlerFactory().Object;
                serviceUnderTest.Handle(request);
            };

            Assert2.CheckInvariantValidation("CountryName cannot be null", () => CallSut(CreateValidRequest(p => p.CommandModel.Name = null)));
        }

        [Test]
        public void CheckValidationRules()
        {
            Func<AddNewCountry.Request, ValidationMessageCollection> CallSut = request =>
            {
                var serviceUnderTest = new AddNewCountryHandlerFactory().Object;
                var reponse = serviceUnderTest.Handle(request);
                return reponse.ValidationDetails;
            };


            var invalidRequest = CreateValidRequest(p => p.CommandModel.Name = "China", p => p.CommandModel.Population = 9);
            Assert2.CheckContextualValidation("Population", "Really? I think we all know China has a bigger population than that.", () => CallSut(invalidRequest));
        }


        // Add other tests here to prove it works
        [Test]
        public void WhenAddNewCountryIsCalledThenIExpectItToDoSomething()
        {
        }
    }
}
