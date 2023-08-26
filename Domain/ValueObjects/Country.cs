using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class Country
{

    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

}