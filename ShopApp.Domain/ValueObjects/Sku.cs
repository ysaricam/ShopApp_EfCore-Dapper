using System.Text.RegularExpressions;
using ShopApp.Domain.Abstractions.Guards;

namespace ShopApp.Domain.ValueObjects;

public record Sku
{
    private static readonly Regex _formatRegex = new Regex("^[A-Z0-9-]+$");
    
    public string Value { get; }
    
    public Sku(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, "SKU (Ürün Kodu) boş olamaz.");


        var normalizedValue = value.Trim()
            .ToUpper()
            .Replace("_", "-");

        Guard.Against.InvalidFormat(normalizedValue,_formatRegex, "SKU (Ürün Kodu) geçersiz karakterler içeriyor. Sadece harf, rakam, alt çizgi (_) ve tire (-) içerebilir.");

        Value = normalizedValue;
    }
    
    public static implicit operator string(Sku sku) => sku.Value;

    public static explicit operator Sku(string value) => new Sku(value);
}