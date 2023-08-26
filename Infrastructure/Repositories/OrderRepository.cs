using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{

    private readonly ProjectDbContext _context;

    public OrderRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Order order)
    {

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order.Id;

    }

    public async Task<int> Update(Order order)
    {

        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order.Id;

    }

    public Task<int> Delete(int id)
    {

        //_context.Products.Remove(new Order { Id = id });
        _context.Orders.Update(new Order { Id = id, IsActive = false });
        return _context.SaveChangesAsync();

    }

    public async Task<Order> GetById(int id)
    {

        Order? result = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        if (result == null)
        {
            throw new Exception("Order not found");
        }

        return result;

    }

    public async Task<List<Order>> GetAll()
    {
        return await _context.Orders.Where(x => x.IsActive == true).ToListAsync();
    }

}