using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Setup
{
    [Table("FacilityType", Schema = "Master")]
    public class FacilityType:BaseEntity
    {
        
        public string Type { get; set; }
    }
}
