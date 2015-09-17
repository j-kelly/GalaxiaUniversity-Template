namespace NUnit.Framework
{
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using GalaxiaUniversity.Core.Domain.InvariantValidation;
    using Shouldly;
    using System;
    using System.Linq;

    public static class Assert2
    {
        public static void CheckInvariantValidation(string errorMsg, Action action)
        {
            Assert.Throws<InvariantValidationException>(() =>
            {
                try { action(); }
                catch (InvariantValidationException) { throw; }
                catch { }
            }, string.Format("Missing invariant validation check: {0}", errorMsg));
        }

        public static void CheckContextualValidation(string errorMessage, Func<ValidationMessageCollection> func)
        {
            try
            {
                var validationaction = func();
                validationaction.AllValidationMessages.Count().ShouldBe(1, string.Format("Missing validation check: {0}", errorMessage));
            }
            catch (InvariantValidationException) { throw; }
            catch (AssertionException aEx) { Assert.Fail(aEx.Message); }
            catch { Assert.Fail(string.Format("Missing validation: {0}", errorMessage)); }
        }

        public static void CheckContextualValidation(string propertyName, string errorMessage, Func<ValidationMessageCollection> func)
        {
            try
            {
                var validationaction = func();

                var msg = validationaction.Errors.SingleOrDefault(p => p.ErrorMessage == errorMessage && p.PropertyName == propertyName);
                msg.ShouldNotBe(null, string.Format("Missing validation check: {0}", errorMessage));
            }
            catch (InvariantValidationException) { throw; }
            catch (AssertionException aEx) { Assert.Fail(aEx.Message); }
            catch { Assert.Fail(string.Format("Missing validation: {0}", errorMessage)); }
        }
    }
}
