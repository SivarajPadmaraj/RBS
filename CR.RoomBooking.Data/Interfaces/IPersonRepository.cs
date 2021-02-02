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
        Task<IEnumerable<Person>> ListAsync();

        Task<Person> FindIdAsync(int id);
        Task AddAsync(Person person);

        Task DeleteAsync(int id);
        Task UpdateAsync(Person person);

        
    }
}
