using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.Infrastruction.Data;
using Interview.ApplicationCore.Entity;

namespace Interview.Infrastruction.Repository
{
    public class InterviewsRepositoryAsync : BaseRepositoryAsync<Interviews>, IInterviewsRepositoryAsync
    {
        public InterviewsRepositoryAsync(InterviewDbContext _context) : base(_context)
        {
        }
    }
}
