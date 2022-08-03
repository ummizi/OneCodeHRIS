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
    public class DocumentTypeController:ControllerBase

    {
        private readonly EmployeeContext _context;

        public DocumentTypeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MasterDocumentType> GetDocumentType()
        {
            using (var context = new EmployeeContext())
            {
                return context.MasterDocumentTypes.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MasterDocumentType> GetById(Guid id)
        {
            return _context.MasterDocumentTypes.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<MasterDocumentType> PostDocumentType(MasterDocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                documentType.Id = Guid.NewGuid();
                _context.MasterDocumentTypes.Add(documentType);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDocumentType), new { id = documentType.Id }, documentType);
            }

            return documentType;
        }

        [HttpPut("{id}")]
        public ActionResult<MasterDocumentType> PutDocumentype(Guid id, MasterDocumentType documentType)
        {
            if (id != documentType.Id)
            {
                return BadRequest();
            }
            if (_context.MasterDocumentTypes.Any(m => m.Id == id))
            {
                _context.Entry(documentType).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDocumentType(Guid id)
        {

            var status = _context.MasterDocumentTypes.Find(id);
            if (status != null)
            {
                _context.MasterDocumentTypes.Remove(status);
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
