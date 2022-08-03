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
    public class FacilityTypeController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public FacilityTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterFacilityType> GetFacilityType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterFacilityTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterFacilityType> GetById(Guid id)
        {
            return _context.MasterFacilityTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterFacilityType> PostFacilityType(MasterFacilityType facilityType)
        {
            if (ModelState.IsValid)
            {
                facilityType.Id = Guid.NewGuid();
                _context.MasterFacilityTypes.Add(facilityType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetFacilityType), new { id = facilityType.Id }, facilityType);
            }

            return facilityType;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterFacilityType> PutFacilityType(Guid id, MasterFacilityType facilityType)
        {
            if (id != facilityType.Id)
            {
                return BadRequest();
            }
            if (_context.MasterFacilityTypes.Any(m => m.Id == id))
            {
                _context.Entry(facilityType).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFacilityType(Guid id)
        {

            var status = _context.MasterFacilityTypes.Find(id);
            if (status != null)
            {
                _context.MasterFacilityTypes.Remove(status);
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
