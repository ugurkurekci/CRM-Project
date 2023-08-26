using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{

    private readonly ProjectDbContext _context;

    public CustomerRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Customer customer)
    {

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer.Id;

    }

    public async Task<int> Update(Customer customer)
    {

        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer.Id;

    }

    public async Task<int> Delete(int id)
    {

        //  _context.Customers.Remove(new Customer { Id = id });

        _context.Customers.Update(new Customer { Id = id, IsDeleted = true });
        return await _context.SaveChangesAsync();

    }

    public async Task<List<Customer>> GetAll()
    {

        return await _context.Customers.Where(x => x.IsDeleted == false).ToListAsync();

    }

    public async Task<Customer> GetById(int id)
    {

        var result = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        if (result == null)
        {
            throw new Exception("Customer not found");
        }
        return result;

    }

}