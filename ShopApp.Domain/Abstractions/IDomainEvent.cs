namespace ShopApp.Domain.Abstractions;

public interface IDomainEvent
{
    public Guid EventId { get;}
    
    public DateTime OccurredOn { get;}
}