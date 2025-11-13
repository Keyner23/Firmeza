using System.Runtime.InteropServices.JavaScript;
using Ferreteria.Application.Interfaces;
using Ferreteria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Infrastructure.Persistence;

public class CustomerRepository :ICustomerRepository
{   
    private readonly ApplicationDbContext _context;
    
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync() =>
        await _context.Customers.ToListAsync();

    public async Task<Customer?> GetByIdAsync(Guid id) =>
        await _context.Customers.FindAsync(id);

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        int rows   = await _context.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}