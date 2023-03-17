using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model.Request;
using Interview.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackServiceAsync feedbackServiceAsync;

        public FeedbackController(IFeedbackServiceAsync _feedbackServiceAsync)
        {
            feedbackServiceAsync = _feedbackServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(FeedbackRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await feedbackServiceAsync.AddFeedbackAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await feedbackServiceAsync.GetAllFeedbackAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await feedbackServiceAsync.DeleteFeedbackAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FeedbackRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await feedbackServiceAsync.UpdateFeedbackAsync(model));
            }
            return BadRequest(model);
        }
    }
}
