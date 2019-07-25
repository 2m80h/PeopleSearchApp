using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HerosAndVillains.Models;
using HerosAndVillains.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace HerosAndVillains.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _people;
        private readonly IConfiguration _configuration;

        public PeopleController(IPeopleRepository peopleRepository, IConfiguration configuration)
        {

            _people = peopleRepository;
            _configuration = configuration;

        }

        /// <summary>
        /// Gets people
        /// </summary>
        /// <param name="runSlow"/>
        /// <param name="searchVal"/>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<ActionResult<List<Person>>> GetPersons(bool runSlow, string searchVal)
        {
            try
            {
                if(runSlow==true)
                    await Task.Delay(5000);
                //if (searchVal == null || searchVal.Length < 1) { return BadRequest("Invalid Passport"); }
                if (searchVal == null)
                    searchVal = "";

                var results = await _people.GetPersons(searchVal);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}