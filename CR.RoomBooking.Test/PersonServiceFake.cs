using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services;
using CR.RoomBooking.Services.Enum;
using CR.RoomBooking.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Test
{
    class PersonServiceFake : IPersonService
    {
        private readonly List<Person> _persons;
        public PersonServiceFake()
        {
            _persons = new List<Person>()
            {
                new Person() { Id =  1,
                    FirstName = "Orange ",LastName="Juice",Email="OrangeJuice@gmail.com",Phone ="123"},
              new Person() { Id = 2,
                    FirstName = "Orange1 ",LastName="Juice1",Email="OrangeJuice1@gmail.com",Phone ="123"},
              new Person() { Id = 3,
                    FirstName = "Orange3 ",LastName="Juice3",Email="OrangeJuice3@gmail.com",Phone ="123" }
            };
            
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
           
            return _persons;
        }
        public Task<Person> FindIdAsync(int id)
        {
            throw new NotImplementedException();
            //Person person = _persons.Where(a => a.Id == id).FirstOrDefault();
            //return person;
        }
        public async Task<Result> DeleteAsync(int id)
        {
            Person person = _persons.Where(a => a.Id == id).FirstOrDefault();
            _persons.Remove(person);
            return Result.Success;
        }
        

        public async Task<Result> SaveAsync(Person person)
        {
            person.Id = _persons.Select(p => person.Id).Max() + 1;
            _persons.Add(person);
            return Result.Success;
        }

        public async Task<Result> UpdateAsync(Person person)
        {
            Person exsistingPerson = _persons.Where(a => a.Id == person.Id).FirstOrDefault();
            if( exsistingPerson != null)
            {
                exsistingPerson.Id = person.Id;
                exsistingPerson.FirstName = person.FirstName;
                exsistingPerson.LastName = person.LastName;
                exsistingPerson.Email = person.Email;
                exsistingPerson.Phone = person.Phone;
                _persons.Add(exsistingPerson);
                return Result.Success;
            }

            return Result.Failure;
            
        }

        
    }
}
