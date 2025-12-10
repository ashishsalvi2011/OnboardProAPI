using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository _masterRepo;

        public MasterService(IMasterRepository masterRepo)
        {
            _masterRepo = masterRepo;
        }

        public Task<List<GenderDto>> GetGenders()
        {
            return _masterRepo.GetGenders();
        }
    }
}
