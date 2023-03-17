using Interview.ApplicationCore.HttpModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewSubmissionController : ControllerBase
    {
        private readonly HttpClient httpClient = new HttpClient();


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<SubmissionModel>>("http://10.0.0.86:56283/api/Submission");
            return Ok(result);
        }
    }
}
