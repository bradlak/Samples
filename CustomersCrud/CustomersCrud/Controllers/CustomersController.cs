using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomersCrud.Interfaces;
using CustomersCrud.Dto;

namespace CustomersCrud.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ILogger logger;

        private readonly ICustomersRepository repository;

        public CustomersController(
            ILogger<CustomersController> logger, 
            ICustomersRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(repository.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var result = repository.GetCustomerById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto customer)
        {
            if(customer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCustomer = repository.CreateCustomer(customer);

            var uri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{newCustomer.Id}";
            return Created(uri, newCustomer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDto customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = repository.GetCustomerById(id);

            if (result == null) return NotFound();

            customer.Id = id;
            return Ok(repository.UpdateCustomer(customer));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = repository.DeleteCustomer(id);

            if (!result) return NotFound();

            return NoContent();
        }
    }
}
