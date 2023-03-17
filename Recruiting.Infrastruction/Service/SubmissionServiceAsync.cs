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
    public class SubmissionServiceAsync : ISubmissionServiceAsync
    {
        private readonly ISubmissionRepositoryAsync submissionRepositoryAsync;

        public SubmissionServiceAsync(ISubmissionRepositoryAsync _submissionRepositoryAsync)
        {   
            submissionRepositoryAsync = _submissionRepositoryAsync;
        }

        public Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                SubmittedOn = model.SubmittedOn,
                ConfirmedOn = model.ConfirmedOn,
                RejectedOn = model.RejectedOn,
                SubmissionStatus = model.SubmissionStatus,
                Candidate = model.Candidate,
                JobRequirement = model.JobRequirement

            };
            return submissionRepositoryAsync.InsertAsync(submission);
        }

        public Task<int> DeleteSubmissionAsync(int id)
        {
            return submissionRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionAsync()
        {
            var result = await submissionRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new SubmissionResponseModel()
                {
                    Id = x.Id,
                    SubmittedOn = x.SubmittedOn,
                    ConfirmedOn = x.ConfirmedOn,
                    RejectedOn = x.RejectedOn,
                    SubmissionStatus = x.SubmissionStatus,
                    Candidate = x.Candidate,
                    JobRequirement = x.JobRequirement
                });
            }
            return null;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var result = await submissionRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new SubmissionResponseModel()
                {
                    Id = result.Id,
                    SubmittedOn = result.SubmittedOn,
                    ConfirmedOn = result.ConfirmedOn,
                    RejectedOn = result.RejectedOn,
                    SubmissionStatus = result.SubmissionStatus,
                    Candidate = result.Candidate,
                    JobRequirement = result.JobRequirement
                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                SubmittedOn = model.SubmittedOn,
                ConfirmedOn = model.ConfirmedOn,
                RejectedOn = model.RejectedOn,
                SubmissionStatus = model.SubmissionStatus,
                Candidate = model.Candidate,
                JobRequirement = model.JobRequirement

            };
            return submissionRepositoryAsync.UpdateAsync(submission);
        }
    }
}
