using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using OneCode.HRIS.Models.EmployeeModels;

namespace OneCode.HRIS.API.Controllers
{

    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class SpecialCaseTypeController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public SpecialCaseTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterSpecialCaseType> GetSpecialCaseType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterSpecialCaseTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterSpecialCaseType> GetById(Guid id)
        {
            return _context.MasterSpecialCaseTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterSpecialCaseType> PostSpecialCaseType(MasterSpecialCaseType specialCase)
        {
            if (ModelState.IsValid)
            {
                specialCase.Id = Guid.NewGuid();
                _context.MasterSpecialCaseTypes.Add(specialCase);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetSpecialCaseType), new { id = specialCase.Id }, specialCase);
            }

            return specialCase;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterSpecialCaseType> PutSpecialCaseType(Guid id, MasterSpecialCaseType specialCase)
        {
            if (id != specialCase.Id)
            {
                return BadRequest();
            }
            if (_context.MasterSpecialCaseTypes.Any(m => m.Id == id))
            {
                _context.Entry(specialCase).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSpecialCaseType(Guid id)
        {

            var status = _context.MasterSpecialCaseTypes.Find(id);
            if (status != null)
            {
                _context.MasterSpecialCaseTypes.Remove(status);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
