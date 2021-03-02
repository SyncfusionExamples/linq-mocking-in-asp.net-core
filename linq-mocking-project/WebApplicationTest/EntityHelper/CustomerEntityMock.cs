using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.CustomerEntity;

namespace WebApplicationTest.EntityHelper
{
    /// <summary>
    /// Customer Entity Mock
    /// </summary>
    /// <typeparam name="T">Fake entity context</typeparam>
    public class MockCustomerContext<T>
    {
        /// <summary>
        /// Get Customer context mock object
        /// </summary>
        /// <returns>Context object</returns>
        public CustomerEntity GetCustomerContext()
        {
            var options = new DbContextOptionsBuilder<CustomerEntity>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            var context = new CustomerEntity(options);

            // CustomerData => table name
            context.CustomerData.Add(new CustomerData { Id = 111, email = "test@gmail.com" });

            context.SaveChanges();
            return context;
        }
    }
}
