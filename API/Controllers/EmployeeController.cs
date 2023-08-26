using Application.DTOs;
using Application.Interface;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmployeeController : BaseController
{

    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto createEmployeeDto)
    {

        int id = await _employeeService.Create(createEmployeeDto);

        if (id == 0)
        {
            return BadRequest("Employee already exists");
        }

        return Ok(id);

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _employeeService.GetAllAsync();
        if (result is null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

}