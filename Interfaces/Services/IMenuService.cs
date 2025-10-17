using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuDto>> GetMenusByRoleAsync(int roleId);
    }
}
