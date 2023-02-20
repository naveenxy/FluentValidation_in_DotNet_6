using FluentValidation;
using FluentValidation.Results;
using FluentValidation_in_DotNet_6.ApplicationDbContext;
using FluentValidation_in_DotNet_6.Models;
using FluentValidation_in_DotNet_6.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FluentValidation_in_DotNet_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IValidator<Customer> _validator;
        private readonly Database _context;
        public CustomerController (IValidator<Customer> validator,Database context) 
        {
            _validator = validator;
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            //var validator = new CustomerValidation();
            //ValidationResult result = validator.Validate(customer);
            ValidationResult result = await _validator.ValidateAsync(customer);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await  _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);    
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
