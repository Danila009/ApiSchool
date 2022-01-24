using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchooApi.model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test2_API.database;

namespace Test2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private EfModel _efModel;

        public SubjectController(EfModel model)
        {
            _efModel = model;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetSchools()
        {
            return await _efModel.subjects.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> PostSchol(Subject subject, int studentId)
        {
            var student = await _efModel.students.FindAsync(studentId);

            if (student == null)
                return NotFound();

            _efModel.subjects.Add(subject);
            await _efModel.SaveChangesAsync();

            return CreatedAtAction(nameof(PostSchol), new { id = subject.SubjectId }, subject);
        }
    }
}
