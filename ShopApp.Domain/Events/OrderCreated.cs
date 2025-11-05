using ShopApp.Domain.Abstractions;

namespace ShopApp.Domain.Events;

public record OrderCreated(Guid OrderId, Guid CustomerId, DateTime OccurredOn) : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();

}
