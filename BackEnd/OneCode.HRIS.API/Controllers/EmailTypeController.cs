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
    public class EmailTypeController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmailTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterEmailType> GetEmailType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterEmailTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterEmailType> GetById(Guid id)
        {
            return _context.MasterEmailTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterEmailType> PostEmailType(MasterEmailType emailType)
        {
            if (ModelState.IsValid)
            {
                emailType.Id = Guid.NewGuid();
                _context.MasterEmailTypes.Add(emailType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetEmailType), new { id = emailType.Id }, emailType);
            }

            return emailType;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterEmailType> PutEmailType(Guid id, MasterEmailType emailType)
        {
            if (id != emailType.Id)
            {
                return BadRequest();
            }
            if (_context.MasterEmailTypes.Any(m => m.Id == id))
            {
                _context.Entry(emailType).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmailType(Guid id)
        {

            var status = _context.MasterEmailTypes.Find(id);
            if (status != null)
            {
                _context.MasterEmailTypes.Remove(status);
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
