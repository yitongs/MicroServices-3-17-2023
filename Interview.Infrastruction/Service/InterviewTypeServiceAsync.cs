using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.Infrastruction.Data;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model.Request;
using Interview.ApplicationCore.Model.Response;

namespace Interview.Infrastruction.Service
{
    public class InterviewTypeServiceAsync:IInterviewTypeServiceAsync
    {
        private readonly IInterviewTypeRepositoryAsync interviewTypeRepositoryAsync;

        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync _interviewTypeRepositoryAsync)
        {
            interviewTypeRepositoryAsync = _interviewTypeRepositoryAsync;
        }
        public Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Title = model.Title
            };
            return interviewTypeRepositoryAsync.InsertAsync(interviewType);
        }

        public Task<int> DeleteInterviewTypeAsync(int id)
        {
            return interviewTypeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypeAsync()
        {
            var result = await interviewTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewTypeResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title
                });
            }
            return null;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var result = await interviewTypeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewTypeResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title

                };
            }
            return null;
        }

        public Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {

            InterviewType interviewType = new InterviewType()
            {
                Id = model.Id,
                Title = model.Title
            };
            return interviewTypeRepositoryAsync.UpdateAsync(interviewType);


        }
    }
}
