using System.Text.RegularExpressions;

namespace ShopApp.Domain.ValueObjects;

public record Sku
{
    private static readonly Regex _formatRegex = new Regex("^[A-Z0-9-]+$");
    
    public string Value { get; }
    
    public Sku(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("SKU (Ürün Kodu) boş olamaz.", nameof(value));
        }


        var normalizedValue = value.Trim()
            .ToUpper()
            .Replace("_", "-");

        if (!_formatRegex.IsMatch(normalizedValue))
        {
            throw new FormatException("SKU (Ürün Kodu) geçersiz karakterler içeriyor. Sadece harf, rakam, alt çizgi (_) ve tire (-) içerebilir.");
        }

        Value = normalizedValue;
    }
    
    public static implicit operator string(Sku sku) => sku.Value;

    public static explicit operator Sku(string value) => new Sku(value);
}