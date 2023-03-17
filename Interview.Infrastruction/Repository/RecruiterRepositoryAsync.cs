using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.ApplicationCore.Entity;
using Interview.Infrastruction.Data;

namespace Interview.Infrastruction.Repository
{
    public class RecruiterRepositoryAsync : BaseRepositoryAsync<Recruiter>, IRecruiterRepositoryAsync
    {
        public RecruiterRepositoryAsync(InterviewDbContext _context) : base(_context)
        {

        }
    }
}
