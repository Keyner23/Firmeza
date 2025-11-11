namespace Ferreteria.Domain.Entities;

public class Product
{
    public Guid id { get; set; }
    public string name { get; set; }
    
    public decimal? price { get; set; }

    public Product(Guid id, string name, decimal? price)
    {
        this.id = id;
        this.name = name;
        this.price = price;
    }
}