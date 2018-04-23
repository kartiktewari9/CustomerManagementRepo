using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Repositories;
using CustomerManagement.Common.Objects;
using POCO = CustomerManagement.Common.Objects.POCO;
using AutoMapper;

namespace CustomerManagementServices
{
    public class CustomerService: ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public POCO.CustomerPoco GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            var customerPoco = Mapper.Map<POCO.CustomerPoco>(customer);
            return customerPoco;
        }

        public POCO.CustomerPoco AddCustomer(POCO.CustomerPoco customerPoco)
        {
            var dbCustomer = Mapper.Map<CustomerManagement.Data.DAO.Customer>(customerPoco);
            dbCustomer = _customerRepository.AddCustomer(dbCustomer);
            customerPoco = Mapper.Map<POCO.CustomerPoco>(dbCustomer);
            return customerPoco;
        }

        public POCO.CustomerPoco UpdateCustomer(POCO.CustomerPoco customerPoco)
        {
            var dbCustomer = Mapper.Map<CustomerManagement.Data.DAO.Customer>(customerPoco);
            dbCustomer = _customerRepository.UpdateCustomer(dbCustomer);
            customerPoco = Mapper.Map<POCO.CustomerPoco>(dbCustomer);
            return customerPoco;
        }

        public List<POCO.CustomerPoco> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            var result = Mapper.Map<List<POCO.CustomerPoco>>(customers);
            return result;
        }
    }

    public interface ICustomerService
    {
        POCO.CustomerPoco GetCustomerById(int customerId);
        POCO.CustomerPoco AddCustomer(POCO.CustomerPoco customerPoco);
        POCO.CustomerPoco UpdateCustomer(POCO.CustomerPoco customerPoco);
        List<POCO.CustomerPoco> GetAllCustomers();
    }
}
