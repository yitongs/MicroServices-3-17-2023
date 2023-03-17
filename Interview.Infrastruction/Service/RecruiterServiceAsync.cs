using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Model.Request;
using Interview.ApplicationCore.Model.Response;
using Interview.Infrastruction.Repository;

namespace Interview.Infrastruction.Service
{
    public class RecruiterServiceAsync: IRecruiterServiceAsync
    {
        private readonly IRecruiterRepositoryAsync recruiterRepositoryAsync;

        public RecruiterServiceAsync(IRecruiterRepositoryAsync _recruiterRepositoryAsync)
        {
            recruiterRepositoryAsync = _recruiterRepositoryAsync;
        }
        public Task<int> AddRecruiterAsync(RecruiterRequestModel model)
        {
            Recruiter recruiter = new Recruiter()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeId = model.EmployeeId

            };
            return recruiterRepositoryAsync.InsertAsync(recruiter);
        }

        public Task<int> DeleteRecruiterAsync(int id)
        {
            return recruiterRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiterAsync()
        {
            var result = await recruiterRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new RecruiterResponseModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmployeeId = x.EmployeeId
                });
            }
            return null;
        }

        public async Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id)
        {
            var result = await recruiterRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new RecruiterResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    EmployeeId = result.EmployeeId

                };
            }
            return null;
        }

        public Task<int> UpdateRecruiterAsync(RecruiterRequestModel model)
        {

            Recruiter recruiter = new Recruiter()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeId = model.EmployeeId
            };
            return recruiterRepositoryAsync.UpdateAsync(recruiter);


        }
    }
}
