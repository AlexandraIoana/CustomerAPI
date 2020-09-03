using System.Threading.Tasks;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerViewModel>> GetCustomerAsync(int id)
        {
            var customerViewModel = await _customerService.GetCustomerAsync(id);

            if (customerViewModel == null)
            {
                return NotFound();
            }
            return Ok(customerViewModel);
        }
    }
}
