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
    public class InterviewTypeRepositoryAsync : BaseRepositoryAsync<InterviewType>, IInterviewTypeRepositoryAsync
    {
        public InterviewTypeRepositoryAsync(InterviewDbContext _context) : base(_context)
        {
        }
    }
}
