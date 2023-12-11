using ActionFilterSample.Filters;
using ActionFilterSample.Models;
using ActionFilterSample.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActionFilterSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personRepository.GetPersons());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _personRepository.GetPerson(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        [MilitaryServiceValidationFilter]
        public IActionResult Post([FromBody] Person person)
        {
            return Ok("It is Ok");
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            return Ok("It is Ok");
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
