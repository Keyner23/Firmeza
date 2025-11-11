using Ferreteria.Application.Interfaces;
using Ferreteria.Domain.Entities;

namespace Ferreteria.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Product>> GetProductsAsync() => _repository.GetAllAsync();
    public Task<Product?> GetProductAsync(int id) => _repository.GetByIdAsync(id);
    public Task AddProductAsync(Product product) => _repository.AddAsync(product);
    public Task UpdateProductAsync(Product product) => _repository.UpdateAsync(product);
    public Task DeleteProductAsync(int id) => _repository.DeleteAsync(id);
}   