using CR.RoomBooking.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Data.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ListAsync();

        Task<IEnumerable<Room>> ListAsync(DateTime startDate, DateTime endDate, int partySize);

        Task AddAsync(Room room);

        Task<bool> CheckMaxRoomsAsync(Room room);

        Task DeleteAsync(int id);
        Task UpdateAsync(Room room);
        Task<Room> FindIdAsync(int id);
    }
}
