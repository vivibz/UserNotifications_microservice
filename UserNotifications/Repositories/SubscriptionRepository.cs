using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using UserNotifications.Context;
using UserNotifications.Enums;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace UserNotifications.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;


        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Subscription>> GetSubscriptionByStatus(int statusId)
        {
            return await _context.Subscriptions.Include(s => s.Status).Where(s => s.StatusId == statusId).ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionByUser(int userId)
        {
            return await _context.Subscriptions.Include(s => s.User).Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task<bool> SubmitUserSubscription(int userId, string notification)
        {
            try
            {
                if (_context.Users.Where(u => u.Id == userId) == null)
                {
                    throw new Exception("User Not Found.");
                }

                var subscription = await _context.Subscriptions.Include(s => s.Status).Where(s => s.UserId == userId).FirstOrDefaultAsync();
                //TODO: Usar dictionary
                switch (notification)
                {
                    case "SUBSCRIPTION_PURCHASED":
                        if(subscription.Status.StatusName == "ACTIVE" )
                        {
                            throw new Exception("Subscription already activated.");
                        }
                        else
                        {
                           subscription.Status = await _context.Status.Where(s => s.StatusName == "ACTIVE").FirstOrDefaultAsync();
                           await _context.EventHistory.AddAsync(new EventHistory { SubscriptionId = subscription.Id, CreatedAt = DateTime.Now, Type = notification});
                        }
                        break;
                    case "SUBSCRIPTION_CANCELED":
                        if(subscription.Status.StatusName == "CANCELED")
                        {
                            throw new Exception("Subscription already canceled.");
                        }else
                        {
                            subscription.Status = await _context.Status.Where(s => s.StatusName == "CANCELED").FirstOrDefaultAsync();
                            await _context.EventHistory.AddAsync(new EventHistory { SubscriptionId = subscription.Id, CreatedAt= DateTime.Now, Type = notification});
                        }
                        break;
                    case "SUBSCRIPTION_RESTARTED":
                        if (subscription.Status.StatusName == "ACTIVE")
                        {
                            throw new Exception("Can not restart an active subscription.");
                        }
                        else
                        {
                            subscription.Status = await _context.Status.Where(s => s.StatusName == "ACTIVE").FirstOrDefaultAsync();
                            await _context.EventHistory.AddAsync(new EventHistory { SubscriptionId = subscription.Id, CreatedAt = DateTime.Now, Type = notification });
                        }
                        break;
                    default: throw new Exception("Invalid Notification.");
                }
                return await _context.SaveChangesAsync() > 0;
                
             }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }
    }
}
