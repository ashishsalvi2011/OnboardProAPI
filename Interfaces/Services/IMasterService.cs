using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IMasterService
    {
        Task<List<GenderDto>> GetGenders();
    }
}
