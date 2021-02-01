using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Services.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> ListAsync();
        Task<Person> FindIdAsync(int id);

        Task<Result> SaveAsync(Person person);
        Task<Result> UpdateAsync(Person person);
        Task<Result> DeleteAsync(int id);
    }
}
