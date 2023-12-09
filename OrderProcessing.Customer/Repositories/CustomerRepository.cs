using OrderProcessing.Customer.Entities;

namespace OrderProcessing.Customer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customers> customers = new List<Customers>();
        private static int _count = 0;
        public CustomerRepository()
        {
            customers = new List<Customers>()
            {
                new Customers()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Maidul",
                    LastName = "Islam",
                    EmailAddress = "maidul.bd@asa-international.com"
                },
                new Customers()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Emrul",
                    LastName = "Kayes",
                    EmailAddress = "emrul.bd@asa-international.com"
                },
                new Customers()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mohammed",
                    LastName = "Raju",
                    EmailAddress = "raju.bd@asa-international.com"
                },
                new Customers()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Rabbi",
                    LastName = "Hasan",
                    EmailAddress = "rabbi.bd@asa-international.com"
                },

            };
            
        }


        public Task<List<Customers>> GetAllCustomers()
        {
            //return customers.ToList();

            _count++;
            if (_count <= 3)
            {
                Thread.Sleep(5000);
            }
            var result = Task.FromResult(customers);

            return result;
        }
    }
}
