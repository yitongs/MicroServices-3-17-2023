using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.Infrastruction.Data
{
    public class RecruitingDbContext : DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) : base(options)
        {

        }
        public DbSet<Candidate> Candidate { get; set; }

        public DbSet<JobRequirement> JobRequirement { get; set; }

        public DbSet<Submission> Submission { get; set; }
        public DbSet<SubmissionStatus> SubmissionStatus { get; set; }
    }
}
