using System.Text.RegularExpressions;
using ShopApp.Domain.Abstractions.Guards;


namespace ShopApp.Domain.ValueObjects;
public record Email
{
    public string Value { get;}

    public Email(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, "E-posta adresi boş olamaz.");
        
        Regex regex = new Regex("\"^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$\"");
        Guard.Against.InvalidFormat(value, regex, "Geçerli bir e-posta adresi olmalı.");

        
        Value = value.Trim().ToLower();
    }
    public static implicit operator string(Email email) => email.Value;
    public static explicit operator Email(string value) => new Email(value);
}