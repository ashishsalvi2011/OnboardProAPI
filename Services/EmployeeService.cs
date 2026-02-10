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
        public async Task<List<DraftWorkerDto>> GetDraftWorkersAsync(int userId)
        {
            return await _employeeRepository.GetDraftWorkersAsync(userId);
        }
        public async Task<List<OnBoardWorkerDto>> GetWorkersForExit(int userId)
        {
            return await _employeeRepository.GetWorkersForExit(userId);
        }
        public async Task<int> ExitWorkerAsync(ExitWorkerDto request)
        {
            return await _employeeRepository.ExitWorkerAsync(request);
        }
        public async Task<List<OnBoardWorkerDto>> GetOnBoardWorkersAsync(int userId)
        {
            return await _employeeRepository.GetOnBoardWorkersAsync(userId);
        }
        public async Task<List<WorkerIdCardDto>> GetIdCardDetails(int userId)
        {
            return await _employeeRepository.GetWorkerIdCardAsync(userId);
        }
        public async Task<int> InsertOrUpdateRewardAsync(WorkerRewardUpsertDto dto)
        {
            return await _employeeRepository.InsertOrUpdateWorkerRewardAsync(dto);
        }
        public async Task<int> BlockOrUnblockWorkerAsync(WorkerBlockRequestDto dto)
        {
            return await _employeeRepository.BlockOrUnblockWorkerAsync(dto);
        }
        public async Task<List<ReturnedWorkerDto>> GetReturnedWorkersAsync(int userId)
        {
            return await _employeeRepository.GetReturnedWorkersAsync(userId);
        }
        public async Task<int> UpdateWokerGatePassDetails(WorkerWageDto request)
        {
            return await _employeeRepository.UpdateWokerGatePassDetails(request);
        }
    }
}
