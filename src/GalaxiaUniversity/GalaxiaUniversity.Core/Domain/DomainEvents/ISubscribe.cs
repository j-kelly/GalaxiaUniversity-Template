namespace GalaxiaUniversity.Core.Domain.DomainEvents
{
    public interface ISubscribe<in T> where T : class, GalaxiaUniversity.Core.Domain.DomainEvents.IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
