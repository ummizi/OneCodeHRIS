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
    public class EmailController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmailController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionEmail> GetEmail()
        {
            using (var context = new EmployeeContext())
            {
                List<TransactionEmail> emails = context.TransactionEmails.ToList();
                foreach (var rec in emails)
                {
                    rec.ContactType = context.MasterContactTypes.Where(x => x.Id == rec.ContactTypeId).FirstOrDefault();
                    rec.EmailType = context.MasterEmailTypes.Where(x => x.Id == rec.EmailTypeId).FirstOrDefault();
                    rec.PersonalData = context.TransactionPersonalDatas.Where(x => x.Id == rec.PersonalDataId).FirstOrDefault();

                }
                return emails;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionEmail> GetById(Guid id)
        {
            return _context.TransactionEmails.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionEmail> PostEmail(TransactionEmail email)
        {
            if (ModelState.IsValid)
            {
                email.Id = Guid.NewGuid();
                _context.TransactionEmails.Add(email);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetEmail), new { id = email.Id }, email);
            }

            return email;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionEmail> PutEmail(Guid id, TransactionEmail email)
        {
            if (id != email.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionEmails.Any(m => m.Id == id))
            {
                _context.Entry(email).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmail(Guid id)
        {

            var status = _context.TransactionEmails.Find(id);
            if (status != null)
            {
                _context.TransactionEmails.Remove(status);
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
