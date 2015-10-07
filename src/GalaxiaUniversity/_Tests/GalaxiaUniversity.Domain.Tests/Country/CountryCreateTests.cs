namespace GalaxiaUniversity.Domain.Tests.AppServices
{
    using Core.Behaviours.Country;
    using Domain.AppServices.Handlers;
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using NRepository.TestKit;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class CountryCreateTests
    {
        // I Prefer to leave this class at the top so easy to see what contistutes a valid request object
        private CountryCreate.Request CreateValidRequest(params Action<CountryCreate.Request>[] updates)
        {
            var commandModel = EntityGenerator.Create<CountryCreate.CommandModel>();

            var request = new CountryCreate.Request("UserId", commandModel);
            updates.ToList().ForEach(func => func(request));
            return request;
        }

        [Test]
        public void CheckInvariantValidation()
        {
            Action<CountryCreate.Request> CallSut = request =>
            {
                CountryHandlers.Handle(null, request);
            };

            Assert2.CheckInvariantValidation("CountryName cannot be null", () => CallSut(CreateValidRequest(p => p.CommandModel.Name = null)));
        }

        [Test]
        public void CheckValidationRules()
        {
            Func<CountryCreate.Request, ValidationMessageCollection> CallSut = request =>
            {
                var inMemoryRepository = new InMemoryRecordedRepository();
                var reponse = CountryHandlers.Handle(inMemoryRepository, request);
                return reponse.ValidationDetails;
            };


            var invalidRequest = CreateValidRequest(p => p.CommandModel.Name = "China", p => p.CommandModel.Population = 9);
            Assert2.CheckContextualValidation("Population", "Really? I think we all know China has a bigger population than that.", () => CallSut(invalidRequest));
        }


        // Add other tests here to prove it works
        [Test]
        public void WhenCountryCreateIsCalledThenIExpectItToDoSomething()
        {
        }
    }
}
