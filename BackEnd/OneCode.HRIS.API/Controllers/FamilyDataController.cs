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
    public class FamilyDataController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public FamilyDataController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionFamilyData> GetFamilyData()
        {
            using (var context = new EmployeeContext())
            {
                return context.TransactionFamilyDatas.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionFamilyData> GetById(Guid id)
        {
            return _context.TransactionFamilyDatas.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionFamilyData> PostFamilyData(TransactionFamilyData familyData)
        {
            if (ModelState.IsValid)
            {
                familyData.Id = Guid.NewGuid();
                _context.TransactionFamilyDatas.Add(familyData);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetFamilyData), new { id = familyData.Id }, familyData);
            }

            return familyData;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionFamilyData> PutFamilyData(Guid id, TransactionFamilyData familyData)
        {
            if (id != familyData.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionFamilyDatas.Any(m => m.Id == id))
            {
                _context.Entry(familyData).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFamilyData(Guid id)
        {

            var status = _context.TransactionFamilyDatas.Find(id);
            if (status != null)
            {
                _context.TransactionFamilyDatas.Remove(status);
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
