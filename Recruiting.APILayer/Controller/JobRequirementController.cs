using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Model.Request;
using Recruiting.Infrastruction.Service;

namespace Recruiting.APILayer.Controller
{
    [Authorize(Roles = "Admin,Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;

        public JobRequirementController(IJobRequirementServiceAsync _jobRequirementServiceAsync)
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobRequirementServiceAsync.AddJobRequirementAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await jobRequirementServiceAsync.GetAllJobRequirementAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await jobRequirementServiceAsync.DeleteJobRequirementAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await jobRequirementServiceAsync.UpdateJobRequirementAsync(model));
            }
            return BadRequest(model);
        }
    }
}
