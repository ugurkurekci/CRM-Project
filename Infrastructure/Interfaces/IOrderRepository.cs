using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IOrderRepository
{
    Task<int> Create(Order order);

    Task<int> Update(Order order);

    Task<int> Delete(int id);

    Task<Order> GetById(int id);

    Task<List<Order>> GetAll();
}
