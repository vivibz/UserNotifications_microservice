using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNotifications.Api.DTOs;
using UserNotifications.Api.Services;
using UserNotifications.Repositories.Interfaces;
using Xunit;

namespace UserNotificationTests.Services
{
    public class UserServiceTests
    {
        private UserService userService;

        public UserServiceTests() 
        {
            userService = new UserService(new Mock<IMapper>().Object, new Mock<IUserRepository>().Object);
        }
        [Fact]
        public void GetById_Sending()
        {
            var exception = Assert.ThrowsAsync<Exception>(() => userService.GetByIdAsync(0));
            Assert.Equal("Id is not valid", exception?.Result.Message.ToString());
        }
        [Fact]
        public void CreatedUser_SendingValidId()
        {
            var exception = Assert.ThrowsAsync<Exception>(() => userService.CreateUserAsync(""));
            Assert.Equal("FullName invalid", exception?.Result.Message);
        }
        [Fact]
        public void CreatedUserNull_SendingValidId()
        {
            var exception = Assert.ThrowsAsync<Exception>(() => userService.CreateUserAsync(null));
            Assert.Equal("FullName invalid", exception?.Result.Message);
        }
    }
}
