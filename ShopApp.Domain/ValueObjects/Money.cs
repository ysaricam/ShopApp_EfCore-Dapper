namespace ShopApp.Domain.ValueObjects;

public record Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    
    public Money(decimal amount, string currency)
    {
        if (amount <= 0)
            throw new ArgumentException("Fiyat 0' dan büyük olmalıdır.");
        
        if(string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Para birimi boş olamaz.", nameof(currency));
        
        Amount = amount;
        Currency = currency.ToUpper();        
    }

    public Money Add(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException("Farklı para birimleri toplanamaz.");
        
        return new Money(Amount + other.Amount, Currency);
    }
    
}