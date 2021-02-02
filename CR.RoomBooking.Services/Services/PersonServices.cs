using CR.RoomBooking.Data;
using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Data.Interfaces;
using CR.RoomBooking.Services.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Services.Services
{
   public class PersonServices: IPersonService
    {

        private IPersonRepository _repo;
        RoomBookingsContext BookingsContext;
        //public PersonServices(RoomBookingsContext bookingsContext)
        //{
        //    BookingsContext = bookingsContext;
        //}
        public PersonServices(IPersonRepository _repo)
        {
            this._repo = _repo;
        }


        public async Task<IEnumerable<Person>> ListAsync()
        {
            
            return await _repo.ListAsync();
        }
        public async Task<Person> FindIdAsync(int id)
        {
            if(id >= 0)
            {
                return await _repo.FindIdAsync(id);

            }
            return await _repo.FindIdAsync(id);
        }

        
        public async Task<Result> DeleteAsync(int id)
        {
            try
            {
                 await _repo.DeleteAsync(id);
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
        }
       

        public async Task<Result> SaveAsync(Person person)
        {
            try
            {
                 await _repo.AddAsync(person);
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
        }

        public async Task<Result> UpdateAsync(Person person)
        {
            try
            {
                await _repo.UpdateAsync(person);
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
        }


    }
}
