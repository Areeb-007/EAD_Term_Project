using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        OnlineJobPortalContext jobPortalContext;
        public JobsController()
        {
            jobPortalContext = new OnlineJobPortalContext();
        }


        [HttpGet]
        [Route("getJobs")]
        public List<TblJob> GetJobs()
        {
            return jobPortalContext.TblJobs.ToList();
        }

        [HttpGet]
        [Route("getJobs/{id}")]
        public TblJob GetJobById(int id)
        {
            return jobPortalContext.TblJobs.First(job => job.Id == id);
        }

        [HttpGet]
        [Route("getJobsByDepartment/{department}")]
        public List<TblJob> GetJobsOnDepartment(string department)
        {
            return jobPortalContext.TblJobs.Where(job => job.Department.Equals(department)).ToList();
        }

        [HttpPost]
        [Route("addJob")]
        public async Task AddJob(TblJob job)
        {
            jobPortalContext.TblJobs.Add(job);
            await jobPortalContext.SaveChangesAsync();
        }

        [HttpPut]
        [Route("updateJob/{id}")]
        public void UpdateJob(TblJob job1,int id)
        {
            TblJob job2 = new TblJob();
            try
            {
                job2 = jobPortalContext.TblJobs.First(jb => jb.Id == id);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"The Message is {ex.Message}");
            }

            if(job2.Id != null)
            {
                job2.Title = job1.Title;
                job2.Location = job1.Location;
                job2.Experience = job1.Experience;
                job2.TypeOfContract = job1.TypeOfContract;
                job2.QualificationRequired = job1.QualificationRequired;
                job2.SkillsRequired = job1.SkillsRequired;
                job2.JobPostingDate = job1.JobPostingDate;
                job2.JobJoiningDate = job1.JobJoiningDate;
                job2.Salary = job1.Salary;
                job2.CompanyId = job1.CompanyId;
                job2.JobStatus = job1.JobStatus;
                job2.Department = job1.Department;
                jobPortalContext.SaveChangesAsync();
            }
        }
    }
}
