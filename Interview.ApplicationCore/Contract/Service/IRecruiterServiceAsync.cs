using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Model.Request;
using Interview.ApplicationCore.Model.Response;

namespace Interview.ApplicationCore.Contract.Service
{
    public interface IRecruiterServiceAsync
    {
        Task<int> AddRecruiterAsync(RecruiterRequestModel model);
        Task<int> UpdateRecruiterAsync(RecruiterRequestModel model);
        Task<int> DeleteRecruiterAsync(int id);
        Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id);
        Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiterAsync();
    }
}
