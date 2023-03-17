using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.AppliactionCore.Contract.Repository;
using Onboarding.AppliactionCore.Contract.Service;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model.Request;
using Onboarding.ApplicationCore.Model.Response;

namespace Onboarding.Infrastruction.Service
{
    public class EmployeeRoleServiceAsync : IEmployeeRoleServiceAsync
    {
        private readonly IEmployeeRoleRepositoryAsync employeeRoleRepositoryAsync;

        public EmployeeRoleServiceAsync(IEmployeeRoleRepositoryAsync _employeeRoleRepositoryAsync)
        {
            employeeRoleRepositoryAsync = _employeeRoleRepositoryAsync;
        }
        public Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            EmployeeRole employeeRole = new EmployeeRole()
            {
                Name = model.Name,
                ABBR = model.ABBR
            };
            return employeeRoleRepositoryAsync.InsertAsync(employeeRole);
        }

        public Task<int> DeleteEmployeeRoleAsync(int id)
        {
            return employeeRoleRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoleAsync()
        {
            var result = await employeeRoleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeRoleResponseModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ABBR = x.ABBR
                });
            }
            return null;
        }

        public async Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id)
        {
            var result = await employeeRoleRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeRoleResponseModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    ABBR = result.ABBR

                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {

            EmployeeRole employeeRole = new EmployeeRole()
            {
                Id = model.Id,
                Name = model.Name,
                ABBR = model.ABBR
            };
            return employeeRoleRepositoryAsync.UpdateAsync(employeeRole);


        }
    }
}
