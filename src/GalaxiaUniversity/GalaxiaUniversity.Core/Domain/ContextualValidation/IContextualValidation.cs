namespace GalaxiaUniversity.Core.Domain.ContextualValidation
{
    public interface IContextualValidation
    {
        ValidationMessageCollection Validate(params object[] dependentServices);
    }
}