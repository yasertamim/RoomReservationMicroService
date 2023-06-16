using CustomerApi.Interfaces;
using CustomerApi.Models;
using CustomerApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customerService;

        public CustomersController(ICustomer customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async  Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerService.GetAllCustomers();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await _customerService.GetCustomerById(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            _customerService.AddCustomer(customer);
        }

    }
}
