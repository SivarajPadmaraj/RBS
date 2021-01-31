using CR.RoomBooking.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CR.RoomBooking.Data.Interfaces
{
    public interface IPersonRepository
    {
        ActionResult<IEnumerable<Person>> Get();

        void Post(Person _person);

        void Update(Person _person);

        void Delete(int? id);
        ActionResult<Person> GetPerson(int? id);
    }
}
