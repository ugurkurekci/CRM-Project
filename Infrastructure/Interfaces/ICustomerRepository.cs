﻿using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<int> Create(Customer customer);

    Task<int> Update(Customer customer);

    Task<int> Delete(int id);

    Task<Customer> GetById(int id);

    Task<List<Customer>> GetAll();
}