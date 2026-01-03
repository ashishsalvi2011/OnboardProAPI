using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IDashboardRepository
    {
        Task<List<DashboardStatDto>> GeDashboardStatsDatails();
    }
}
