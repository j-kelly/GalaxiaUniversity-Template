namespace GalaxiaUniversity.Core.Domain.InvariantValidation
{
    public interface IDomainAssertable
    {
        IInvariantValidation InvariantValidation { get; }

        void Assert(params object[] dependentServices);
    }
}