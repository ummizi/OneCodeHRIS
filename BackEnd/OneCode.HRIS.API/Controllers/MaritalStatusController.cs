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
    public class MaritalStatusController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public MaritalStatusController(EmployeeContext context)
        {
            _context = context;
        }

        //GET : api/MaritalStatus
        [HttpGet]
        public IEnumerable<MasterMaritalStatus> GetMaritalStatus()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterMaritalStatuses.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterMaritalStatus> GetById(Guid id)
        {
            return _context.MasterMaritalStatuses.FirstOrDefault(m => m.Id == id);
        }


        [HttpPost]
        public ActionResult<MasterMaritalStatus> PostMaritalStatus(MasterMaritalStatus maritalStatus)
        {
            if(ModelState.IsValid)
            {
                maritalStatus.Id = Guid.NewGuid();
                _context.MasterMaritalStatuses.Add(maritalStatus);
                _context.SaveChanges();
                return CreatedAtAction("GetMaritalStatus", new { id = maritalStatus.Id }, maritalStatus);
            }

            return maritalStatus;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterMaritalStatus> PutMaritalStatus(Guid id, MasterMaritalStatus maritalStatus)
        {
            if (id != maritalStatus.Id)
            {
                return BadRequest();
            }    
            if (_context.MasterMaritalStatuses.Any(m=>m.Id == id))
            {
                _context.Entry(maritalStatus).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMaritalStatus(Guid id)
        {
            var status = _context.MasterMaritalStatuses.Find(id);
            if (status != null)
            {
                _context.MasterMaritalStatuses.Remove(status);
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
