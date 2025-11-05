using ShopApp.Domain.Abstractions.Guards;

namespace ShopApp.Domain.ValueObjects;

public record Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    
    public Money(decimal amount, string currency)
    {
        Guard.Against.Negative(amount, "Para miktarı negatif olamaz.");
        Guard.Against.NullOrWhiteSpace(currency, "Para birimi boş olamaz.");
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