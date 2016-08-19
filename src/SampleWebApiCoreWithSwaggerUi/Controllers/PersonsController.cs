using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiCoreWithSwaggerUi.Models;

namespace SampleWebApiCoreWithSwaggerUi.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private static readonly HashSet<Person> Persons = new HashSet<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "Rico",
                LastName = "Suter"
            },
        };

        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            lock (Persons)
                return Persons;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            lock (Persons)
                return Persons.FirstOrDefault(p => p.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Person value)
        {
            lock (Persons)
            {
                Delete(value.Id);
                Persons.Add(value);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person value)
        {
            value.Id = id;
            Post(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            lock (Persons)
            {
                var person = Get(id);
                if (person != null)
                    Persons.Remove(person);
            }
        }
    }
}
