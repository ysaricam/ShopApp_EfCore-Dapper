using ShopApp.Domain.Abstractions;

namespace ShopApp.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; private set; }
    
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    
    protected Entity(Guid id)
    { 
        Id = id;
    }

    protected Entity(){}
    
    /// <summary>
    /// Varlıklar (Product, Order), durumları değiştiğinde
    /// bu metodu çağırarak bir olayı listeye ekler.
    /// </summary>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    /// <summary>
    /// Olaylar fırlatıldıktan sonra bu listeyi temizlemek için
    /// (Application katmanındaki UnitOfWork tarafından çağrılacak).
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
    
    
}