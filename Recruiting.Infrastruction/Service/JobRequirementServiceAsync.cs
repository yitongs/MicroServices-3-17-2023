using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Model.Request;
using Recruiting.ApplicationCore.Model.Response;

namespace Recruiting.Infrastruction.Service
{
    public class JobRequirementServiceAsync : IJobRequirementServiceAsync
    {
        private readonly IJobRequirementRepositoryAsync jobRequirementRepositoryAsync;

        public JobRequirementServiceAsync(IJobRequirementRepositoryAsync _jobRequirementRepositoryAsync)
        {
            jobRequirementRepositoryAsync = _jobRequirementRepositoryAsync;
        }

        public Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Title = model.Title,
                Description = model.Description,
                NumberOfPositions = model.NumberOfPositions,
                HiringManagerId = model.HiringManagerId,
                HiringManagerName = model.HiringManagerName,
                StartDate = model.StartDate,
                ClosedOn = model.ClosedOn,
                ClosedReason = model.ClosedReason,
                CreateOn = model.CreateOn,
                IsActive = model.IsActive,
                JobCategory = model.JobCategory,
                EmployeeType = model.EmployeeType,

            };
            return jobRequirementRepositoryAsync.InsertAsync(jobRequirement);
        }

        public Task<int> DeleteJobRequirementAsync(int id)
        {
            return jobRequirementRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementAsync()
        {
            var result = await jobRequirementRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new JobRequirementResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    NumberOfPositions = x.NumberOfPositions,
                    HiringManagerId = x.HiringManagerId,
                    HiringManagerName = x.HiringManagerName,
                    StartDate = x.StartDate,
                    ClosedOn = x.ClosedOn,
                    ClosedReason = x.ClosedReason,
                    CreateOn = x.CreateOn,
                    IsActive = x.IsActive,
                    JobCategory = x.JobCategory,
                    EmployeeType = x.EmployeeType,
                });
            }
            return null;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var result = await jobRequirementRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new JobRequirementResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    NumberOfPositions = result.NumberOfPositions,
                    HiringManagerId = result.HiringManagerId,
                    HiringManagerName = result.HiringManagerName,
                    StartDate = result.StartDate,
                    ClosedOn = result.ClosedOn,
                    ClosedReason = result.ClosedReason,
                    CreateOn = result.CreateOn,
                    IsActive = result.IsActive,
                    JobCategory = result.JobCategory,
                    EmployeeType = result.EmployeeType,
                };
            }
            return null;
        }

        public Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                NumberOfPositions = model.NumberOfPositions,
                HiringManagerId = model.HiringManagerId,
                HiringManagerName = model.HiringManagerName,
                StartDate = model.StartDate,
                ClosedOn = model.ClosedOn,
                ClosedReason = model.ClosedReason,
                CreateOn = model.CreateOn,
                IsActive = model.IsActive,
                JobCategory = model.JobCategory,
                EmployeeType = model.EmployeeType,

            };
            return jobRequirementRepositoryAsync.UpdateAsync(jobRequirement);
        }
    }
}
