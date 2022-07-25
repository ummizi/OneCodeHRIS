using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Employee
{
    [Table("BankAccount", Schema="Transaction")]
    public class BankAccount:BaseEntity
    {
       

        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }  

        public string AccountNumber { get; set; }



    }
}
