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
    public class BankAccountController:ControllerBase
    {
        private readonly EmployeeContext _context;

        public BankAccountController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TransactionBankAccount> GetBankAccount()
        {
            using (var context = new EmployeeContext())
            {
                List<TransactionBankAccount> bankAccounts = context.TransactionBankAccounts.ToList();
                foreach (var rec in bankAccounts)
                {
                    rec.PersonalData = context.TransactionPersonalDatas.Where(x => x.Id == rec.PersonalDataId).FirstOrDefault();
                }
                return bankAccounts;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionBankAccount> GetById(Guid id)
        {
            return _context.TransactionBankAccounts.FirstOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public ActionResult<TransactionBankAccount> PostBankAccount(TransactionBankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                bankAccount.Id = Guid.NewGuid();
                _context.TransactionBankAccounts.Add(bankAccount);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetBankAccount), new { id = bankAccount.Id }, bankAccount);
            }

            return bankAccount;
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionBankAccount> PutBankAccount(Guid id, TransactionBankAccount bankAccount)
        {
            if (id != bankAccount.Id)
            {
                return BadRequest();
            }
            if (_context.TransactionBankAccounts.Any(m => m.Id == id))
            {
                _context.Entry(bankAccount).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBankAccount(Guid id)
        {

            var status = _context.TransactionBankAccounts.Find(id);
            if (status != null)
            {
                _context.TransactionBankAccounts.Remove(status);
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
