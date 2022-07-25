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
    [Table("SpecialCase", Schema="Transaction")]
    public class SpecialCase:BaseEntity
    {
        
        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

        [ForeignKey("SpecialCaseType")]
        public Guid SpecialCaseId { get; set; }
        public virtual SpecialCaseType SpecialCaseType { get; set; }

        public string StatusVaksin { get; set; }
    }
}
