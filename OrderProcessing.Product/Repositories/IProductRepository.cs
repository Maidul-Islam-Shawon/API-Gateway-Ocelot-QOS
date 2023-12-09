using OrderProcessing.Product.Entities;

namespace OrderProcessing.Product.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Products>> GetAllProducts();
        public Task<Products> GetProductById(Guid id);
    }
}
