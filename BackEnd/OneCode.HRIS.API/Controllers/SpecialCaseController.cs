using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OneCode.HRIS.Models.Employee;
using OneCode.HRIS.Models.Setup;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using OneCode.HRIS.Models.EmployeeModels;

namespace OneCode.HRIS.API.Controllers
{

    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class SpecialCaseController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public SpecialCaseController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionSpecialCase> GetSpecialCase()
        {
            using (var context = new EmployeeContext())
            {
                return context.TransactionSpecialCases.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionSpecialCase> GetById(Guid id)
        {
            return _context.TransactionSpecialCases.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionSpecialCase> PostSpecialCase(TransactionSpecialCase specialCase)
        {
            if (ModelState.IsValid)
            {
                specialCase.Id = Guid.NewGuid();
                _context.TransactionSpecialCases.Add(specialCase);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetSpecialCase), new { id = specialCase.Id }, specialCase);
            }

            return specialCase;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionSpecialCase> PutSpecialCase(Guid id, TransactionSpecialCase specialCase)
        {
            if (id != specialCase.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionSpecialCases.Any(m => m.Id == id))
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
        public ActionResult DeleteSpecialCase(Guid id)
        {

            var status = _context.TransactionSpecialCases.Find(id);
            if (status != null)
            {
                _context.TransactionSpecialCases.Remove(status);
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
