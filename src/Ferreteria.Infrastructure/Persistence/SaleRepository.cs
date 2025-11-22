using Ferreteria.Application.Interfaces;
using Ferreteria.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Ferreteria.Infrastructure.Persistence;

public class SaleRepository : ISaleRepository
{
    private readonly ApplicationDbContext _context;

    public SaleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Sale> AddSaleAsync(Sale sale)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
        return sale;
    }

    public async Task<Sale?> GetSaleByIdAsync(Guid id)
{
    return await _context.Sales
        .Include(s => s.Customer)
        .Include(s => s.Details)
        .ThenInclude(d => d.Product)
        .FirstOrDefaultAsync(s => s.Id == id);
}

public async Task<IEnumerable<Sale>> GetAllSalesAsync()
{
    return await _context.Sales
        .Include(s => s.Customer)
        .Include(s => s.Details)
        .ThenInclude(d => d.Product)
        .ToListAsync();
}

    // public async Task<Sale?> GetSaleByIdAsync(Guid id)
    // {
    //     return await _context.Sales
    //         .Include(s => s.Customer)
    //         .Include(s => s.Details)
    //         .ThenInclude(d => d.Product)
    //         .FirstOrDefaultAsync(s => s.Id == id);
    // }

    // public async Task<IEnumerable<Sale>> GetAllSalesAsync()
    // {
    //     return await _context.Sales
    //         .Include(s => s.Customer)
    //         .Include(s => s.Details)
    //         .ThenInclude(d => d.Product)
    //         .ToListAsync();
    // }
}