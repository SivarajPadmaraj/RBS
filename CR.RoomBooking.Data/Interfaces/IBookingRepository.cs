using CR.RoomBooking.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Data.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> ListAsync();
        Task<Booking> GetFromIDAsync(int id);

        Task AddAsync(Booking booking);

        Task<bool> CheckClashAsync(Booking booking);

        Task<bool> CheckCapacityAsync(Booking booking);
    }
}
