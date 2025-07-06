using Microsoft.AspNetCore.Mvc;
using Recuriment_Platform.Data;
using Recuriment_Platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Recuriment_Platform.Controllers
{
    public class ApplyController : Controller
    {
        private readonly MyContextDB _context;

        public ApplyController(MyContextDB context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Apply/GetAllApplies")]
        public List<Apply> GetApplies()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            return _context.Applies.ToList();
        }

        [HttpGet]
        [Route("Apply/GetApplyById/{jobId}/{candidateId}")]
        public Apply GetApplyById(int jobId, int candidateId)
        {
            if(_context == null)
            {
                throw new ArgumentException("Context is null");
            }
            Apply apply = _context.Applies.Find(jobId, candidateId);
            return apply;
        }

        [HttpPost]
        [Route("Apply/CreateApply")]
        public void CreateApply([FromBody] Apply apply)
        {
            int id = apply.CandidateId;
            CandidateController candidateController = new CandidateController(_context);
            Candidate can = candidateController.GetCandidateById(id);
            apply.Candidate = can;

            if (apply == null)
            {
                throw new ArgumentNullException("Apply object cannot be null.");
            }
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            _context.Applies.Add(apply);
            _context.SaveChanges();
        }

        [HttpPut]
        [Route("Apply/UpdateApply")]
        public void UpdateApply([FromBody] Apply apply)
        {
            if (apply == null)
            {
                throw new ArgumentNullException("Apply object cannot be null.");
            }
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            _context.Applies.Update(apply);
            _context.SaveChanges();
        }

        [HttpDelete]
        [Route("Apply/DeleteApply/{jobId}/{candidateId}")]
        public void DeleteApply(int jobId, int candidateId)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            Apply apply = _context.Applies.Find(jobId, candidateId);
            if (apply != null)
            {
                _context.Applies.Remove(apply);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Apply not found for the given JobId and CandidateId.");
            }
        }






    }
}