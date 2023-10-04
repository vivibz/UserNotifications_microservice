using AutoMapper;
using UserNotifications.Models;

namespace UserNotifications.Api.DTOs.Mappings
{
    public class MappingsProfile: Profile
    {
        public MappingsProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Subscription, SubscriptionDTO>().ReverseMap();
  

        }
    }
}
