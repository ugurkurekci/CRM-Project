namespace Domain.Entities;

public class Order
{

    public int Id { get; set; }

    public bool IsActive { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;
}