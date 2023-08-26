using Application.DTOs;
using Application.Interface;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{

    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<int> Create(CreateEmployeeDto createEmployeeDto)
    {

        Employee? employee = _mapper.Map<Employee>(createEmployeeDto);
        return await _employeeRepository.Create(employee);

    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }

}