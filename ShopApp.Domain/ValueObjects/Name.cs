namespace ShopApp.Domain.ValueObjects;

public record Name
{
    public const int MaxLength = 25;
    public string Value { get;}

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("İsim Alanı boş olamaz.", nameof(value));
        
        var trimmed = value.Trim();
        
        if (trimmed.Length > MaxLength)
            throw new ArgumentException($"İsim {MaxLength} karakterden uzun olamaz.", nameof(value));
        
        Value = trimmed;
    }
    public static implicit operator string(Name name) => name.Value;
    public static explicit operator Name(string value) => new Name(value);
}