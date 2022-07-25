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
    public class IdentityController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public IdentityController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterIdentity> GetIdentity()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterIdentities.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterIdentity> GetById(Guid id)
        {
            return _context.MasterIdentities.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterIdentity> PostIdentity(MasterIdentity identity)
        {
            if (ModelState.IsValid)
            {
                identity.Id = Guid.NewGuid();
                _context.MasterIdentities.Add(identity);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetIdentity), new { id = identity.Id }, identity);
            }

            return identity;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterIdentity> PutIdentity(Guid id, MasterIdentity identity)
        {
            if (id != identity.Id)
            {
                return BadRequest();
            }
            if (_context.MasterIdentities.Any(m => m.Id == id))
            {
                _context.Entry(identity).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteIdentity(Guid id)
        {

            var status = _context.MasterIdentities.Find(id);
            if (status != null)
            {
                _context.MasterIdentities.Remove(status);
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
