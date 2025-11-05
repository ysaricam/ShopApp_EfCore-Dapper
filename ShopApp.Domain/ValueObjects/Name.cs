using ShopApp.Domain.Abstractions.Guards;

namespace ShopApp.Domain.ValueObjects;

public record Name
{
    public const int MaxLength = 25;
    public string Value { get;}

    public Name(string value)
    {
       Guard.Against.NullOrWhiteSpace(value, "İsim alanı boş olamaz.");
        
        var trimmed = value.Trim();
        
        Guard.Against.MaxLength(trimmed.Length, MaxLength,$"İsim {MaxLength} karakterden uzun olamaz.");

        
        Value = trimmed;
    }
    public static implicit operator string(Name name) => name.Value;
    public static explicit operator Name(string value) => new Name(value);
}