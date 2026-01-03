using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<List<DashboardStatDto>> GeDashboardStatsDatails();
    }
}
