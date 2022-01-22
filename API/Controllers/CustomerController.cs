using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpPut]
        public IActionResult AddCustomer(string firstname, string lastname, DateTime dateOfBirth)
        {
            return new OkObjectResult(true);
        }
    }
}
