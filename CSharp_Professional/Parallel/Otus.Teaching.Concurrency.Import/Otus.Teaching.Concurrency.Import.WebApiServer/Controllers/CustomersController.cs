using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Otus.Teaching.Concurrency.Import.DataAccess;
using Otus.Teaching.Concurrency.Import.Core;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;

namespace Otus.Teaching.Concurrency.Import.WebApiServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        static string  connectionString = "Server=localhost;Database=otusdb;Trusted_Connection=True";
        public ICustomerRepository repo = new SqlRepository(connectionString);


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Customer> Get(int id)
        {
            Customer customer = repo.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            if (repo.GetCustomerById(customer.Id) != null)
            {
                return Conflict();
            }
            else
            {
                repo.AddCustomer(customer, 1);
            }

            return Ok(customer);
        }

    }
}
