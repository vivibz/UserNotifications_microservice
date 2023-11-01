using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNotifications.Api.Services;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;
using Xunit;

namespace UserNotificationTests.Services
{
    public class SubscriptionServiceTest
    {
        private SubscriptionService subscriptionService;
        //public SubscriptionServiceTest()
        //{
        //    subscriptionService = new SubscriptionService(new Mock<IMapper>().Object, new Mock<ISubscriptionRepository>().Object);
        //}
        //[Fact]
        //public void GetSubscriptionByStatus_SendingUserId()
        //{
        //    var exception = Assert.ThrowsAsync<Exception>(() => subscriptionService.GetSubscriptionByStatus(0));
        //    Assert.Equal("StatusId is not valid", exception?.Result.Message.ToString());
        //}
        //[Fact]
        //public void GetSubscriptionByUser_SendingUserId()
        //{
        //    var exception = Assert.ThrowsAsync<Exception>(() => subscriptionService.GetSubscriptionByUser(0));
        //    Assert.Equal("UserId is not valid", exception?.Result.Message);
        //}
        //[Fact]
        //public void SubmitUserSubscription_SendingUserId()
        //{
        //    var exception = Assert.ThrowsAsync<Exception>(() => subscriptionService.SubmitUserSubscription(0, new Status().StatusName));
        //    Assert.Equal("UserID is not valid", exception?.Result.Message);
        //}

        


    }
}
