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
    public class FacilityController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public FacilityController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionFacility> GetFacility()
        {
            using (var context = new EmployeeContext())
            {
                List<TransactionFacility> facilities = context.TransactionFacilities.ToList();
                foreach (var rec in facilities)
                {
                    rec.FacilityType = context.MasterFacilityTypes.Where(x => x.Id == rec.FacilityTypeId).FirstOrDefault();
                    rec.Identity = context.MasterIdentities.Where(x => x.Id == rec.IdentityId).FirstOrDefault();
                    rec.PersonalData = context.TransactionPersonalDatas.Where(x => x.Id == rec.PersonalDataId).FirstOrDefault();
                }
                return facilities;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionFacility> GetById(Guid id)
        {
            return _context.TransactionFacilities.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionFacility> PostFacility(TransactionFacility facility)
        {
            if (ModelState.IsValid)
            {
                facility.Id = Guid.NewGuid();
                _context.TransactionFacilities.Add(facility);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetFacility), new { id = facility.Id }, facility);
            }

            return facility;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionFacility> PutFacility(Guid id, TransactionFacility facility)
        {
            if (id != facility.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionFacilities.Any(m => m.Id == id))
            {
                _context.Entry(facility).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFacility(Guid id)
        {

            var status = _context.TransactionFacilities.Find(id);
            if (status != null)
            {
                _context.TransactionFacilities.Remove(status);
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
