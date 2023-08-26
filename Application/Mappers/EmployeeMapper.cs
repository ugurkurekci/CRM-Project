using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class EmployeeMapper : Profile
{
    // CreateEmployeeDto -> Employee
    public EmployeeMapper()
    {
        // IsActive true
        CreateMap<CreateEmployeeDto, Employee>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
    }
}