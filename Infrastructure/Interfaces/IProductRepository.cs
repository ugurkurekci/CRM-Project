using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IProductRepository
{

    Task<int> Create(Product product);

    Task<int> Update(Product product);

    Task<int> Delete(int id);

    Task<Product> GetById(int id);

    Task<List<Product>> GetAll();

}