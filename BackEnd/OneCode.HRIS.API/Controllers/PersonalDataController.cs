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
    public class PersonalDataController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public PersonalDataController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionPersonalData> GetPersonalData()
        {
            using (var context = new EmployeeContext())
            {
                List<TransactionPersonalData> personalDatas = context.TransactionPersonalDatas.ToList();
                foreach(var rec in personalDatas)
                {
                    rec.MaritalStatus = context.MasterMaritalStatuses.Where(x => x.Id == rec.MaritalStatusId).FirstOrDefault();
                }
                return personalDatas;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionPersonalData> GetById(Guid id)
        {
            return _context.TransactionPersonalDatas.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionPersonalData> PostPersonalData(TransactionPersonalData personalData)
        {
            if (ModelState.IsValid)
            {
                personalData.Id = Guid.NewGuid();
                _context.TransactionPersonalDatas.Add(personalData);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetPersonalData), new { id = personalData.Id }, personalData);
            }

            return personalData;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionPersonalData> PutPersonalData(Guid id, TransactionPersonalData personalData)
        {
            if (id != personalData.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionPersonalDatas.Any(m => m.Id == id))
            {
                _context.Entry(personalData).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePersonalData(Guid id)
        {

            var status = _context.TransactionPersonalDatas.Find(id);
            if (status != null)
            {
                _context.TransactionPersonalDatas.Remove(status);
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
