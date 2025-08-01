using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_01.Models;
namespace Project_01.Controllers
{

    [ApiController]
    [Route("")]
    public class CustomerController : Controller
    {
        // Sead some Date instead of dataBase
        private static List<Customer> customers = new List<Customer>
        {
            new Customer {Id=1, Name = "Ali", Age = 25 },
            new Customer {Id=2, Name = "Mohamed", Age = 30 },
            new Customer {Id=3, Name = "Yara", Age = 7 },
            new Customer {Id=4, Name = "Talia", Age = 5 },
            new Customer {Id=5, Name = "Jana", Age = 18 }
        };

        private readonly ILogger<CustomerController> _logger;

       
        // Test MiddleWare
        private readonly IServices services;
        public CustomerController(IServices myService, ILogger<CustomerController> logger)
        {
            services = myService;
            _logger = logger;

        }


        // Get all data
        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            _logger.LogInformation("GetAll endpoint was called.");
            services.LogCreation("From Controller");
            return Ok(customers);
        }
        // Get Specific Customer by id
        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Customer> GetById(int id)
        {

        services.LogCreation("From Controller");
        var customer = customers.FirstOrDefault(e => e.Id == id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // Create Customer
        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            services.LogCreation("From Controller");
            customer.Id = customers.Count + 1;
            customers.Add(customer);
            return Ok(customer);
        }

        // Update whole data
        [HttpPut("{id:int}")]
        public ActionResult<Customer> UpdateCustomer(Customer customer, int id)
        {
            var oldCustomer = customers.FirstOrDefault(e => e.Id == id);
            if (oldCustomer == null) return NotFound();

            oldCustomer.Name = customer.Name;
            oldCustomer.Age = customer.Age;

            return Ok(oldCustomer);
        }

        // Update partial data
        [HttpPatch("{id:int}")]
        public ActionResult UpdatePartial([FromRoute]int id, [FromBody] Customer newCustomer)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            if (!string.IsNullOrWhiteSpace(newCustomer.Name))
                customer.Name = newCustomer.Name;

            if (newCustomer.Age != 0)
                customer.Age = newCustomer.Age;

            return Ok(customer);
        }

        // Delete By Id
        [HttpDelete("{id:int}")]
        public ActionResult DeleteById([FromRoute]int id)
        {
            var customer = customers.FirstOrDefault(p => p.Id == id);
            if (customer == null) return NotFound("This Customer is not exist");

            customers.Remove(customer);
            return Ok(customer);
        }
    }
}
