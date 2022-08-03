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
    public class DocumentController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public DocumentController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionDocument> GetDocument()
        {
            using (var context = new EmployeeContext())
            {
                List<TransactionDocument> documents = context.TransactionDocuments.ToList();
                foreach (var rec in documents)
                {
                    rec.DocumentType = context.MasterDocumentTypes.Where(x => x.Id == rec.DocumentTypeId).FirstOrDefault();
                    rec.PersonalData = context.TransactionPersonalDatas.Where(x => x.Id == rec.PersonalDataId).FirstOrDefault();
                    rec.Identity = context.MasterIdentities.Where(x => x.Id == rec.IdentityId).FirstOrDefault();

                }
                return documents;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionDocument> GetById(Guid id)
        {
            return _context.TransactionDocuments.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionDocument> PostDocument(TransactionDocument document)
        {
            if (ModelState.IsValid)
            {
                document.Id = Guid.NewGuid();
                _context.TransactionDocuments.Add(document);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
            }

            return document;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionDocument> PutDocument(Guid id, TransactionDocument document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionDocuments.Any(m => m.Id == id))
            {
                _context.Entry(document).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDocument(Guid id)
        {

            var status = _context.TransactionDocuments.Find(id);
            if (status != null)
            {
                _context.TransactionDocuments.Remove(status);
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
