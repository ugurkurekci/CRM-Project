﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{

    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public bool ValidatePassword(string password)
    {
        return Password == password;
    }

}