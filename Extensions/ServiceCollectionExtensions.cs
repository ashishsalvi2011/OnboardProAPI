using OnboardPro.Helper;
using OnboardPro.Interface;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Repositories;
using OnboardPro.Repository;
using OnboardPro.Services;

namespace OnboardPro.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoginOTPService, LoginOTPService>();
            services.AddScoped<ILoginOTPRepository, LoginOTPRepository>();
            services.AddScoped<IMenuService,MenuService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISkillMasterService, SkillMasterService>();
            services.AddScoped<ISkillMasterRepository, SkillMasterRepository>();
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IUserMasterService, UserMasterService>();
            services.AddScoped<IUserMasterRepository, UserMasterRepository>();
            services.AddScoped<IVendorMasterService, VendorMasterService>();
            services.AddScoped<IVendorMasterRepository, VendorMasterRepository>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Complince
            services.AddScoped<IWorkerSkillVerificationService, WorkerSkillVerificationService>();
            services.AddScoped<IWorkerSkillVerificationRepository, WorkerSkillVerificationRepository>();
            services.AddScoped<IWorkerMedicalVerificationService, WorkerMedicalVerificationService>();
            services.AddScoped<IWorkerMedicalVerificationRepository, WorkerMedicalVerificationRepository>();
            services.AddScoped<IWorkerEHSVerificationService, WorkerEHSVerificationService>();
            services.AddScoped<IWorkerEHSVerificationRepository, WorkerEHSVerificationRepository>();
            services.AddScoped<IFinalApprovalService, FinalApprovalService>();
            services.AddScoped<IFinalApprovalRepository, FinalApprovalRepository>();
            services.AddScoped<IWorkerDoctorVerificationService, WorkerDoctorVerificationService>();
            services.AddScoped<IWorkerDoctorVerificationRepository, WorkerDoctorVerificationRepository>();
            services.AddScoped<IWorkerPFService, WorkerPFService>();
            services.AddScoped<IWorkerPFRepository, WorkerPFRepository>();


            services.AddScoped<JwtService>();
            services.AddSingleton<IResponse, ResponseService>();
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddHttpContextAccessor();
            services.AddScoped<ITenantProvider, TenantProviderService>();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Program));
            services.AddHttpContextAccessor();

            return services;

        }
    }
}
    