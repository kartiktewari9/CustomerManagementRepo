using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Common.Objects;
using CustomerManagement.Data;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private ICustomerManagementDbContext _context { get; set; }

        public CustomerRepository(ICustomerManagementDbContext context)
        {
            _context = context;
        }

        public List<Data.DAO.Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Data.DAO.Customer GetCustomerById(int customerId)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == customerId);
        }

        public Data.DAO.Customer AddCustomer(Data.DAO.Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Data.DAO.Customer UpdateCustomer(Data.DAO.Customer customer)
        {
            var dbcustomer = _context.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if (customer != null)
            {
                dbcustomer.CustomerName = customer.CustomerName;
                dbcustomer.CustomerAddress = customer.CustomerAddress;
                dbcustomer.Email = customer.Email;
                dbcustomer.Mobile = customer.Mobile;
                _context.SaveChanges();
            }

            return customer;
        }
    }

    public interface ICustomerRepository
    {
        List<Data.DAO.Customer> GetAllCustomers();
        Data.DAO.Customer GetCustomerById(int customerId);
        Data.DAO.Customer AddCustomer(Data.DAO.Customer customer);
        Data.DAO.Customer UpdateCustomer(Data.DAO.Customer customer);
    }
}
