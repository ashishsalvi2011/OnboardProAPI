using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuDto>> GetMenusByRoleAsync(int roleId);
    }
}
