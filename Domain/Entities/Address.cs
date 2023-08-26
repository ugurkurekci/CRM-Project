using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Address
{

    [Key]
    public int Id { get; set; }

    public int CityId { get; set; }

    public int CountryId { get; set; }

    public string Street { get; set; }

    public string PostalCode { get; set; }

    public City City { get; set; }

    public Country Country { get; set; }

}