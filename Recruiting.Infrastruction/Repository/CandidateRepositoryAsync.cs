using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.Infrastruction.Data;

namespace Recruiting.Infrastruction.Repository
{
    public class CandidateRepositoryAsync : BaseRepositoryAsync<Candidate>, ICandidateRepositoryAsync
    {
        public CandidateRepositoryAsync(RecruitingDbContext _context) : base(_context)
        {
        }
    }
}
