using Interview.ApplicationCore.HttpModel;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewCandidateController : ControllerBase
    {
        private readonly HttpClient httpClient = new HttpClient();


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<CandidateModel>>("http://10.0.0.86:56283/api/candidate");
            return Ok(result);
        }
    }
}
