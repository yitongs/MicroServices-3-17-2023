using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model.Request;
using Interview.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterServiceAsync recruiterServiceAsync;

        public RecruiterController(IRecruiterServiceAsync _recruiterServiceAsync)
        {
            recruiterServiceAsync = _recruiterServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(RecruiterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await recruiterServiceAsync.AddRecruiterAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await recruiterServiceAsync.GetAllRecruiterAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await recruiterServiceAsync.DeleteRecruiterAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RecruiterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await recruiterServiceAsync.UpdateRecruiterAsync(model));
            }
            return BadRequest(model);
        }
    }
}
