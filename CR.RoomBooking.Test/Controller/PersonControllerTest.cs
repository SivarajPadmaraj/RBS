using CR.RoomBooking.Data.Domain;
using CR.RoomBooking.Services;
using CR.RoomBooking.Services.Services;
using CR.RoomBooking.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CR.RoomBooking.Test.Controller
{
    public class PersonControllerTest
    {
       

        PersonController controller;
        IPersonService service;

        public PersonControllerTest()
        {
            service = new PersonServiceFake();
            controller = new PersonController(service);
        }


        [Fact]
        public async void GetAllAsync_WhenCalled_ReturnsAllHotels()
        {
            // Act
            var persons = await controller.GetAllAsync();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Person>>(persons);
            Assert.Equal(3, persons.ToList().Count);
        }
       
        [Fact]
        public async void PostAsync_WhenCalledWithValidModel_ReturnsOk()
        {
            // Act
            var result = await controller.PostAsync(new Person() {
                Id = ' ',
                FirstName = "Orange ",
                LastName = "Juice",
                Email = "OrangeJuice@gmail.com",
                Phone = "123"
            });

            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async void DeletAsync_whenCall_Resturnsok()
        {
            var result = await controller.DeletePerson(2);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void PostUpdateAsync_WhenCalledWithValidModel_ReturnsOk()
        {
            // Act
            var result = await controller.UpdatePerson(new Person()
            {
                Id = 2,
                FirstName = "Orange22 ",
                LastName = "Juice",
                Email = "OrangeJuice@gmail.com",
                Phone = "123"
            });

            Assert.IsType<OkResult>(result);
        }
       


    }
}
