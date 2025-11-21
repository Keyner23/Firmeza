using Ferreteria.Application.Interfaces;
using Ferreteria.Domain.Entities;

namespace Ferreteria.Application.Services;

public class CustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Customer>> GetCustomersAsync() => _repository.GetAllAsync();
    public Task<Customer?> GetCustomerAsync(Guid id) => _repository.GetByIdAsync(id);

    public async Task AddCustomerAsync(Customer customer)
    {
        
        var existingEmail = await _repository.GetByEmailAsync(customer.Email);
        if (existingEmail != null)
            throw new Exception("El email ya está registrado.");

        
        var existingDocument = await _repository.GetByDocumentAsync(customer.Document);
        if (existingDocument != null)
            throw new Exception("El documento ya está registrado.");
        
        customer.Id = Guid.NewGuid();
        await _repository.AddAsync(customer);
    }

    public Task UpdateCustomerAsync(Customer customer) => _repository.UpdateAsync(customer);
    public Task DeleteCustomerAsync(Guid id) => _repository.DeleteAsync(id);
}