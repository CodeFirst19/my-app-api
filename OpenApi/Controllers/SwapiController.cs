using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsApiCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenApi.Controllers
{
    /// <summary>
    /// Controller for Star Wars API
    /// This controller gets Star Wars data that is provided by the package called SWapiCSharp
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {

        /// <summary>
        /// Gets all the star wars people
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("people")]
        public IEnumerable<Person> GetPeople()
        {
            try
            {
                IRepository<Person> people = new Repository<Person>();
                return people.GetEntities().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Searches for people/person that matches the given search value
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("people/search")]
        public IEnumerable<Person> SearchPeople(string query)
        {
            try
            {
                IRepository<Person> person = new Repository<Person>();

                List<Person> results = person.GetEntities().Where((p) => p.Name.Contains(query)).ToList();

                return results;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
