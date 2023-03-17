using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model.Request;
using Interview.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewTypeController : ControllerBase
    {
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;

        public InterviewTypeController(IInterviewTypeServiceAsync _interviewTypeServiceAsync)
        {
            interviewTypeServiceAsync = _interviewTypeServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(InterviewTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewTypeServiceAsync.AddInterviewTypeAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewTypeServiceAsync.GetAllInterviewTypeAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await interviewTypeServiceAsync.DeleteInterviewTypeAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] InterviewTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await interviewTypeServiceAsync.UpdateInterviewTypeAsync(model));
            }
            return BadRequest(model);
        }
    }
}
