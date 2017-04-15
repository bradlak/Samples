using CustomersCrud.Data.Entities;
using CustomersCrud.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CustomersCrud.Interfaces
{
    public interface ICustomersRepository
    {
        IEnumerable<CustomerDto> GetCustomers(Expression<Func<Customer, bool>> predicate = null);

        CustomerDto GetCustomerById(int id);

        CustomerDto UpdateCustomer(CustomerDto dto);

        CustomerDto CreateCustomer(CustomerDto dto);

        bool DeleteCustomer(int id);
    }
}
