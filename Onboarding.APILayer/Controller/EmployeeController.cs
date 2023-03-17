using Onboarding.ApplicationCore.Model.Request;
using Onboarding.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.AppliactionCore.Contract.Service;

namespace Onboarding.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _employeeServiceAsync)
        {
            employeeServiceAsync = _employeeServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.AddEmployeeAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeServiceAsync.GetAllEmployeeAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await employeeServiceAsync.DeleteEmployeeAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await employeeServiceAsync.UpdateEmployeeAsync(model));
            }
            return BadRequest(model);
        }
    }
}
