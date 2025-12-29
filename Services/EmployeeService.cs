using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<DraftWorkerDto>> GetDraftWorkersAsync()
        {
            return await _employeeRepository.GetDraftWorkersAsync();
        }
        public async Task<int> ExitWorkerAsync(ExitWorkerDto request)
        {
            return await _employeeRepository.ExitWorkerAsync(request);
        }
        public async Task<List<OnBoardWorkerDto>> GetOnBoardWorkersAsync()
        {
            return await _employeeRepository.GetOnBoardWorkersAsync();
        }
    }
}
