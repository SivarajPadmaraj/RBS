using System;

namespace CR.RoomBooking.Data.Domain
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int RoomId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PartySize { get; set; }

    }
}