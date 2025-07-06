using Microsoft.AspNetCore.Mvc;
using Recuriment_Platform.Data;
using Recuriment_Platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Recuriment_Platform.Controllers
{
    public class EducationController : Controller
    {
        private readonly MyContextDB _context;

        public EducationController(MyContextDB context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Education> GetAllEducations()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            return _context.Educations.ToList();
        }

        [HttpGet]
        public Education GetEducationById(int id)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            return _context.Educations.Find(id);
        }

        [HttpGet]
        public List<Education> GetEducationByCandidateId(int candidateId)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            return _context.Educations.Where(e => e.CandidateId == candidateId).ToList();
        }




        [HttpPost]
        [Route("/Education/CreateEducation")]
        public IActionResult CreateEducation([FromBody] Education education)
        {
            if (_context == null)
            {
                return StatusCode(500, "Database context is not initialized.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Fetch the Candidate directly using the context
                var candidate = _context.Candidates.Find(education.CandidateId);
                if (candidate == null)
                {
                    return NotFound($"Candidate with ID {education.CandidateId} not found.");
                }

                // Associate the Candidate with the Education
                education.Candidate = candidate;
                // Ensure CandidateId is set (redundant but ensures consistency)
                education.CandidateId = candidate.Id;

                // Add and save the Education record
                _context.Educations.Add(education);
                _context.SaveChanges();

                // Return a 201 Created response with the created resource
                return CreatedAtAction(nameof(GetEducationById), new { id = education.Id }, education);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the education record: {ex.Message}");
            }
        }

        [HttpPost]
        public void CreateEducationWithCandidateId([FromBody] Education education, int candidateId)
        {



            if (_context == null)
            {
                throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
            }
            if (ModelState.IsValid)
            {
                education.CandidateId = candidateId; // Set the CandidateId
                _context.Educations.Add(education);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Model state is invalid. Please check the education data.");
            }

        }

        [HttpPut]
        public IActionResult UpdateEducation(int id, [FromBody] Education education)
        {
            if (_context == null)
            {
                return StatusCode(500, "Context is null. Please ensure it is properly initialized.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is invalid. Please check the education data.");
            }
            var existingEducation = _context.Educations.Find(id);
            if (existingEducation == null)
            {
                return NotFound("Education not found.");
            }
            _context.Educations.Update(education);
            _context.SaveChanges();
            return Ok(education);
        }

        [HttpDelete]
        public IActionResult DeleteEducation(int id)
        {
            if (_context == null)
            {
                return StatusCode(500, "Context is null. Please ensure it is properly initialized.");
            }
            var education = _context.Educations.Find(id);
            if (education == null)
            {
                return NotFound("Education not found.");
            }
            _context.Educations.Remove(education);
            _context.SaveChanges();
            return Ok(new { message = "Education deleted successfully." });
        }

        //[HttpGet]
        //[Route("Education/GetCandidateSelectList")]
        //public List<SelectListItem> GetCandidateSelectList()
        //{
        //    if (_context == null)
        //    {
        //        throw new InvalidOperationException("Context is null. Please ensure it is properly initialized.");
        //    }
        //    return _context.Candidates.Select(c => new SelectListItem
        //    {
        //        Value = c.Id.ToString(),
        //        Text = c.Name // Assuming Candidate has a Name property
        //    }).ToList();

        }


}
