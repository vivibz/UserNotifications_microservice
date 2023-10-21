using UserNotifications.Api.DTOs;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Api.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> CreateUserAsync(string fullName);
    }
}
