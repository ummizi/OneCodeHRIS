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
    public class EmergencyContactController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmergencyContactController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionEmergencyContact> GetEmergencyContact()
        {
            using (var context = new EmployeeContext())
            {
                List<TransactionEmergencyContact> emergencyContacts = context.TransactionEmergencyContacts.ToList();
                foreach (var rec in emergencyContacts)
                {
                    rec.ContactType = context.MasterContactTypes.Where(x => x.Id == rec.ContactTypeId).FirstOrDefault();
                    rec.PersonalData = context.TransactionPersonalDatas.Where(x => x.Id == rec.PersonalDataId).FirstOrDefault();
                    rec.Relation = context.MasterRelationTypes.Where(x => x.Id == rec.RelationId).FirstOrDefault();

                }
                return emergencyContacts;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionEmergencyContact> GetById(Guid id)
        {
            return _context.TransactionEmergencyContacts.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionEmergencyContact> PostEmergencyContact(TransactionEmergencyContact emergencyContact)
        {
            if (ModelState.IsValid)
            {
                emergencyContact.Id = Guid.NewGuid();
                _context.TransactionEmergencyContacts.Add(emergencyContact);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetEmergencyContact), new { id = emergencyContact.Id }, emergencyContact);
            }

            return emergencyContact;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionEmergencyContact> PutEmergencyContact(Guid id, TransactionEmergencyContact emergencyContact)
        {
            if (id != emergencyContact.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionEmergencyContacts.Any(m => m.Id == id))
            {
                _context.Entry(emergencyContact).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmergencyContact(Guid id)
        {

            var status = _context.TransactionEmergencyContacts.Find(id);
            if (status != null)
            {
                _context.TransactionEmergencyContacts.Remove(status);
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
