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
using Recruiting.Infrastruction.Repository;

namespace Recruiting.Infrastruction.Service
{
    public class SubmissionStatusServiceAsync: ISubmissionStatusServiceAsync
    {
        private readonly ISubmissionStatusRepositoryAsync submissionStatusRepositoryAsync;

        public SubmissionStatusServiceAsync(ISubmissionStatusRepositoryAsync _submissionStatusRepositoryAsync)
        {
            submissionStatusRepositoryAsync = _submissionStatusRepositoryAsync;
        }

        public Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            SubmissionStatus submissionStatus = new SubmissionStatus()
            {
                Description = model.Description

            };
            return submissionStatusRepositoryAsync.InsertAsync(submissionStatus);
        }

        public Task<int> DeleteSubmissionStatusAsync(int id)
        {
            return submissionStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatusAsync()
        {
            var result = await submissionStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new SubmissionStatusResponseModel()
                {
                    Id = x.Id,
                    Description = x.Description
                });
            }
            return null;
        }

        public async Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id)
        {
            var result = await submissionStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new SubmissionStatusResponseModel()
                {
                    Id = result.Id,
                    Description = result.Description
                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            SubmissionStatus submissionStatus = new SubmissionStatus()
            {
                Id = model.Id,
                Description = model.Description
            };
            return submissionStatusRepositoryAsync.UpdateAsync(submissionStatus);
        }
    }
}
