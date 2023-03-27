using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Model.Request;

namespace Recruiting.APILayer.Controller
{
    [Authorize(Roles = "Admin,Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;

        public SubmissionController(ISubmissionServiceAsync _submissionServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubmissionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await submissionServiceAsync.AddSubmissionAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await submissionServiceAsync.GetAllSubmissionAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await submissionServiceAsync.DeleteSubmissionAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SubmissionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await submissionServiceAsync.UpdateSubmissionAsync(model));
            }
            return BadRequest(model);
        }
    }
}
