using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNotifications.Repositories;
using UserNotifications.Repositories.Interfaces;

namespace UserNotification.Tests.Repository
{
    internal class UserRepositoryTests
    {
        private UserRepository userRepository;
        public UserRepositoryTests() 
        {
            userRepository = new UserRepository(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }
    }
}
