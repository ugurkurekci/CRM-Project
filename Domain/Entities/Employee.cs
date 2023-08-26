using Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Employee
{

    [Key]
    public int Id { get; set; }

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

    public bool IsActive { get; set; }

    [ForeignKey("AddressId")]
    public Address Address { get; set; }


}