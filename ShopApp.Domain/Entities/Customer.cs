using ShopApp.Domain.ValueObjects;


namespace ShopApp.Domain.Entities;

public class Customer : Entity
{
    public Name FullName { get; private set; }
    public Email Email { get; private set; }
    public string? Phone { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Customer(Guid id, Name fullName, Email email, string phone,DateTime createdAt) : base(id)
    {
        FullName = fullName;
        Email = email;
        Phone = phone;
        CreatedAt = createdAt;
    }
    private Customer() : base() {}
    
    public void ChangeEmail(Email newEmail)
    {
        Email = newEmail;
    }

    public void ChangeName(Name newName)
    {
        FullName = newName;
    }
    public void ChangePhone(string newPhone)
    {
        Phone = newPhone;
    }
}