using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IUserMasterRepository
    {
        Task<List<RoleDto>> GetActiveRolesAsync();
        Task<int> InsertOrUpdateUserAsync(UserDto user);
        Task<List<UserResponseDto>> GetUsersAsync();

    }
}
