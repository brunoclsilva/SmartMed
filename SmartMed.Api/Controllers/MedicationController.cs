using Microsoft.AspNetCore.Mvc;
using SmartMed.Domain.Entities;
using SmartMed.Domain.Interfaces.Services;

namespace SmartMed.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly ILogger<MedicationController> _logger;
        private readonly IMedicationService _medicationService;

        public MedicationController(ILogger<MedicationController> logger, 
                                    IMedicationService medicationService)
        {
            _logger = logger;
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                _logger.LogInformation("Searching Medications.");
                var response = await _medicationService.GetAsync();
                _logger.LogInformation("Medications returned.");

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] Medication medication)
        {
            try
            {
                _logger.LogInformation("Creating Medication.");
                var response = await _medicationService.CreateAsync(medication);
                _logger.LogInformation("Medication created.");

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw;
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Deleting Medication.");
                var response = await _medicationService.DeleteAsync(id);
                _logger.LogInformation("Medication deleted.");

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw;
            }
        }
    }
}