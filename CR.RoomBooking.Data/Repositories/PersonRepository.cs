using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Data.Repositories
{
   public class PersonRepository :  IPersonRepository
    {
        private RoomBookingsContext _Context ;

        public PersonRepository (RoomBookingsContext context)
        {
            _Context = context;
        }

        public ActionResult<IEnumerable<Person>> Get()
        {
            var getPersons = _Context.People.ToList();
            return getPersons;
           
        }

        public ActionResult<Person> GetPerson(int? id)
        {
            var getPersons = _Context.People.FirstOrDefault(s => s.Id == id);
            return getPersons;

        }

        public async void Post(Person _person)
        {
            if (_person == null)
            {
                throw new ArgumentNullException(nameof(_person));
            }

            await _Context.People.AddAsync(_person);
            await _Context.SaveChangesAsync();

        }

        public async void Update(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            Person existingPerson = _Context.People.FirstOrDefault(s => s.Id == person.Id);

            if (existingPerson == null)
            {
                throw new ArgumentNullException(nameof(existingPerson));
            }

            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Email = person.Email;
            existingPerson.Phone = person.Phone;
            existingPerson.DateOfBirth = person.DateOfBirth;
            

            _Context.Attach(existingPerson).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _Context.SaveChangesAsync();

        }

        public async void Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Person person = _Context.People.FirstOrDefault(s => s.Id == id);

            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            _Context.People.Remove(person);
            await _Context.SaveChangesAsync();
        }

    }
}
