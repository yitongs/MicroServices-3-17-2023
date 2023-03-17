using Onboarding.ApplicationCore.Model.Request;
using Onboarding.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.AppliactionCore.Contract.Service;

namespace Onboarding.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeServiceAsync employeeTypeServiceAsync;

        public EmployeeTypeController(IEmployeeTypeServiceAsync _employeeTypeServiceAsync)
        {
            employeeTypeServiceAsync = _employeeTypeServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeTypeServiceAsync.AddEmployeeTypeAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeTypeServiceAsync.GetAllEmployeeTypeAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await employeeTypeServiceAsync.DeleteEmployeeTypeAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await employeeTypeServiceAsync.UpdateEmployeeTypeAsync(model));
            }
            return BadRequest(model);
        }
    }
}
