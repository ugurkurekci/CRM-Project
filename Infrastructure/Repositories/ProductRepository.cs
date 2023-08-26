using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{

    private readonly ProjectDbContext _context;

    public ProductRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Product product)
    {

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product.Id;

    }

    public async Task<int> Update(Product product)
    {

        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product.Id;

    }

    public Task<int> Delete(int id)
    {

        //_context.Products.Remove(new Product { Id = id });
        _context.Products.Update(new Product { Id = id, IsDeleted = true });
        return _context.SaveChangesAsync();

    }

    public async Task<Product> GetById(int id)
    {

        Product? result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (result == null)
        {
            throw new Exception("Product not found");
        }

        return result;

    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products.Where(x => x.IsDeleted == false).ToListAsync();
    }

}