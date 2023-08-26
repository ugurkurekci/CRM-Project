using Core.Enums;

namespace Application.DTOs;

public class CreateEmployeeDto
{

    public int AddressId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string IdentityNumber { get; set; }

    public decimal SalaryAmount { get; set; }

    public DateTime EmploymentStartDate { get; set; }

    public DateTime EmploymentEndDate { get; set; }

    public DateTime BirthDate { get; set; }

    public SalaryCurrency SalaryCurrency { get; set; }

    public Gender Gender { get; set; }
}