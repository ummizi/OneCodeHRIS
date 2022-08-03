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
    public class ContactTypeController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public ContactTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterContactType> GetContactType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterContactTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterContactType> GetById(Guid id)
        {
            return _context.MasterContactTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterContactType> PostContactType(MasterContactType contactType)
        {
            if (ModelState.IsValid)
            {
                contactType.Id = Guid.NewGuid();
                _context.MasterContactTypes.Add(contactType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetContactType), new { id = contactType.Id }, contactType);
            }

            return contactType;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterContactType> PutContactType(Guid id, MasterContactType contactType)
        {
            if (id != contactType.Id)
            {
                return BadRequest();
            }
            if (_context.MasterContactTypes.Any(m => m.Id == id))
            {
                _context.Entry(contactType).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContactType(Guid id)
        {
            
            var status = _context.MasterContactTypes.Find(id);
            if (status != null)
            {
                _context.MasterContactTypes.Remove(status);
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
