using ShopApp.Domain.ValueObjects;

namespace ShopApp.Domain.Entities;

public class OrderItem : Entity
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public Quantity Quantity { get; private set; }
    public Money UnitPrice { get; private set; }
    
    public Money Subtotal => new Money(Quantity.Value * UnitPrice.Amount, UnitPrice.Currency);

    internal OrderItem(Guid id, Guid orderId, Guid productId, Quantity quantity, Money unitPrice) : base(id)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    
    private OrderItem() : base() { }
}