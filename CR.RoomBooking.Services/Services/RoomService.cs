using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Data.Interfaces;
using CR.RoomBooking.Services.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Services.Services
{
   public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> ListAsync(string startDate, string endDate, int partySize)
        {
            DateTime sDate, eDate;
            // Check dates and party size are valid
            if (DateTime.TryParse(startDate, out sDate) && DateTime.TryParse(endDate, out eDate) && partySize > 0)
            {
                return await roomRepository.ListAsync(sDate, eDate, partySize);
            }
            // otherwise, just resort to get-all
            return await roomRepository.ListAsync();
        }

        public async Task<Result> SaveAsync(Room room)
        {
            if (await roomRepository.CheckMaxRoomsAsync(room))
            {
                try
                {
                    await roomRepository.AddAsync(room);
                    return Result.Success;
                }
                catch
                {
                    return Result.Failure;
                }
            }
            return Result.Failure; //TODO: add more error info
        }

        public async Task<Result> UpdateAsync(Room room)
        {
            try
            {
                await roomRepository.UpdateAsync(room);
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
        }

        public async Task<Room> FindIdAsync(int id)
        {
            if (id >= 0)
            {
                return await roomRepository.FindIdAsync(id);

            }
            return await roomRepository.FindIdAsync(id);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            try
            {
                await roomRepository.DeleteAsync(id);
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
        }
    }
}
