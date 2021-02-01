using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CR.RoomBooking.Services;
using CR.RoomBooking.Services.Models;
using CR.RoomBooking.Data.Interfaces;
using CR.RoomBooking.Data.Domain;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using CR.RoomBooking.Services.Enum;
using CR.RoomBooking.Services.Services;

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

        private readonly IPersonService _repo;

        public PersonController(IPersonService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var persons = await _repo.ListAsync();
            return persons;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Post error"); // TODO: More error information
            }

            Result result = await _repo.SaveAsync(person);

            if (result == Result.Failure)
            {
                return BadRequest("Post error");
            }

            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<Person> GetByIdAsync(int id)
        {
            var persons = await _repo.FindIdAsync(id);
            return persons;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson (int id)
        {
            Result result = await _repo.DeleteAsync(id);

            if(result== Result.Failure)
            {
                return BadRequest("Post Error");
            }

            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Post error"); // TODO: More error information
            }

            Result result = await _repo.UpdateAsync(person);

            if (result == Result.Failure)
            {
                return BadRequest("Post error");
            }

            return Ok();
        }
        // GET: api/[controller]
        //[HttpGet]
        //public async Task<IEnumerable<Person>> GetValues()
        //{

        //        var person = await _repo.Get();
        //        return person;

        //}

        //// POST: api/[controller]
        //[HttpPost]
        //public async Task<IActionResult> PostAsync([FromBody] Person person)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Post error"); // TODO: More error information
        //    }


        //    Result result = await _repo.AddAsync(person);

        //    if (result == Result.Failure)
        //    {
        //        return BadRequest("Post error");
        //    }

        //    return Ok();

        //}


        //[HttpPut]
        //public async Task<ActionResult> Update([FromBody] Person person)
        //{
        //    if (person == null)
        //    {
        //        return NotFound("Getting null for student");
        //    }

        //    _repo.Update(person);
        //    return Ok("Person Updated");
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound("Getting null for person id");
        //    }
        //    _repo.Delete(id);
        //    return Ok("Person Deleted");
        //}

        //[HttpGet("{id:int}")]
        //public ActionResult<Person> GetPerson(int? id)
        //{
        //    try
        //    {

        //        if (id == null)
        //        {
        //            return NotFound("Getting null for person id");
        //        }
        //       var p =  _repo.GetPerson(id);
        //        return Ok(p);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}

    }
}
