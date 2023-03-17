using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Model.Response
{
    public class CandidateResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string? ResumeUrl { get; set; }
    }
}
