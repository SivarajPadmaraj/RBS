﻿using System;

namespace CR.RoomBooking.Data.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public string Phone { get; set; }

        
    }
}