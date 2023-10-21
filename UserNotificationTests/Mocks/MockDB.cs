using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNotifications.Context;

namespace UserNotificationTests.Mocks
{
    internal class MockDB : IDbContextFactory<AppDbContext>
    {
        //mock do banco
        public AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc}")
                .Options;

            return new AppDbContext(options);
        }
    }
}
