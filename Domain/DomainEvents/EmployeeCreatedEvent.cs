using Domain.Entities;

namespace Domain.DomainEvents;

public class EmployeeCreatedEvent
{

    public Employee Employee { get; set; }

    public EmployeeCreatedEvent(Employee employee)
    {
        Employee = employee;
    }

}