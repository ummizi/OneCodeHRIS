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
    [Table("Email", Schema="Transaction")]
    public class Email:BaseEntity
    {
        

        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

        [ForeignKey("ContactType")]
        public Guid ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }

        [ForeignKey("EmailType")]
        public Guid EmailTypeId { get; set; }
        public virtual EmailType EmailType { get; set; }

        public string EmailAddress { get; set; }




    }
}
