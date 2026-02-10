using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using OnboardPro.Services;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplianceController : ControllerBase
    {
        private readonly IComplianceService _complianceService;
        public ComplianceController(IComplianceService complianceService)
        {
            _complianceService = complianceService;
        }

        [HttpPost("contract-license-save")]
        public async Task<IActionResult> ContractLabourLicenseSave([FromBody] ContractLabourLicenseDto dto)
        {
            try
            { 
                var data = await _complianceService.SaveLicenseWithFilesAsync(dto);

                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "Contract license saved loaded successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }                       
        }

        [HttpPost("bocw-save")]
        public async Task<IActionResult> BOCWSave([FromBody] BOCWLicenseDto dto)
        {
            try
            {
                var data = await _complianceService.SaveBOCWAsync(dto);

                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "BOCW license saved loaded successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost("migrant-save")]
        public async Task<IActionResult> InterstateMigrant([FromBody] MigrantLicenseDto dto)
        {
            try
            {
                var data = await _complianceService.SaveInterstateMigrant(dto);

                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "Contract license saved loaded successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost("factory-license-save")]
        public async Task<IActionResult> FactoryLicenseSave([FromBody] FactoryLicenseDto dto)
        {
            try
            {
                var data = await _complianceService.SaveFactoryLicense(dto);

                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "Contract license saved loaded successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("wage-master")]
        public async Task<IActionResult> GeWagMasterDatails()
        {
            try
            {
                var data = await _complianceService.GeWagMasterDatails();

                return Ok(new ListResponseModel<WageMasterDto>
                {
                    Success = true,
                    Message = "Wages Master loaded successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }


        }

        [HttpPost("wage-master-save")]
        public async Task<IActionResult> WagesMasterSave([FromBody] List<WageMasterDto> dto)
        {
            try
            {
                var data = await _complianceService.SaveWagesMaster(dto);

                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "Wages Master saved successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}
