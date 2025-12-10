using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IUserMasterService
    {
        Task<List<RoleDto>> GetActiveRolesAsync();
        Task<int> SaveUserAsync(UserDto user);
        Task<List<UserResponseDto>> GetUsersAsync();

    }
}
