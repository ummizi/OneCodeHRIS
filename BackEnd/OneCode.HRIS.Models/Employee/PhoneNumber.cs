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
    [Table("PhoneNumber", Schema="Transaction")]
    public class PhoneNumber:BaseEntity
    {
               
        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

        [ForeignKey("ContactTypeId")]
        public Guid ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }

        public string Number { get; set; }








    }
}
