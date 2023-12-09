using OrderProcessing.Product.Entities;

namespace OrderProcessing.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly List<Products> products = new List<Products>();
        public ProductRepository()
        {
            products = new List<Products>()
            {
                new Products()
                {
                    Id = new Guid("4f4d89cd-e8af-4ce7-a64c-758901d97433"),
                    Code = "A0001",
                    Name = "IPhone 8",
                    Quantity_In_Stock = 10,
                    Unit_Price = 80000
                },
                new Products()
                {
                    Id = new Guid("f4556b64-c831-4295-8bcf-e17e61a94fdc"),
                    Code = "A0002",
                    Name = "ASUS VivoBook",
                    Quantity_In_Stock = 20,
                    Unit_Price = 120000
                },
                new Products()
                {
                    Id =  new Guid("8fe6c263-5713-4083-b955-8ea3cd428abf"),
                    Code = "A0003",
                    Name = "Skullcandy Headphone",
                    Quantity_In_Stock = 50,
                    Unit_Price = 15000
                },
                new Products()
                {
                    Id =  new Guid("175c76b9-7760-435d-8ec0-80a039453922"),
                    Code = "A0004",
                    Name = "Mouse",
                    Quantity_In_Stock = 100,
                    Unit_Price = 500
                },
                new Products()
                {
                    Id = Guid.NewGuid(),
                    Code = "A0005",
                    Name = "Keyboard",
                    Quantity_In_Stock = 80,
                    Unit_Price = 1200
                }
            };
        }

        public Task<List<Products>> GetAllProducts()
        {
            return Task.FromResult(products);
        }

        public Task<Products> GetProductById(Guid id)
        {
            var result = products.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(result);
        }
    }
}
