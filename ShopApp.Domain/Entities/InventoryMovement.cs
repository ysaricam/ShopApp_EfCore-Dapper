using ShopApp.Domain.Enums;
using ShopApp.Domain.ValueObjects;

namespace ShopApp.Domain.Entities;

public class InventoryMovement : Entity
{
    public Guid ProductId { get; private set; }
    public InventoryMovementType MovementType { get; private set; }
    public Quantity Quantity { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string? Note { get; private set; }
    
    internal InventoryMovement(Guid id, Guid productId, InventoryMovementType movementType, Quantity quantity, string? note) : base(id)
    {
        ProductId = productId;
        MovementType = movementType;
        Quantity = quantity;
        Note = note;
        CreatedAt = DateTime.UtcNow;
    }

    private InventoryMovement() : base(){}
}