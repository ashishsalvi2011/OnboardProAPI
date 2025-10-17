using OnboardPro.Models;

namespace OnboardPro.Services
{
    public interface ITenantProvider
    {
        TenantInfoModel Tenant { get; }
        void SetTenant(TenantInfoModel tenant);
    }

    public class TenantProviderService: ITenantProvider
    {
        private TenantInfoModel _tenant;
        public TenantInfoModel Tenant => _tenant ?? throw new Exception("Tenant not initialized.");

        public void SetTenant(TenantInfoModel tenant)
        {
            _tenant = tenant;
        }
    }
}
