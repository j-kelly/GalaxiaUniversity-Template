namespace GalaxiaUniversity.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [Serializable]
    [ExcludeFromCodeCoverage]
    public class GalaxiaUniversityException : Exception
    {
        public GalaxiaUniversityException()
        {
        }

        public GalaxiaUniversityException(string message)
            : base(message)
        {
        }

        public GalaxiaUniversityException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected GalaxiaUniversityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
