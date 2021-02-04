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
   public class RoomControllerTest
    {

        RoomController controller;
        IRoomService service;

        public RoomControllerTest()
        {
            service = new RoomServiceFake();
            controller = new RoomController(service);
        }


        [Fact]
        public async void PostAsync_WhenCalledWithValidModel_ReturnsOk()
        {
            // Act
            var result = await controller.PostAsync(new Room() { RoomID = 1, PersonID = 1, Type = 0 });

            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async void GetAllAsync_WhenCalled_ReturnsAllRooms()
        {
            // Act
            var rooms = await controller.GetAllAsync("2021-02-02" , "2021-05-05", 0);

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Room>>(rooms);
            Assert.Equal(4, rooms.ToList().Count);
        }
        [Fact]
        public async void PostUpdateAsync_WhenCalledWithValidModel_ReturnsOk()
        {
            // Act
            var result = await controller.UpdateRoom(new Room()
            {
               RoomID = 1, PersonID = 1, Type = 1 
            });

            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async void DeletAsync_whenCall_Resturnsok()
        {
            var result = await controller.DeleteRoom(2);

            Assert.IsType<OkResult>(result);
        }
    }
}
