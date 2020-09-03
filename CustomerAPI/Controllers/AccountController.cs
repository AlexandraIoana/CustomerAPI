using System.Threading.Tasks;
using AutoMapper;
using CustomerAPI.Interfaces;
using CustomerAPI.Resources.Classes;
using CustomerAPI.Resources.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAccountAsync([FromBody] SaveAccountResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _accountService.PostAccountAsync(resource.CustomerID, resource.InitialCredit);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Account);
        }
    }
}
