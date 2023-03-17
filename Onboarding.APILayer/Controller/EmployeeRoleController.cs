using Onboarding.ApplicationCore.Model.Request;
using Onboarding.Infrastruction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.AppliactionCore.Contract.Service;

namespace Onboarding.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmployeeRoleServiceAsync employeeRoleServiceAsync;

        public EmployeeRoleController(IEmployeeRoleServiceAsync _employeeRoleServiceAsync)
        {
            employeeRoleServiceAsync = _employeeRoleServiceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeRoleServiceAsync.AddEmployeeRoleAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeRoleServiceAsync.GetAllEmployeeRoleAsync();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await employeeRoleServiceAsync.DeleteEmployeeRoleAsync(id) > 0);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await employeeRoleServiceAsync.UpdateEmployeeRoleAsync(model));
            }
            return BadRequest(model);
        }
    }
}
