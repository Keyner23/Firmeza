namespace Ferreteria.Application.Dtos.Sale;

public class CreateSaleDetailDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}