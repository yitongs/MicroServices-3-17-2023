using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Model.Request;
using Recruiting.Infrastruction.Service;

namespace Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServiceAsync candidateServiceAsync;

        public CandidateController(ICandidateServiceAsync _candidateServiceAsync)
        {
            candidateServiceAsync = _candidateServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await candidateServiceAsync.AddCandidateAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await candidateServiceAsync.GetAllCandidatesAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await candidateServiceAsync.DeleteCandidateAsync(id));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await candidateServiceAsync.UpdateCandidateAsync(model));
            }
            return BadRequest(model);
        }

        [HttpGet("{id:int}")]
        public  IActionResult Get(int id)
        {
            return Ok();
        }
    }
}
