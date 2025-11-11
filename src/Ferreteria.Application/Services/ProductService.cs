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

    public async Task<IEnumerable<Product>> GetProductsAsync() =>
        await _repository.GetAllAsync();

    public async Task AddProductAsync(Product product)
    {
        product.id = Guid.NewGuid(); 
        await _repository.AddAsync(product); 
    }

    public async Task<Product?> GetProductAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task UpdateProductAsync(Product product) =>
        await _repository.UpdateAsync(product);

    // public async Task DeleteProductAsync(Guid id) =>
    //     await _repository.DeleteAsync(id);
}   