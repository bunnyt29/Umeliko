namespace Umeliko.Infrastructure.Common.Events;

using Domain.Common;

internal interface IEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent);
}
