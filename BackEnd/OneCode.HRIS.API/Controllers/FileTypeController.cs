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
    public class FileTypeController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public FileTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterFileType> GetFileType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterFileTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterFileType> GetById(Guid id)
        {
            return _context.MasterFileTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterFileType> PostFileType(MasterFileType fileType)
        {
            if (ModelState.IsValid)
            {
                fileType.Id = Guid.NewGuid();
                _context.MasterFileTypes.Add(fileType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetFileType), new { id = fileType.Id }, fileType);
            }

            return fileType;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterFileType> PutFileType(Guid id, MasterFileType fileType)
        {
            if (id != fileType.Id)
            {
                return BadRequest();
            }
            if (_context.MasterFileTypes.Any(m => m.Id == id))
            {
                _context.Entry(fileType).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFileType(Guid id)
        {

            var status = _context.MasterFileTypes.Find(id);
            if (status != null)
            {
                _context.MasterFileTypes.Remove(status);
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
