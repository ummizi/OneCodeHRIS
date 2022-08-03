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
using System.IO;
using System.Net.Http.Headers;

namespace OneCode.HRIS.API.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class DocumentFileController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public DocumentFileController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionDocumentFile> GetDocumentFile()
        {
            using (var context = new EmployeeContext())
            {
                List<TransactionDocumentFile> documentFiles = context.TransactionDocumentFiles.ToList();
                foreach (var rec in documentFiles)
                {
                    rec.Document = context.TransactionDocuments.Where(x => x.Id == rec.DocumentId).FirstOrDefault();
                    rec.FileType = context.MasterFileTypes.Where(x => x.Id == rec.FileTypeId).FirstOrDefault();
                    rec.Identity = context.MasterIdentities.Where(x => x.Id == rec.IdentityId).FirstOrDefault();

                }
                return documentFiles;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionDocumentFile> GetById(Guid id)
        {
            return _context.TransactionDocumentFiles.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionDocumentFile> PostDocument(TransactionDocumentFile documentFile)
        {
            if (ModelState.IsValid)
            {
                documentFile.Id = Guid.NewGuid();
                _context.TransactionDocumentFiles.Add(documentFile);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDocumentFile), new { id = documentFile.Id }, documentFile);
            }

            return documentFile;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionDocumentFile> PutDocumentFile(Guid id, TransactionDocumentFile documentFile)
        {
            if (id != documentFile.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionDocumentFiles.Any(m => m.Id == id))
            {
                _context.Entry(documentFile).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDocumentFile(Guid id)
        {

            var status = _context.TransactionDocumentFiles.Find(id);
            if (status != null)
            {
                _context.TransactionDocumentFiles.Remove(status);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPost, DisableRequestSizeLimit]
        //public async Task<IActionResult> Upload()
        //{
        //    try
        //    {
        //        var formCollection = await Request.ReadFormAsync();
        //        var file = formCollection.Files.First();
        //        var folderName = Path.Combine("Resource", "Files");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok();
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal Serve Error: {ex}");
        //    }
        //}
    }
}
