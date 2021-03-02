namespace WebApplication.Customer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApplication.CustomerEntity;

    /// <summary>
    /// Customer data access interface.
    /// </summary>
    public interface ICustomerDataAccess
    {
        /// <summary>
        /// Gets or sets an object for CustomerEntity class.
        /// </summary>
        CustomerEntity CustomerEntity { get; set; }

        /// <summary>
        /// Get customer id.
        /// </summary>
        /// <param name="customerEmail">Customer Email.</param>
        /// <returns>Customer id.</returns>
        int GetCustomerIdBasedOnEmail(string customerEmail);
    }

    /// <summary>
    /// Customer data access class.
    /// </summary>
    public class CustomerDataAccess : ICustomerDataAccess
    {
        /// <summary>
        /// Create an object for ICustomerDataAccess class.
        /// </summary>
        private readonly ICustomerDataAccess iCustomerDataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDataAccess" /> class.
        /// </summary>
        public CustomerDataAccess()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDataAccess" /> class.
        /// </summary>
        /// <param name="customerDataAccess">Customer data access interface object.</param>
        public CustomerDataAccess(ICustomerDataAccess customerDataAccess = null)
        {
            this.iCustomerDataAccess = customerDataAccess;

            // Assign mocked entity data for linq mocking in case of interface object is not null
            if (customerDataAccess != null)
            {
                this.CustomerEntity = this.iCustomerDataAccess.CustomerEntity ?? new CustomerEntity();
            }
        }

        /// <summary>
        /// Gets or sets an object for CustomerEntity class.
        /// </summary>
        public CustomerEntity CustomerEntity { get; set; }

        /// <summary>
        /// Get customer id.
        /// </summary>
        /// <param name="customerEmail">Customer Email.</param>
        /// <returns>Customer id.</returns>
        public int GetCustomerIdBasedOnEmail(string customerEmail)
        {
            int customerId = 0;

            if (!string.IsNullOrEmpty(customerEmail))
            {
                try
                {
                    using (CustomerEntity context = this.CustomerEntity ?? new CustomerEntity())
                    {
                        customerId = (from user in context.CustomerData
                                      where user.email == customerEmail
                                      select user.Id).FirstOrDefault();
                    }

                    this.CustomerEntity = null;
                }
                catch (Exception ex)
                {
                    
                }
            }

            return customerId;
        }
    }
}
