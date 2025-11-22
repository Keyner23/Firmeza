namespace Ferreteria.Application.Dtos.Sale;

public class SaleResponseDto
{
    public Guid Id { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal Subtotal { get; set; }
    public decimal IVA { get; set; }
    public decimal Total { get; set; }
    public CustomerSimpleDto Customer { get; set; }
    public List<SaleDetailResponseDto> Details { get; set; }
}