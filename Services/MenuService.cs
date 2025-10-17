using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuDto>> GetMenusByRoleAsync(int roleId)
        {
            var menus = await _menuRepository.GetMenusByRoleAsync(roleId);
            return menus;
        }
    }
}
