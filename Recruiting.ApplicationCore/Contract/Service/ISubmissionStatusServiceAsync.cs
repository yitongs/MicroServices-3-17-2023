using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Model.Request;
using Recruiting.ApplicationCore.Model.Response;

namespace Recruiting.ApplicationCore.Contract.Service
{
    public interface ISubmissionStatusServiceAsync
    {
        Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel model);
        Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel model);

        Task<int> DeleteSubmissionStatusAsync(int id);

        Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id);
        Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatusAsync();
    }
}
