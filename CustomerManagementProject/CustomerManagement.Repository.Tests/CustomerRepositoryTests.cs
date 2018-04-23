using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Moq;
using NUnit.Framework;
using AutoMapper;
using CustomerManagement.Common.Converters;
using System.Transactions;
using CustomerManagement.Repositories;
using CustomerManagement.Data;

namespace CustomerManagement.Repository.Tests
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        private Mock<ICustomerRepository> _customerRepositoryMock;

        private Data.DAO.Customer dummyCustomer;

        [OneTimeSetUp]
        public void Setup()
        {
            Mapper.Initialize(Bootstrap.InitMappingConfig);
        }

        [SetUp]
        public void TestSetup()
        {
            dummyCustomer = new Data.DAO.Customer
            {
                Id = 1,
                CustomerName = "Test",
                CustomerAddress = "TestAddress",
                Email = "TestEmail",
                Mobile = 12345
            };
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerRepositoryMock.Setup(x => x.GetAllCustomers()).Returns(new List<Data.DAO.Customer> { dummyCustomer });
            _customerRepositoryMock.Setup(x => x.AddCustomer(It.IsAny<Data.DAO.Customer>())).Returns(dummyCustomer);
            _customerRepositoryMock.Setup(x => x.UpdateCustomer(It.IsAny<Data.DAO.Customer>())).Returns(dummyCustomer);
            _customerRepositoryMock.Setup(x => x.GetCustomerById(It.IsAny<int>())).Returns(dummyCustomer);
        }

        [Test]
        public void Can_Get_All_Customers()
        {
            var customers = _customerRepositoryMock.Object.GetAllCustomers();
            Assert.NotNull(customers);
            Assert.Greater(customers.Count, 0);
            Assert.AreEqual(customers[0], dummyCustomer);
            _customerRepositoryMock.Verify(x => x.GetAllCustomers(), Times.Exactly(1));
        }

        [Test]
        public void Can_Add_Customer()
        {
            var addedCustomer = _customerRepositoryMock.Object.AddCustomer(dummyCustomer);
            Assert.NotNull(addedCustomer);
            Assert.Greater(addedCustomer.Id, 0);
            Assert.AreEqual(addedCustomer, dummyCustomer);
        }
    }
}
