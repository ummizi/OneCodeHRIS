using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Setup
{
    [Table("MaritalStatus", Schema = "Master")]
    public class MaritalStatus : BaseEntity
    {
        
        public string Type { get; set; }
    }
}
