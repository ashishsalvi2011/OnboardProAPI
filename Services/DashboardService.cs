using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using OnboardPro.Repositories;

namespace OnboardPro.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepo;

        public DashboardService(IDashboardRepository dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }
        public async Task<List<DashboardStatDto>> GeDashboardStatsDatails()
        {
            return await _dashboardRepo.GeDashboardStatsDatails();
        }

    }
}
