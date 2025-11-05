using ShopApp.Domain.Abstractions;

namespace ShopApp.Domain.Events;

public record OrderCancelled(Guid OrderId, DateTime OccurredOn) : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();
}