namespace Ferreteria.Application.Dtos.Sale;

public class CreateSaleDto
{
    public Guid CustomerId { get; set; }

    public List<CreateSaleDetailDto> Details { get; set; } = new();
}