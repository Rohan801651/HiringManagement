using Microsoft.AspNetCore.Mvc;
using Recuriment_Platform.Data;
using Recuriment_Platform.Models;
using System.Linq;

namespace Recuriment_Platform.Controllers
{
    public class CandidateController : Controller
    {
        private readonly MyContextDB _context;

        public CandidateController(MyContextDB context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Candidate> GetAllCandidates()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            return _context.Candidates.ToList();
        }

        [HttpGet]
        public Candidate GetCandidateById(int id)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            return _context.Candidates.Find(id); ;
        }


        [HttpPost]
        public void CreateCandidate([FromBody] Candidate candidate)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            if (ModelState.IsValid)
            {
                _context.Candidates.Add(candidate);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Model state is invalid. Please check the candidate data.");
            }
        }

        [HttpPut]
        public void UpdateCandidate(int id, [FromBody] Candidate candidate)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            if (ModelState.IsValid)
            {
                _context.Candidates.Update(candidate);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Model state is invalid. Please check the candidate data.");
            }
        }

        [HttpDelete]
        public void DeleteCandidate(int id)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            var candidate = _context.Candidates.Find(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Candidate not found.");
            }
        }







    }
}