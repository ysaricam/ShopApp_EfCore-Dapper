using ShopApp.Domain.Abstractions;
using ShopApp.Domain.ValueObjects;

namespace ShopApp.Domain.Events;

public record ProductPriceChanged(Guid ProductId, Money OldPrice, Money NewPrice, DateTime OccurredOn) : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();

}
