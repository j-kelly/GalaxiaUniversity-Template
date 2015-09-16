namespace GalaxiaUniversity.Core.Domain.InvariantValidation
{
    public interface IInvariantValidation
    {
        void StartAsserting(params object[] dependentServices);
    }
}
