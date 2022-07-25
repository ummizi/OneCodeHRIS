using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneCode.HRIS.Models.Setup;

namespace OneCode.HRIS.Models.Employee
{
    [Table("Document", Schema="Transaction")]
    public class Document:BaseEntity
    {
       
        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

        [ForeignKey("DocumentType")]
        public Guid DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }

        [ForeignKey("Identity")]
        public Guid IdentityId { get; set; }
        public virtual Identity Identity { get; set; }

        public string SerialNumber { get; set; }

    }
}
