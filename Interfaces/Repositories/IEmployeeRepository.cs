using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<DraftWorkerDto>> GetDraftWorkersAsync();
    }
}
