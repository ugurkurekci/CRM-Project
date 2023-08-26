using Application.DTOs;

namespace Application.Interface;

public interface IEmployeeService
{

    Task<int> Create(CreateEmployeeDto createEmployeeDto);

}