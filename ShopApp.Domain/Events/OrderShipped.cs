using ShopApp.Domain.Abstractions;

namespace ShopApp.Domain.Events;

public record OrderShipped(Guid OrderId, DateTime OccurredOn) : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();

}