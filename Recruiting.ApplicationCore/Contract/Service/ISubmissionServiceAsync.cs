using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Model.Request;
using Recruiting.ApplicationCore.Model.Response;

namespace Recruiting.ApplicationCore.Contract.Service
{
    public interface ISubmissionServiceAsync
    {
        Task<int> AddSubmissionAsync(SubmissionRequestModel model);
        Task<int> UpdateSubmissionAsync(SubmissionRequestModel model);

        Task<int> DeleteSubmissionAsync(int id);

        Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id);
        Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionAsync();
    }
}
