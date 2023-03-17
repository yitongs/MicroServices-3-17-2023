using Onboarding.ApplicationCore.Model.Request;
using Onboarding.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.AppliactionCore.Contract.Service;

namespace Onboarding.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmployeeStatusServiceAsync employeeStatusServiceAsync;

        public EmployeeStatusController(IEmployeeStatusServiceAsync _employeeStatusServiceAsync)
        {
            employeeStatusServiceAsync = _employeeStatusServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeStatusServiceAsync.AddEmployeeStatusAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeStatusServiceAsync.GetAllEmployeeStatusAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await employeeStatusServiceAsync.DeleteEmployeeStatusAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await employeeStatusServiceAsync.UpdateEmployeeStatusAsync(model));
            }
            return BadRequest(model);
        }

    }
}
