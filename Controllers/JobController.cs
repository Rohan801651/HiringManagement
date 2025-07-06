using Microsoft.AspNetCore.Mvc;
using Recuriment_Platform.Data;
using Recuriment_Platform.Models;

namespace Recuriment_Platform.Controllers
{
    public class JobController : Controller
    {
        private readonly MyContextDB _context;

        public JobController(MyContextDB context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Job/GetAllJobs")]
        public List<Job> GetAllJobs()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            var job = _context.Jobs.ToList();
            return job;
        }


        [HttpGet]
        [Route("Job/GetJobById/{id}")]
        public Job GetJobById(int id)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            Job job = _context.Jobs.Find(id);
            return job;
        }

        [HttpPost]
        [Route("Job/CreateJob")]
        public void CreateJob([FromBody] Job job)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            if (ModelState.IsValid)
            {
                _context.Jobs.Add(job);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Model state is invalid. Please check the job data.");
            }

        }

        [HttpPut]
        [Route("Job/UpdateJob/{id}")]
        public void UpdateJob(int id, [FromBody] Job job)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            if (id != job.jobId)
            {
                throw new ArgumentException("Job id Did not match");
            }
            if (ModelState.IsValid)
            {
                _context.Jobs.Update(job);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Model state is invalid. Please check the job data.");
            }
        }

        [HttpDelete]
        [Route("/Job/DeleteJob/{id}")]
        public void DeleteJob(int id)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            Job job = _context.Jobs.Find(id);
            if (job == null)
            {
                throw new KeyNotFoundException("Job not found with the provided id.");
            }
            _context.Jobs.Remove(job);
            _context.SaveChanges();

        }

       






    }
}