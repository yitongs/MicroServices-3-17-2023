using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model.Request;
using Interview.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerServiceAsync interviewerServiceAsync;

        public InterviewerController(IInterviewerServiceAsync _interviewerServiceAsync)
        {
            interviewerServiceAsync = _interviewerServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(InterviewerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewerServiceAsync.AddInterviewerAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewerServiceAsync.GetAllInterviewerAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await interviewerServiceAsync.DeleteInterviewerAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] InterviewerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await interviewerServiceAsync.UpdateInterviewerAsync(model));
            }
            return BadRequest(model);
        }
    }
}
