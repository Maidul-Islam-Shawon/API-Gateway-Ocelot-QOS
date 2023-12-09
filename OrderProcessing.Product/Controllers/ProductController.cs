using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Product.Entities;
using OrderProcessing.Product.Repositories;

namespace OrderProcessing.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAll()
        {
            return await _productRepository.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetById(Guid id)
        {
            return await _productRepository.GetProductById(id);
        }
    }
}
