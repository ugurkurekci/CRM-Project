using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class City
{

    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

}