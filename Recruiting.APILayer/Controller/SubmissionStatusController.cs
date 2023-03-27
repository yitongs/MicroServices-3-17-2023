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
    public class SubmissionStatusController : ControllerBase
    {
        private readonly ISubmissionStatusServiceAsync submissionStatusServiceAsync;

        public SubmissionStatusController(ISubmissionStatusServiceAsync _submissionStatusServiceAsync)
        {
            submissionStatusServiceAsync = _submissionStatusServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubmissionStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await submissionStatusServiceAsync.AddSubmissionStatusAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await submissionStatusServiceAsync.GetAllSubmissionStatusAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await submissionStatusServiceAsync.DeleteSubmissionStatusAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SubmissionStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await submissionStatusServiceAsync.UpdateSubmissionStatusAsync(model));
            }
            return BadRequest(model);
        }

    }
}
