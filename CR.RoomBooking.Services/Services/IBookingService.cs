using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Services.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> ListAsync(int id);
        Task<Result> DeleteAsync(int id);
        Task<Result> SaveAsync(Booking booking);
    }
}
