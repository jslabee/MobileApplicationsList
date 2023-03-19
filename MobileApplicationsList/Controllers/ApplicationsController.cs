using Microsoft.AspNetCore.Mvc;
using MobileApplicationsList.Services;
using MobileApplicationsList.Services.ApiModel;

namespace MobileApplicationsList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateApplicationRequest>> CreateApplication(CreateApplicationRequest application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
      
               return Ok(await _applicationService.AddApplicationAsync(application));

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<PageParameters<IApplicationDetailsResponse>>> GetAllApplications(int page = 1, int pageSize = 2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (page  < 0 || pageSize < 0)
            {
                return BadRequest("Integers must be a positive.");
            }

            try
            {
                var applications = await _applicationService.GetAllApplications(page, pageSize);

                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
