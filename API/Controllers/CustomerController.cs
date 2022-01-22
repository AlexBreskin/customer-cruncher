using CustomerCruncher.Application.Customers.Commands.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adds a new customer to the database
        /// </summary>
        /// <param name="firstname">Customer's first name</param>
        /// <param name="lastname">Customer's last name</param>
        /// <param name="dateOfBirth">Customer's date of birth</param>
        /// <returns>The assigned Id of the new customer</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPut]
        public async Task<ActionResult<int>> AddCustomer(string firstname, string lastname, DateTime dateOfBirth)
        {
            var customerId = await _mediator.Send(new CreateCustomerCommand
            {
                FirstName = firstname,
                LastName = lastname,
                DateOfBirth = dateOfBirth
            });

            return Created(string.Empty, customerId);
        }
    }
}
