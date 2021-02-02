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
        
    }
}
