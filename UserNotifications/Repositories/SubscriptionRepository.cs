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

        public async Task<Subscription> SubmitUserSubscription(int userId, int subscription)
        {

            var subscriptionToSumit = await _context.Subscriptions.Where(s => s.UserId == userId).FirstOrDefaultAsync();
            var submitStatus = await _context.Subscriptions.Include(s => s.StatusId).Where(s => s.StatusId == subscription).FirstOrDefaultAsync();
            await _context.SaveChangesAsync();
            return submitStatus;
        }

        public async Task<Subscription> UpdateSubscription(int userId, ESubscription subscription)
        {
           var subscriptionToUpdate = _context.Subscriptions.Include(s => s.User).Where(s => s.UserId == userId).FirstOrDefaultAsync();
            
            if (subscriptionToUpdate != null)
            {
              if(subscription == ESubscription.PURCHASED || ESubscription.RESTARTED == subscription || ESubscription.CANCELED == subscription) 
              {
                  _context.Entry(subscription).State = EntityState.Modified;
                  await _context.SaveChangesAsync();
                    
                }
         
            }
            throw new NotImplementedException(); // TODO

        }
    }
}
