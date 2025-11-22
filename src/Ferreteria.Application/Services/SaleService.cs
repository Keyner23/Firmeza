using Ferreteria.Application.Dtos.Sale;
using Ferreteria.Application.Interfaces;
using Ferreteria.Domain.Entities;

namespace Ferreteria.Application.Services;

public class SaleService
{
    private readonly ISaleRepository _saleRepo;
    private readonly IProductRepository _productRepo;
    private readonly ICustomerRepository _customerRepo;

    public SaleService(
        ISaleRepository saleRepo,
        IProductRepository productRepo,
        ICustomerRepository customerRepo)
    {
        _saleRepo = saleRepo;
        _productRepo = productRepo;
        _customerRepo = customerRepo;
    }

    public async Task<SaleResponseDto> CreateSaleAsync(CreateSaleDto dto)
    {
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            SaleDate = DateTime.UtcNow,
            CustomerId = dto.CustomerId,
            Details = new List<SaleDetail>()
        };

        decimal subtotal = 0;

        foreach (var d in dto.Details)
        {
            var product = await _productRepo.GetByIdAsync(d.ProductId);
            if (product == null)
                throw new Exception($"Producto {d.ProductId} no existe");

            var detail = new SaleDetail
            {
                Id = Guid.NewGuid(),
                SaleId = sale.Id,
                ProductId = d.ProductId,
                Quantity = d.Quantity,
                UnitPrice = product.price,  
                Total = (decimal)(product.price * d.Quantity)
            };

            subtotal += detail.Total;
            sale.Details.Add(detail);
        }

        sale.Subtotal = subtotal;
        sale.IVA = subtotal * 0.19m;
        sale.Total = sale.Subtotal + sale.IVA;

        await _saleRepo.AddSaleAsync(sale);

        sale = await _saleRepo.GetSaleByIdAsync(sale.Id);

        return new SaleResponseDto
        {
            Id = sale.Id,
            SaleDate = sale.SaleDate,
            Subtotal = sale.Subtotal,
            IVA = sale.IVA,
            Total = sale.Total,

            Customer = new CustomerSimpleDto
            {
                Name = sale.Customer?.Name,
                Document = sale.Customer?.Document ?? 0
            },

            Details = sale.Details.Select(d => new SaleDetailResponseDto
            {
                ProductId = d.ProductId,
                ProductName = d.Product?.name,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice ?? 0m,
                Subtotal = d.Total
            }).ToList()
        };
    }




    public Task<Sale?> GetSaleAsync(Guid id) =>
        _saleRepo.GetSaleByIdAsync(id);

    public Task<IEnumerable<Sale>> GetAllSalesAsync() =>
        _saleRepo.GetAllSalesAsync();
}