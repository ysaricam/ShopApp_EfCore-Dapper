using ShopApp.Domain.Enums;
using ShopApp.Domain.ValueObjects;
using ShopApp.Domain.Events;


namespace ShopApp.Domain.Entities;

public class Product : Entity
{   
    public Name Name { get; private set; }
    public Sku Sku { get; private set; }
    public Money Price { get; private set; }
    public bool IsActive { get; private set; }
    public Quantity StockQuantity { get; private set; }
    
    private readonly List<InventoryMovement> _movements = new();
    
    public IReadOnlyCollection<InventoryMovement> Movements => _movements.AsReadOnly();

    public Product(Guid id, Name name, Sku sku, Money price, Quantity initialStock) : base(id)
    {
        Name = name;
        Sku = sku;
        Price = price;
        IsActive = false;
        
        StockQuantity = initialStock;
        
        if (StockQuantity.Value > 0)
        {
            _movements.Add(new InventoryMovement(
                Guid.NewGuid(), 
                this.Id, 
                InventoryMovementType.Increase, 
                initialStock, // 'initialStock' (örn: 5)
                "İlk stok girişi"));
        }
    }
    
    public Product() : base(){}
    
    public void ChangePrice(Money newPrice)
    {
        var oldPrice = Price;
        Price = newPrice;
        //TODO
        //AddDomainEvent(new ProductPriceChanged(this.Id, oldPrice, newPrice, DateTime.UtcNow));
    }
    
    public void Activate()
    {
        if(StockQuantity.Value <= 0 ||Price.Amount <= 0)
            throw new InvalidOperationException("Stoğu veya fiyatı olmayan ürün aktif edilemez.");
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
    public void AdjustStock(InventoryMovementType type, Quantity quantity, string? note = null)
    {
        if (type == InventoryMovementType.Decrease)
        {

            StockQuantity = StockQuantity.Subtract(quantity);
            
            AddDomainEvent(new InventoryDecreased(this.Id, quantity, DateTime.UtcNow));
        }
        else if (type == InventoryMovementType.Increase)
        {
            StockQuantity = StockQuantity.Add(quantity);
            
            AddDomainEvent(new InventoryIncreased(this.Id, quantity, DateTime.UtcNow));
        }

        var movement = new InventoryMovement(
            Guid.NewGuid(), 
            this.Id, 
            type, 
            quantity, 
            note);
            
        _movements.Add(movement);
    }
}