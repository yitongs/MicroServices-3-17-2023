using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.ApplicationCore.Entity;

namespace Interview.ApplicationCore.Contract.Repository
{
    public interface IInterviewTypeRepositoryAsync: IRepositoryAsync<InterviewType>
    {
    }
}
