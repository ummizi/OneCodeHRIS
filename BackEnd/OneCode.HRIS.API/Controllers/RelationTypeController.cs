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
    public class RelationTypeController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public RelationTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterRelationType> GetRelationType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterRelationTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterRelationType> GetById(Guid id)
        {
            return _context.MasterRelationTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterRelationType> PostRelationType(MasterRelationType relationType)
        {
            if (ModelState.IsValid)
            {
                relationType.Id = Guid.NewGuid();
                _context.MasterRelationTypes.Add(relationType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetRelationType), new { id = relationType.Id }, relationType);
            }

            return relationType;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterRelationType> PutRelationType(Guid id, MasterRelationType relationType)
        {
            if (id != relationType.Id)
            {
                return BadRequest();
            }
            if (_context.MasterRelationTypes.Any(m => m.Id == id))
            {
                _context.Entry(relationType).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRelationType(Guid id)
        {

            var status = _context.MasterRelationTypes.Find(id);
            if (status != null)
            {
                _context.MasterRelationTypes.Remove(status);
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
