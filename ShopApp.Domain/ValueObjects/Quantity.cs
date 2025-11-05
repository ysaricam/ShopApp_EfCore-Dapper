using ShopApp.Domain.Abstractions.Guards;

namespace ShopApp.Domain.ValueObjects;

public record Quantity
{
    public int Value { get;}
    
    public Quantity(int value)
    {
        Guard.Against.Negative(value, "Adet sıfırdan küçük olamaz.");
        Value = value;
    }

    public Quantity Add(Quantity other)
    {
        return new Quantity(Value + other.Value); 
    }
    
    public Quantity Subtract(Quantity other)
    {
        int newValue = Value - other.Value;
        if(newValue < 0)
            throw new InvalidOperationException("Çıkarma işlemi sonucu adet negatif olamaz.");
        
        return new Quantity(newValue);
    }
}