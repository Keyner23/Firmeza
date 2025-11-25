using System.Text.Json.Serialization;

namespace Ferreteria.Domain.Entities;

public class SaleDetail
{
    public Guid Id { get; set; }

    public Guid SaleId { get; set; }
    [JsonIgnore]
    public Sale Sale { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal Total { get; set; }
}