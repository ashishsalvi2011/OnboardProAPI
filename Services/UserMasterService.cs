using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class UserMasterService : IUserMasterService
    {
        private readonly IUserMasterRepository _repo;

        public UserMasterService(IUserMasterRepository repo)
        {
            _repo = repo;
        }

        public Task<List<RoleDto>> GetActiveRolesAsync() => _repo.GetActiveRolesAsync();

        public async Task<int> SaveUserAsync(UserDto user)
        {
            return await _repo.InsertOrUpdateUserAsync(user);
        }

        public Task<List<UserResponseDto>> GetUsersAsync() => _repo.GetUsersAsync();
    }
}
