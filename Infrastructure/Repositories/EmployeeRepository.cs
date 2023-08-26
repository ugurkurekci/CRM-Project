using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly ProjectDbContext _context;

    public EmployeeRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Employee employee)
    {

        employee.IsActive = true;
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee.Id;

    }

    public async Task<int> Update(Employee employee)
    {

        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee.Id;

    }

    public Task<int> Delete(int id)
    {

        //_context.Products.Remove(new Product { Id = id });
        _context.Employees.Update(new Employee { Id = id, IsActive = false });
        return _context.SaveChangesAsync();

    }

    public async Task<Employee> GetById(int id)
    {

        Employee? result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (result == null)
        {
            throw new Exception("Employee not found");
        }

        return result;

    }

    public async Task<List<Employee>> GetAll()
    {
        return await _context.Employees.Where(x => x.IsActive == true).ToListAsync();
    }

}