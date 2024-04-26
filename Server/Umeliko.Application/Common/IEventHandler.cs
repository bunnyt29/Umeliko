namespace Umeliko.Application.Common;

using Domain.Common;

public interface IEventHandler<in TEvent>
    where TEvent : IDomainEvent
{
    Task Handle(TEvent domainEvent);
}
