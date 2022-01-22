using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult AddCustomer(string firstname, string lastname, DateTime dateOfBirth)
        {
            return new OkObjectResult(true);
        }
    }
}
