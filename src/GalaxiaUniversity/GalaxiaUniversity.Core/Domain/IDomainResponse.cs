namespace GalaxiaUniversity.Core.Domain
{
    using GalaxiaUniversity.Core.Domain.ContextualValidation;

    public interface IDomainResponse
    {
        ValidationMessageCollection ValidationDetails { get; }
        bool HasValidationIssues { get; }
    }
}
