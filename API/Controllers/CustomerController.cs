using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Adds a new customer to the database
        /// </summary>
        /// <param name="firstname">Customer's first name</param>
        /// <param name="lastname">Customer's last name</param>
        /// <param name="dateOfBirth">Customer's date of birth</param>
        /// <returns>Whether the action was completed - either 201 or 400</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public IActionResult AddCustomer(string firstname, string lastname, DateTime dateOfBirth)
        {
            return new OkObjectResult(true);
        }
    }
}
