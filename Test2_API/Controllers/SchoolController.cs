using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test2_API.database;
using Test2_API.model;

namespace Test2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private EfModel _efModel;

        public SchoolController(EfModel model)
        {
            _efModel = model;
        }

        [HttpGet]
        public async Task<ActionResult<List<School>>> GetSchools()
        {
            return await _efModel.schools.ToListAsync();
        }

        [HttpGet("{schoolId}")]
        public async Task<ActionResult<School>> GetUsers(int schoolId)
        {
            if (User == null)
                return NotFound();

            return await _efModel.schools.FindAsync(schoolId);
        }

        [HttpPost]
        public async Task<ActionResult<School>> PostSchol(School school)
        {
            _efModel.schools.Add(school);
            await _efModel.SaveChangesAsync();

            return CreatedAtAction(nameof(PostSchol), new { id = school.SchoolId }, school);
        }


        [HttpDelete("{schoolId}")]
        public async Task<IActionResult> DeleteSchool(int schoolId)
        {
            var school = await _efModel.schools.FindAsync(schoolId);
            if (school == null)
                return NotFound();
            _efModel.schools.Remove(school);
            await _efModel.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{schoolId}")]
        public async Task<IActionResult> PutSchool(long schoolId, School school)
        {
            if (schoolId != school.SchoolId)
                return BadRequest();

            _efModel.Entry(school).State = EntityState.Modified;
            try
            {
                await _efModel.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
