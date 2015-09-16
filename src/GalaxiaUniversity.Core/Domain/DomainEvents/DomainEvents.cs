namespace GalaxiaUniversity.Core.Domain.DomainEvents
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class DomainEvents
    {
        private static GalaxiaUniversity.Core.Domain.DomainEvents.IDomainEventHandler eventHandler = new GalaxiaUniversity.Core.Domain.DomainEvents.BlankDomainEventHandler();

        public static void SetDomainEventHandler(GalaxiaUniversity.Core.Domain.DomainEvents.IDomainEventHandler newHandler)
        {
            eventHandler = newHandler;
        }

        public static void Raise<T>(T domainEvent) where T : class, GalaxiaUniversity.Core.Domain.DomainEvents.IDomainEvent
        {
            eventHandler.Handle(domainEvent);
        }
    }
}
