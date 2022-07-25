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
    [Table("Transportation", Schema="Transaction")]
    public class Transportation:BaseEntity
    {
        

        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

        [ForeignKey("TransportationType")]
        public Guid TransportationTypeId { get; set; }
        public virtual TransportationType  TransportationType { get; set; }

        [ForeignKey("Document")]
        public Guid DocumentId { get; set; }
        public virtual Document Document { get; set; }

        [ForeignKey("Identity")]
        public Guid IdentityId { get; set; }
        public virtual Identity Identity { get; set; }

        public string PlatNumber { get; set; }
    }
}
