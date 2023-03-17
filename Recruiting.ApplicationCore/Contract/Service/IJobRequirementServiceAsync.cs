using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Model.Request;
using Recruiting.ApplicationCore.Model.Response;

namespace Recruiting.ApplicationCore.Contract.Service
{
    public interface IJobRequirementServiceAsync
    {
        Task<int> AddJobRequirementAsync(JobRequirementRequestModel model);
        Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model);

        Task<int> DeleteJobRequirementAsync(int id);

        Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id);
        Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementAsync();
    }
}
