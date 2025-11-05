using ShopApp.Domain.Enums;
using ShopApp.Domain.ValueObjects;
using ShopApp.Domain.Events;

namespace ShopApp.Domain.Entities;

public class Order : Entity
{
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Money Total
    {
        get
        {
            decimal totalAmount = _items.Sum(item => item.Subtotal.Amount);
            return new Money(totalAmount, "TRY");
        }
    }
    
    public Order(Guid id, Guid customerId) : base(id)
    {
        CustomerId = customerId;
        Status = OrderStatus.Pending; 
        CreatedAt = DateTime.UtcNow;
        
        AddDomainEvent(new OrderCreated(this.Id, this.CustomerId, this.CreatedAt));
    }
    
    private Order() : base() { }
    
    public void AddItem(Guid productId, Quantity quantity, Money unitPrice)
    {
        if (Status != OrderStatus.Pending)
        {
            throw new InvalidOperationException("Sadece 'Beklemede' olan siparişlere ürün eklenebilir.");
        }
        
        var newItem = new OrderItem(
            Guid.NewGuid(), 
            this.Id, 
            productId, 
            quantity, 
            unitPrice);
            
        _items.Add(newItem);
    }

    public void RemoveItem(Guid orderItemId)
    {
        if (Status != OrderStatus.Pending)
        {
            throw new InvalidOperationException("Sadece 'Beklemede' olan siparişlerden ürün silinebilir.");
        }

        var item = _items.FirstOrDefault(i => i.Id == orderItemId);
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public void MarkPaid()
    {
        if (Status != OrderStatus.Pending)
        {
            throw new InvalidOperationException("Sadece 'Beklemede' olan siparişler 'Ödendi' olarak işaretlenebilir.");
        }
        Status = OrderStatus.Paid;
        
        AddDomainEvent(new OrderPaid(this.Id, DateTime.UtcNow));
        
    }

    public void Ship()
    {
        if (Status != OrderStatus.Paid)
        {
            throw new InvalidOperationException("Sadece 'Ödendi' olan siparişler 'Kargolandı' olarak işaretlenebilir.");
        }
        Status = OrderStatus.Shipped;
        
        AddDomainEvent(new OrderShipped(this.Id, DateTime.UtcNow));
        
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped)
        {
            throw new InvalidOperationException("Kargolanmış sipariş iptal edilemez.");
        }
        Status = OrderStatus.Cancelled;
        
        AddDomainEvent(new OrderCancelled(this.Id, DateTime.UtcNow));
        
    }
}