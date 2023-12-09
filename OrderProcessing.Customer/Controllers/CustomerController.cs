using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Customer.Entities;
using OrderProcessing.Customer.Repositories;

namespace OrderProcessing.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customers>>> GetAll()
        {
            //Thread.Sleep(5000);
            return await _customerRepository.GetAllCustomers();
        }

        
    }
}
