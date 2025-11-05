using ShopApp.Domain.Abstractions;

namespace ShopApp.Domain.Events;

/// <summary>
/// Bir siparişin ödemesi başarıyla alındığında tetiklenir.
/// </summary>
public record OrderPaid(Guid OrderId, DateTime OccurredOn) : IDomainEvent
{
   public Guid EventId { get; } = Guid.NewGuid();
}