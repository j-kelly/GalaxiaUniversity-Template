namespace GalaxiaUniversity.Core.Domain.DomainEvents
{
    public interface IDomainEventHandler
    {
        void Handle<T>(T domainEvent) where T : class, GalaxiaUniversity.Core.Domain.DomainEvents.IDomainEvent;
    }
}
