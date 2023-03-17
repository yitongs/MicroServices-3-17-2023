using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model.Request;
using Interview.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Interview.ApplicationCore.HttpModel;

namespace Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewsServiceAsync interviewsServiceAsync;

        public InterviewsController(IInterviewsServiceAsync _interviewsServiceAsync)
        {
            interviewsServiceAsync = _interviewsServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(InterviewsRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewsServiceAsync.AddInterviewsAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewsServiceAsync.GetAllInterviewsAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await interviewsServiceAsync.DeleteInterviewsAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] InterviewsRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await interviewsServiceAsync.UpdateInterviewsAsync(model));
            }
            return BadRequest(model);
        }


    }
}
