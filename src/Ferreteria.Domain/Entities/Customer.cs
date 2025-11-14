namespace Ferreteria.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int Document { get; set; } 
    
    public Customer() { }
    
    public Customer(Guid id, string name, string email, string phone, int document)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Document = document;
    }
}
