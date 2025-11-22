using Ferreteria.Domain.Entities;

namespace Ferreteria.Application.Interfaces;

public interface ISaleRepository
{
    Task<Sale> AddSaleAsync(Sale sale);

    Task<Sale?> GetSaleByIdAsync(Guid id);
    Task<IEnumerable<Sale>> GetAllSalesAsync();
}