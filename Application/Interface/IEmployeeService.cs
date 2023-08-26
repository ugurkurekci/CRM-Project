using Application.DTOs;
using BenchmarkDotNet.Attributes;
using Domain.Entities;

namespace Application.Interface;

public interface IEmployeeService
{

    Task<int> Create(CreateEmployeeDto createEmployeeDto);

    Task<List<Employee>> GetAllAsync();

}