using OrderProcessing.Customer.Entities;

namespace OrderProcessing.Customer.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<Customers>> GetAllCustomers();
    }
}
