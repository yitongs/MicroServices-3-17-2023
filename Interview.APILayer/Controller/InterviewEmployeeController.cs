using Interview.ApplicationCore.HttpModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewEmployeeController : ControllerBase
    {
        private readonly HttpClient httpClient = new HttpClient();


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EmployeeModel>>("http://10.0.0.86:56285/api/Employee");
            return Ok(result);
        }
    }
}
