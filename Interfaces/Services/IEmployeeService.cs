using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<List<DraftWorkerDto>> GetDraftWorkersAsync();
    }
}
