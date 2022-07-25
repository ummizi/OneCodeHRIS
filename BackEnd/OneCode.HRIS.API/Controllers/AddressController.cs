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
    public class AddressController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public AddressController(EmployeeContext context)
        {
            _context = context; 
        }
        
        [HttpGet]
        public IEnumerable<TransactionAddress> GetAddress()
        {
            using (var context = new EmployeeContext())
            {
                List<TransactionAddress> addresses = context.TransactionAddresses.ToList();
                foreach (var rec in addresses)
                {
                    rec.AddressType = context.MasterAddressTypes.Where(x => x.Id == rec.AddressTypeId).FirstOrDefault();
                    rec.PersonalData = context.TransactionPersonalDatas.Where(x => x.Id == rec.PersonalDataId).FirstOrDefault();
                }
                return addresses;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionAddress> GetById(Guid id)
        {
            return _context.TransactionAddresses.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionAddress> PostAddress(TransactionAddress address)
        {
            if (ModelState.IsValid)
            {
                address.Id = Guid.NewGuid();
                _context.TransactionAddresses.Add(address);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAddress), new { id = address.Id }, address);
            }

            return address;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionAddress> PutAddress(Guid id, TransactionAddress address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionAddresses.Any(m => m.Id == id))
            {
                _context.Entry(address).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(Guid id)
        {

            var status = _context.TransactionAddresses.Find(id);
            if (status != null)
            {
                _context.TransactionAddresses.Remove(status);
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
