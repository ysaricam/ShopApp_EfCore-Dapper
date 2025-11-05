using ShopApp.Domain.Abstractions;
using ShopApp.Domain.ValueObjects;

namespace ShopApp.Domain.Events;

public record InventoryDecreased(Guid ProductId, Quantity Delta, DateTime OccurredOn) : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();
}
