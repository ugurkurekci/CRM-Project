using Domain.Entities;
using Domain.Extensions;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.TechnicalServices.Caching;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly ProjectDbContext _context;
    private readonly ICacheManager _cacheManager;

    public EmployeeRepository(ProjectDbContext context, ICacheManager cacheManager)
    {
        _context = context;
        _cacheManager = cacheManager;
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

    public async Task<List<Employee>> GetAllAsync()
    {

        //if (_cacheManager.Contains("Employees"))
        //{
        //    var listResult = _cacheManager.Get<List<Employee>>("Employees");
        //    Console.WriteLine("Cache: " + listResult.ToJson());
        //    return listResult;
        //}

        //List<Employee> result = await _context.Employees.ToListAsync();
        //Console.WriteLine("Not cache: " + result.ToJson());
        //_cacheManager.Add("Employees", result);
        //return result;
        return await _context.Employees.ToListAsync();

    }

}