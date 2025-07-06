using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recuriment_Platform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class McqController : ControllerBase
    {
        public class McqRequest
        {
            public string Text { get; set; }
            public int NumQuestions { get; set; }
        }

        public class McqResponse
        {
            public int Id { get; set; }
            public string Question { get; set; }
            public List<string> Options { get; set; }
            public string Answer { get; set; }
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateMcqs([FromBody] McqRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Text) || request.NumQuestions <= 0)
            {
                return BadRequest("Text and a positive number of questions are required.");
            }

            // Simulate AI processing delay
            await Task.Delay(1500);

            var mcqs = new List<McqResponse>();
            for (int i = 0; i < request.NumQuestions; i++)
            {
                mcqs.Add(new McqResponse
                {
                    Id = i + 1,
                    Question = $"Generated question {i + 1} based on: '{request.Text.Substring(0, System.Math.Min(request.Text.Length, 20))}...'?",
                    Options = new List<string> { "Option A", "Option B", "Option C", "Option D" },
                    Answer = "Option A" // Placeholder answer
                });
            }

            return Ok(mcqs);
        }
    }
}