using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using WebApplication.Customer;
using WebApplication.CustomerEntity;
using WebApplicationTest.EntityHelper;

namespace WebApplicationTest.Customer
{
    class CustomerDataAccessTest
    {
        /// <summary>
        ///  Gets or sets a value of the ICustomerDataAccess
        /// </summary>
        public ICustomerDataAccess ICustomerDataAccess { get; set; }

        /// <summary>
        /// Customer Data Access
        /// </summary>
        public CustomerDataAccess CustomerDataAccess { get; set; }

        [SetUp]
        public void TestMethodSetup()
        {
            this.ICustomerDataAccess = Substitute.For<ICustomerDataAccess>();
            this.ICustomerDataAccess.CustomerEntity = new MockCustomerContext<CustomerEntity>().GetCustomerContext();
            this.CustomerDataAccess = new CustomerDataAccess(this.ICustomerDataAccess);
        }

        /// <summary>
        /// Valid Customer.
        /// </summary>
        [Test]
        public void GetCustomerIdBasedOnEmail_ValidCustomerEmail_ReturnCustomerId()
        {
            ////Act
            int customerId = this.CustomerDataAccess.GetCustomerIdBasedOnEmail("test@gmail.com");

            ////Assert
            Assert.AreEqual(111, customerId);
        }
    }
}
