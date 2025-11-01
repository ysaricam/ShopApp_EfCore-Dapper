using System.Text.RegularExpressions;


namespace ShopApp.Domain.ValueObjects;
public record Email
{
    public string Value { get;}

    public Email(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("E-posta adresi boş olamaz.", nameof(value));
        
        if(!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Geçersiz e-posta formatı.");
        
        Value = value.Trim().ToLower();
    }
    public static implicit operator string(Email email) => email.Value;
    public static explicit operator Email(string value) => new Email(value);
}