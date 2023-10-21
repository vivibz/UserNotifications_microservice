using AutoMapper;
using UserNotifications.Api.DTOs;
using UserNotifications.Api.Services.Interface;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public async Task<UserDTO> GetByIdAsync(int id)
        {
            if(id == 0)
                throw new Exception("Id is not valid");

            var userId = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(userId);
        }

        public async Task<UserDTO> CreateUserAsync(string fullName)
        {
            if (fullName == null || fullName == "")
                throw new Exception("FullName invalid");

                var userEntity = _mapper.Map<User>(new UserDTO { FullName = fullName, CreateAt = DateTime.Now});
                var createdUser = await _userRepository.Create(userEntity);
                return _mapper.Map<UserDTO>(createdUser);
        }

    }
}
