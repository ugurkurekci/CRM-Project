using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmployeeRepository
{

    Task<int> Create(Employee employee);

    Task<int> Update(Employee employee);

    Task<int> Delete(int id);

    Task<List<Employee>> GetAll();

    Task<Employee> GetById(int id);

}