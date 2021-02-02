using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Services.Services
{
   public interface IRoomService
    {
        Task<IEnumerable<Room>> ListAsync(string startDate, string endDate, int partySize);

        Task<Result> SaveAsync(Room room);
    }
}
