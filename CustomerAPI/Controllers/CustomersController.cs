using CustomerAPI.Models;
using CustomerAPI.Services.CustomersService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _service;

        public CustomersController(ICustomerRepository service)
        {
            _service = service;
        }
        
        [HttpGet("getAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var AllCustomers = _service.GetAllCustomers();

            return Ok(AllCustomers);
        }

        [HttpGet("getCustomer/{customerId}")]

        public IActionResult GetCustomer(int customerId)
        {

            var Customer = _service.GetCustomer(customerId);
            if (Customer is null)
            {
                return NotFound();
            }

            return Ok(Customer);
        }

        [HttpPost("createCustomer")]
        public IActionResult CreateCustomer(Customer customer)
        {

            if (customer is null)
            {
                return BadRequest();
            }
            else
            {
                _service.AddCustomer(customer);
                return Ok(new
                {
                    StatusCode = 200,

                });
            }
        }

        [HttpPut("updateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _service.UpdateCustomer(customer);
            return NoContent();

        }

        [HttpDelete("deleteCustomer/{customerId}")]
        public ActionResult DeleteInvoice(int customerId)
        {
            var deletingCustomer = _service.GetCustomer(customerId);
            if (deletingCustomer is null)
            {
                return NotFound();
            }

            _service.DeleteCustomer(deletingCustomer);
            return NoContent();
        }


    }
}
