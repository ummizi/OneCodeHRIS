using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Setup
{
    [Table("DocumentType", Schema ="Master")]
    public class DocumentType:BaseEntity
    {
        [Key]
        
        public string Type { get; set; }
    }
}
