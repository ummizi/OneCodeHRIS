//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using OneCode.HRIS.Models.Employee;
//using OneCode.HRIS.Models.Setup;
//using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
//using OneCode.HRIS.Models.EmployeeModels;

//namespace OneCode.HRIS.API.Controllers
//{
//    [Route("api/[controller]")]
//    [Consumes("application/json")]
//    [ApiController]
//    public class EmployementStatusController : ControllerBase
//    {
//        private readonly EmployeeContext _context;

//        public EmployementStatusController(EmployeeContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public IEnumerable<MasterEmployementStatus> GetEmployementStatus()
//        {
//            using(var context = new EmployeeContext())
//            {
//                return context.MasterEmployementStatus.ToList();
//            }
//        }

//        [HttpGet("{id}")]
//        public ActionResult<MasterEmployementStatus> GetById(Guid id)
//        {
//            return _context.MasterEmployementStatus.FirstOrDefault(m => m.Id == id);
//        }

//        [HttpPost]
//        public ActionResult<MasterEmployementStatus> PostEmployementStatus(MasterEmployementStatus employementStatus)
//        {
//            if(ModelState.IsValid)
//            {
//                employementStatus.Id = Guid.NewGuid();
//                _context.MasterEmployementStatus.Add(employementStatus);
//                _context.SaveChanges();
//                return CreatedAtAction(nameof(GetEmployementStatus), new { id = employementStatus.Id }, employementStatus);
//            }

//            return employementStatus;
//        }
//    }
//}
