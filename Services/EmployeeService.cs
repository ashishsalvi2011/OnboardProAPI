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
        public async Task<List<OnBoardWorkerDto>> GetWorkersForExit()
        {
            return await _employeeRepository.GetWorkersForExit();
        }
        public async Task<int> ExitWorkerAsync(ExitWorkerDto request)
        {
            return await _employeeRepository.ExitWorkerAsync(request);
        }
        public async Task<List<OnBoardWorkerDto>> GetOnBoardWorkersAsync()
        {
            return await _employeeRepository.GetOnBoardWorkersAsync();
        }
        public async Task<List<WorkerIdCardDto>> GetIdCardDetails()
        {
            return await _employeeRepository.GetWorkerIdCardAsync();
        }
        public async Task<int> InsertOrUpdateRewardAsync(WorkerRewardUpsertDto dto)
        {
            return await _employeeRepository.InsertOrUpdateWorkerRewardAsync(dto);
        }
        public async Task<int> BlockOrUnblockWorkerAsync(WorkerBlockRequestDto dto)
        {
            return await _employeeRepository.BlockOrUnblockWorkerAsync(dto);
        }
        public async Task<List<ReturnedWorkerDto>> GetReturnedWorkersAsync()
        {
            return await _employeeRepository.GetReturnedWorkersAsync();
        }
    }
}
