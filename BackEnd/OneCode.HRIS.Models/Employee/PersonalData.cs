using OneCode.HRIS.Models.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Employee
{
    [Table("PersonalData", Schema = "Transaction")]
    public class PersonalData:BaseEntity
    {
        
        [ForeignKey("MaritalStatus")]
        public Guid MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public string Nik { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string JoinDate { get; set; }

    }
}
