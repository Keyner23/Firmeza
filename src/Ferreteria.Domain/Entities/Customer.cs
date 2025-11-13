namespace Ferreteria.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    
    public Customer() { }
    
    public Customer(Guid id, string name, string email, string phone, string address)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
    }
}
