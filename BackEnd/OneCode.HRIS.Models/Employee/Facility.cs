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
    [Table("Facility", Schema="Transaction")]
    public class Facility:BaseEntity
    {
        

        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

        [ForeignKey("FacilityType")]
        public Guid FacilityTypeId { get; set; }
        public virtual FacilityType FacilityType { get; set; }

        [ForeignKey("Identity")]
        public Guid IdentityId { get; set; }
        public virtual Identity Identity { get; set; }

        public string SerialNumber { get; set; }



    }
}
