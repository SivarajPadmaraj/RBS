using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.RoomBooking.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private RoomBookingsContext _Context;

        public RoomRepository(RoomBookingsContext context)
        {
            _Context = context;
        }


        public async Task<IEnumerable<Room>> ListAsync()
        {
            return await _Context.Rooms.ToListAsync();
        }

        public async Task<IEnumerable<Room>> ListAsync(DateTime startDate, DateTime endDate, int partySize)
        {
            // Get RoomIDs of bookings that clash with the dates
            var unavailableRooms = await _Context.Bookings
                .Where(b => b.StartDate < endDate && startDate < b.EndDate)
                .Select(b => b.RoomId)
                .ToListAsync();
            // Only return available rooms that have sufficient capacity
            return await _Context.Rooms.ToListAsync();
        }

        public async Task AddAsync(Room room)
        {
            await _Context.Rooms.AddAsync(room);
            await _Context.SaveChangesAsync();
        }

        public async Task<bool> CheckMaxRoomsAsync(Room room)
        {
            int roomCount = await _Context.Rooms.CountAsync(r => r.PersonID == room.PersonID);
            return roomCount < 6;
        }

        public async Task DeleteAsync(int id)
        {

            Room rooma = _Context.Rooms.FirstOrDefault(s => s.RoomID == id);
            if (rooma.RoomID == id)
            {
                _Context.Rooms.Remove(rooma);
                _Context.SaveChanges();
            }

        }
        public async Task UpdateAsync(Room room)
        {
            Room existingRoom = await _Context.Rooms.FirstOrDefaultAsync(s => s.RoomID == room.RoomID);

            if (existingRoom != null)
            {
                existingRoom.RoomID = room.RoomID;
                existingRoom.PersonID = room.PersonID;
                existingRoom.Type = room.Type;

                _Context.Attach(existingRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _Context.SaveChangesAsync();
            }

        }

        public async Task<Room> FindIdAsync(int id)
        {
            return await _Context.Rooms.FirstOrDefaultAsync(s => s.RoomID == id);


        }
    }
}
