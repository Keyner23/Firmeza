namespace Ferreteria.Domain.Entities;

public class Sale
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }  

    public decimal Subtotal { get; set; }
    public decimal IVA { get; set; }
    public decimal Total { get; set; }

    public ICollection<SaleDetail> Details { get; set; } = new List<SaleDetail>();
}