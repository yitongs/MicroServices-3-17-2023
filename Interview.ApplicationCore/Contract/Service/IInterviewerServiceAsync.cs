using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Model.Request;
using Interview.ApplicationCore.Model.Response;

namespace Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewerServiceAsync
    {
        Task<int> AddInterviewerAsync(InterviewerRequestModel model);
        Task<int> UpdateInterviewerAsync(InterviewerRequestModel model);
        Task<int> DeleteInterviewerAsync(int id);
        Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id);
        Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewerAsync();
    }
}
