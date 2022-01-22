using CustomerCruncher.Application.Customers.Commands.CreateCustomer;
using CustomerCruncher.Application.Customers.Commands.DeleteCustomer;
using CustomerCruncher.Application.Customers.Commands.EditCustomer;
using CustomerCruncher.Application.Customers.Queries.GetCustomers;
using CustomerCruncher.Application.Customers.Queries.GetCustomersByName;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [HttpPut("AddCustomer")]
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

        /// <summary>
        /// Changes an existing customer in the database
        /// </summary>
        /// <param name="Id">Customer's Id</param>
        /// <param name="firstname">Customer's first name</param>
        /// <param name="lastname">Customer's last name</param>
        /// <param name="dateOfBirth">Customer's date of birth</param>
        /// <returns>The relevant customer information</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("EditCustomer")]
        public async Task<ActionResult<CustomerDto>> EditCustomer(int Id, string firstname, string lastname, DateTime dateOfBirth)
        {
            var customer = await _mediator.Send(new EditCustomerCommand
            {
                Id = Id,
                FirstName = firstname,
                LastName = lastname,
                DateOfBirth = dateOfBirth
            });

            if (customer == null)
                return BadRequest("Id does not match any existing customer");

            return Ok(customer);
        }

        /// <summary>
        /// Delete an existing customer in the database
        /// </summary>
        /// <param name="Id">Customer's Id</param>
        /// <returns>Whether the request was successful</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete ("DeleteCustomer")]
        public async Task<ActionResult> DeleteCustomer(int Id)
        {
            var success = await _mediator.Send(new DeleteCustomerCommand
            {
                Id = Id,
            });

            if (success == false)
                return BadRequest("Id does not match any existing customer");

            return Ok();
        }


        /// <summary>
        /// Returns all current customers in the database
        /// </summary>
        /// <returns>All customers</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("AllCustomers")]
        public async Task<ActionResult<List<CustomerDto>>> AllCustomers()
        {
            var customers = await _mediator.Send(new GetCustomersQuery());
            return Ok(customers);
        }

        /// <summary>
        /// Returns all customers that have a name that matches the given search parameter
        /// </summary>
        /// <param name="searchParam">The search parameter</param>
        /// <returns>All customers matching the search parameter</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("CustomersByName")]
        public async Task<ActionResult<List<CustomerDto>>> CustomersByName(string searchParam)
        {
            List<CustomerDto> customers = await _mediator.Send(new GetCustomersByNameQuery
            {
                searchParam = searchParam
            });

            return Ok(customers);
        }
    }
}
