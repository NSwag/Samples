using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleWebApiWithSwaggerUi.Models;

namespace SampleWebApiWithSwaggerUi.Controllers
{
    [RoutePrefix("api/Persons")]
    public class PersonsController : ApiController
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
        [HttpGet, Route("")]
        public IEnumerable<Person> Get()
        {
            lock (Persons)
                return Persons;
        }

        // GET api/values/5
        [HttpGet, Route("{id}")]
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
        [HttpPut, Route("{id}")]
        public void Put(int id, [FromBody]Person value)
        {
            value.Id = id;
            Post(value);
        }

        // DELETE api/values/5
        [HttpDelete, Route("{id}")]
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
