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
    public class CandidateServiceAsync : ICandidateServiceAsync
    {
        private readonly ICandidateRepositoryAsync candidateRepositoryAsync;

        public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepositoryAsync)
        {
            candidateRepositoryAsync = _candidateRepositoryAsync;
        }
        public Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                EmailId = model.EmailId

            };
            return candidateRepositoryAsync.InsertAsync(candidate);
        }

        public Task<int> DeleteCandidateAsync(int id)
        {
            return candidateRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidatesAsync()
        {
            var result = await candidateRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new CandidateResponseModel()
                { Id = x.Id, EmailId = x.EmailId, FirstName = x.FirstName, MiddleName = x.MiddleName, LastName = x.LastName });
            }
            return null;
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var result = await candidateRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new CandidateResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    MiddleName = result.MiddleName,
                    LastName = result.LastName,
                    EmailId = result.EmailId

                };
            }
            return null;
        }

        public Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {

            Candidate candidate = new Candidate()
            {
                Id = model.Id,
                EmailId = model.EmailId,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName
            };
            return candidateRepositoryAsync.UpdateAsync(candidate);


        }
    }
}
