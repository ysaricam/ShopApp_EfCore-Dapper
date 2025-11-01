using ShopApp.Domain.ValueObjects;

namespace ShopApp.Domain.Entities;

public class Category : Entity
{
    public Name Name { get; private set; }
    public string? Description { get; private set; }
    
    public Category(Guid id, Name name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    public Category() : base() {}

    public void UpdateDetails(Name newName, string? newDescription)
    {
        Name = newName;
        Description = newDescription;
    }
    
}