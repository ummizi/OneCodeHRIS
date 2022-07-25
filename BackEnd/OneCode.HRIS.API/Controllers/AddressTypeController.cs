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
    public class AddressTypeController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public AddressTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterAddressType> GetAddressType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterAddressTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterAddressType> GetById(Guid id)
        {
            return _context.MasterAddressTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterAddressType> PostAddressType(MasterAddressType addressType)
        {
            if (ModelState.IsValid)
            {
                addressType.Id = Guid.NewGuid();
                _context.MasterAddressTypes.Add(addressType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAddressType), new { id = addressType.Id }, addressType);
            }

            return addressType;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterAddressType> PutAddressType(Guid id, MasterAddressType addressType)
        {
            if (id != addressType.Id)
            {
                return BadRequest();
            }
            if (_context.MasterAddressTypes.Any(m => m.Id == id))
            {
                _context.Entry(addressType).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddressType(Guid id)
        {
            
            var address = _context.MasterAddressTypes.Find(id);
            if (address != null)
            {
                _context.MasterAddressTypes.Remove(address);
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
