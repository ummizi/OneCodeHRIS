using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Setup
{
    [Table("Identity", Schema="Master")]
    public class Identity:BaseEntity
    {
        
        public string TableName { get; set; }
    }
}
