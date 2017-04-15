using CustomersCrud.Data.Entities;
using CustomersCrud.Interfaces;
using System;
using System.Collections.Generic;
using CustomersCrud.Dto;
using System.Linq.Expressions;
using CustomersCrud.Data;
using AutoMapper;
using System.Linq;

namespace CustomersCrud.Services
{
    public class CustomersRepository : BaseRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(CustomersContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public CustomerDto CreateCustomer(CustomerDto dto)
        {
            return InvokeWithMapping<CustomerDto>(dto, Create);
        }

        public bool DeleteCustomer(int id)
        {
            return Delete(id);
        }

        public CustomerDto GetCustomerById(int id)
        {
            CustomerDto result = null;
            var entity = GetById(id);

            if (entity != null)
            {
                result = mapper.Map<CustomerDto>(entity);
            }

            return result;
        }

        public IEnumerable<CustomerDto> GetCustomers(Expression<Func<Customer, bool>> predicate = null)
        {
            return mapper.Map<IEnumerable<CustomerDto>>(GetAll(predicate).ToList());
        }

        public CustomerDto UpdateCustomer(CustomerDto dto)
        {
            return InvokeWithMapping<CustomerDto>(dto, Update);
        }
    }
}
