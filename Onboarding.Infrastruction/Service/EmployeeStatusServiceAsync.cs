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
    public class EmployeeStatusServiceAsync : IEmployeeStatusServiceAsync
    {
        private readonly IEmployeeStatusRepositoryAsync employeeStatusRepositoryAsync;

        public EmployeeStatusServiceAsync(IEmployeeStatusRepositoryAsync _employeeStatusRepositoryAsync)
        {
            employeeStatusRepositoryAsync = _employeeStatusRepositoryAsync;
        }
        public Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                ABBR = model.ABBR,
                Description = model.Description
            };
            return employeeStatusRepositoryAsync.InsertAsync(employeeStatus);
        }

        public Task<int> DeleteEmployeeStatusAsync(int id)
        {
            return employeeStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync()
        {
            var result = await employeeStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeStatusResponseModel()
                {
                    Id = x.Id,
                    ABBR = x.ABBR,
                    Description = x.Description
                });
            }
            return null;
        }

        public async Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id)
        {
            var result = await employeeStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeStatusResponseModel()
                {
                    Id = result.Id,
                    ABBR = result.ABBR,
                    Description = result.Description

                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {

            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                Id = model.Id,
                ABBR = model.ABBR,
                Description = model.Description
            };
            return employeeStatusRepositoryAsync.UpdateAsync(employeeStatus);


        }
    }
}
