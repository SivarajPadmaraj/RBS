using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services.Enum;
using CR.RoomBooking.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Test
{
   public class RoomServiceFake : IRoomService
    {
        private readonly List<Room> rooms;

        public RoomServiceFake()
        {
            rooms = new List<Room>()
            {
                new Room() { RoomID = 1, PersonID = 1, Type = 0},
                new Room() { RoomID = 2, PersonID = 1, Type = 0},
                new Room() { RoomID = 3, PersonID = 2, Type = 0},
                new Room() { RoomID = 6, PersonID = 5, Type = 0}
            };
        }

        public async Task<IEnumerable<Room>> ListAsync(string startDate, string endDate, int partySize)
        {
            DateTime sDate, eDate;
            if (DateTime.TryParse(startDate, out sDate) && DateTime.TryParse(endDate, out eDate) && partySize > 0)
            {
                return rooms.GetRange(1, 3);
            }
            return rooms;
        }

        public async Task<Result> SaveAsync(Room room)
        {
            rooms.Add(room);
            return Result.Success;
        }

        public Task<Room> FindIdAsync(int id)
        {
            throw new NotImplementedException();
            //Person person = _persons.Where(a => a.Id == id).FirstOrDefault();
            //return person;
        }
        public async Task<Result> DeleteAsync(int id)
        {
            Room room = rooms.Where(a => a.RoomID == id).FirstOrDefault();
            if (room.RoomID == id)
            {
                rooms.Remove(room);
                return Result.Success;
            }

            return Result.Failure;


        }

        public async Task<Result> UpdateAsync(Room room)
        {
            Room exsistingRoom = rooms.Where(a => a.RoomID == room.RoomID).FirstOrDefault();
            if (exsistingRoom != null)
            {
                exsistingRoom.RoomID = room.RoomID;
                exsistingRoom.PersonID = room.PersonID;
                exsistingRoom.Type = room.Type;
                return Result.Success;
            }

            return Result.Failure;

        }

    }
}
