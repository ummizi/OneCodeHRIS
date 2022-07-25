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
    [Table("FamilyData", Schema="Transaction")]
    public class FamilyData:BaseEntity
    {
        

        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

        [ForeignKey("Relation")]
        public Guid RelationId { get; set; }
        public virtual RelationType Relation { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}
