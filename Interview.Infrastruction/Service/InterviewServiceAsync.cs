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
    public class InterviewsServiceAsync : IInterviewsServiceAsync
    {
        private readonly IInterviewsRepositoryAsync interviewsRepositoryAsync;

        public InterviewsServiceAsync(IInterviewsRepositoryAsync _interviewsRepositoryAsync)
        {
            interviewsRepositoryAsync = _interviewsRepositoryAsync;
        }

        public Task<int> AddInterviewsAsync(InterviewsRequestModel model)
        {
            Interviews interviews = new Interviews()
            {
                SubmissionId = model.SubmissionId,
                Recruiter = model.Recruiter,
                ScheduledOn = model.ScheduledOn,
                InterviewRound = model.InterviewRound,
                Feedback = model.Feedback,
                InterviewType = model.InterviewType,
                Interviewer = model.Interviewer

            };
            return interviewsRepositoryAsync.InsertAsync(interviews);
        }

        public Task<int> DeleteInterviewsAsync(int id)
        {
            return interviewsRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewsResponseModel>> GetAllInterviewsAsync()
        {
            var result = await interviewsRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewsResponseModel()
                {   
                    Id = x.Id,
                    SubmissionId = x.SubmissionId,
                    Recruiter = x.Recruiter,
                    ScheduledOn = x.ScheduledOn,
                    InterviewRound = x.InterviewRound,
                    Feedback = x.Feedback,
                    InterviewType = x.InterviewType,
                    Interviewer = x.Interviewer
                });
            }
            return null;
        }

        public async Task<InterviewsResponseModel> GetInterviewsByIdAsync(int id)
        {
            var result = await interviewsRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewsResponseModel()
                {
                    Id = result.Id,
                    SubmissionId = result.SubmissionId,
                    Recruiter = result.Recruiter,
                    ScheduledOn = result.ScheduledOn,
                    InterviewRound = result.InterviewRound,
                    Feedback = result.Feedback,
                    InterviewType = result.InterviewType,
                    Interviewer = result.Interviewer
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewsAsync(InterviewsRequestModel model)
        {
            Interviews interviews = new Interviews()
            {
                Id = model.Id,
                SubmissionId = model.SubmissionId,
                Recruiter = model.Recruiter,
                ScheduledOn = model.ScheduledOn,
                InterviewRound = model.InterviewRound,
                Feedback = model.Feedback,
                InterviewType = model.InterviewType,
                Interviewer = model.Interviewer

            };
            return interviewsRepositoryAsync.UpdateAsync(interviews);
        }
    }
}
