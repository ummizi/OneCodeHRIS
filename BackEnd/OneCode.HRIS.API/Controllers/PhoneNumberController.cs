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
    public class PhoneNumberController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public PhoneNumberController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionPhoneNumber> GetPhoneNumber()
        {
            using (var context = new EmployeeContext())
            {
                return context.TransactionPhoneNumbers.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionPhoneNumber> GetById(Guid id)
        {
            return _context.TransactionPhoneNumbers.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionPhoneNumber> PostPhoneNumber(TransactionPhoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                phoneNumber.Id = Guid.NewGuid();
                _context.TransactionPhoneNumbers.Add(phoneNumber);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetPhoneNumber), new { id = phoneNumber.Id }, phoneNumber);
            }

            return phoneNumber;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionPhoneNumber> PutPhoneNumber(Guid id, TransactionPhoneNumber phoneNumber)
        {
            if (id != phoneNumber.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionPhoneNumbers.Any(m => m.Id == id))
            {
                _context.Entry(phoneNumber).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePhoneNumber(Guid id)
        {

            var status = _context.TransactionPhoneNumbers.Find(id);
            if (status != null)
            {
                _context.TransactionPhoneNumbers.Remove(status);
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
