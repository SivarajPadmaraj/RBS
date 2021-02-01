using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private RoomBookingsContext _Context;

        public PersonRepository(RoomBookingsContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _Context.People.ToListAsync();
        }

        public async Task<Person> FindIdAsync(int id)
        {

            return await _Context.People.FirstOrDefaultAsync(s => s.Id == id);

        }

        public async Task DeleteAsync(int id)
        {

          Person person = _Context.People.FirstOrDefault(s => s.Id == id);
            if (person != null)
            {
                _Context.People.Remove(person);
             _Context.SaveChanges();
            }
            




        }

        public async Task AddAsync(Person person)
        {
            await _Context.People.AddAsync(person);
            await _Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            Person existingPerson = await _Context.People.FirstOrDefaultAsync(s => s.Id == person.Id);

            if(existingPerson != null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Email = person.Email;
                existingPerson.Phone = person.Phone;

                _Context.Attach(existingPerson).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
               await _Context.SaveChangesAsync();
            }

        }


    }
}
