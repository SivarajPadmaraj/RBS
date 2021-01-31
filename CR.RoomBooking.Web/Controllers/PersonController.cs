using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CR.RoomBooking.Services;
using CR.RoomBooking.Services.Models;
using CR.RoomBooking.Data.Interfaces;
using CR.RoomBooking.Data.Domain;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;

namespace CR.RoomBooking.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        //private readonly IPersonService _personService;

        //public PersonController(IPersonService personService)
        //{
        //    _personService = personService;
        //}

        //[HttpGet("{personId}")]
        //public async Task<ActionResult<PersonInfo>> Get(int personId)
        //{
        //    var person = await _personService.GetAsync(personId);
        //    return person;
        //}

        private readonly IPersonRepository _repo;

        public PersonController(IPersonRepository repo)
        {
            _repo = repo;
        }

        // GET: api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetValues()
        {
            try
            {
                var person = _repo.Get();
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound();
            }
            try
            {
                _repo.Post(person);
                return Ok("Person Added");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound("Getting null for student");
            }

            _repo.Update(person);
            return Ok("Person Updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Getting null for person id");
            }
            _repo.Delete(id);
            return Ok("Person Deleted");
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetPerson(int? id)
        {
            try
            {


                if (id == null)
                {
                    return NotFound("Getting null for person id");
                }
               var p =  _repo.GetPerson(id);
                return p;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
