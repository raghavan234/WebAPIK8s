using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIK8s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService; 
        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomerDetails()
        {
            var customerDetails = await _customerService.GetAllCustomerDetails();
            if (customerDetails != null)
            {
                return Ok(customerDetails);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetailsByID(int id)
        {
            var custDetailsByID = await _customerService.GetAllCustomerByID(id);
            if (custDetailsByID != null)
            {
                return Ok(custDetailsByID);
            }
            else 
            { 
                return NoContent(); 
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> AddCustomerDetails(CustomerDetails customerDetails)
        {
            var isCustomerInserted = await _customerService.AddCustomerDetails(customerDetails);
            if (isCustomerInserted)
            {
                return Ok(isCustomerInserted);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerDetails(CustomerDetails customerDetails)
        {
            var isCustomerUpdated = await _customerService.UpdateCustomerDetails(customerDetails);
            if (isCustomerUpdated)
            {
                return Ok(isCustomerUpdated);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetails(int id)
        {
            var isCustomerDeleted = await _customerService.DeleteCustomerDetails(id);
            if (isCustomerDeleted)
                return Ok(isCustomerDeleted);
            return BadRequest();
        }
    }
}
