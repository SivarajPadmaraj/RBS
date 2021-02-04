using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services.Services;
using CR.RoomBooking.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CR.RoomBooking.Test.Controller
{
    public class BookingControllerTest
    {
        RoomBookingController controller;
        IBookingService service;

        public BookingControllerTest()
        {
            service = new BookingServiceFake();
            controller = new RoomBookingController(service);
        }

        [Fact]
        public async void DeletAsync_whenCall_Resturnsok()
        {
            var result = await controller.DeleteBooking(5);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void GetAllAsync_WhenCalled_ReturnsAllBookings()
        {
            // Act
            var _bookings = await controller.GetAllAsync();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Booking>>(_bookings);
            Assert.Equal(3, _bookings.ToList().Count);
        }
      
    }
}
