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
    public class TransportationTypeController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public TransportationTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterTransportationType> GetTransportationType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterTransportationTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterTransportationType> GetById(Guid id)
        {
            return _context.MasterTransportationTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterTransportationType> PostTransportationType(MasterTransportationType transportationType)
        {
            if (ModelState.IsValid)
            {
                transportationType.Id = Guid.NewGuid();
                _context.MasterTransportationTypes.Add(transportationType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetTransportationType), new { id = transportationType.Id }, transportationType);
            }

            return transportationType;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterTransportationType> PutTransportationType(Guid id, MasterTransportationType transportationType)
        {
            if (id != transportationType.Id)
            {
                return BadRequest();
            }
            if (_context.MasterTransportationTypes.Any(m => m.Id == id))
            {
                _context.Entry(transportationType).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTransportationType(Guid id)
        {

            var status = _context.MasterTransportationTypes.Find(id);
            if (status != null)
            {
                _context.MasterTransportationTypes.Remove(status);
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
