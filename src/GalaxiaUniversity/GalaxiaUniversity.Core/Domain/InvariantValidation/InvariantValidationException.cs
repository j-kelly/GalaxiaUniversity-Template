namespace GalaxiaUniversity.Core.Domain.InvariantValidation
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [Serializable]
    [ExcludeFromCodeCoverage]
    public class InvariantValidationException : GalaxiaUniversityException
    {
        public InvariantValidationException(string message)
            : base(message)
        {
        }

        public InvariantValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
