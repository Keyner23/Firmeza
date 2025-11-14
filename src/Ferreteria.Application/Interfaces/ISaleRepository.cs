using Ferreteria.Domain.Entities;

namespace Ferreteria.Application.Interfaces;

public interface ISaleRepository
{
    
    Task AddAsync(Sale sale);
    Task<IEnumerable<Sale>> GetAllAsync();
}