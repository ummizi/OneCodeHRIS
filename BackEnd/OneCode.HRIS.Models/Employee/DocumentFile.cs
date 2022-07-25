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
    [Table("DocumentFile", Schema="Transaction")]
    public class DocumentFile:BaseEntity
    {
        
        [ForeignKey("Document")]
        public Guid DocumentId { get; set; }
        public virtual Document Document { get; set; }

        [ForeignKey("FileType")]
        public Guid FileTypeId  { get; set; }
        public virtual FileType FileType { get; set; }

        [ForeignKey("Identity")]
        public Guid IdentityId { get; set; }
        public virtual Identity Identity { get; set; }
        
        public string DocFile { get; set; }



    }
}
