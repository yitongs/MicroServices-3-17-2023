using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Model.Request;
using Interview.ApplicationCore.Model.Response;

namespace Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewsServiceAsync
    {
        Task<int> AddInterviewsAsync(InterviewsRequestModel model);
        Task<int> UpdateInterviewsAsync(InterviewsRequestModel model);

        Task<int> DeleteInterviewsAsync(int id);

        Task<InterviewsResponseModel> GetInterviewsByIdAsync(int id);
        Task<IEnumerable<InterviewsResponseModel>> GetAllInterviewsAsync();
    }
}
