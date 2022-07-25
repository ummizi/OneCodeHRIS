using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCode.HRIS.Models.Setup
{
    [Table("TransportationType", Schema="Master")]
    public class TransportationType : BaseEntity
    {
        
        public string Type { get; set; }
    }
}
