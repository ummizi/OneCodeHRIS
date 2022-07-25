using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class TransactionFamilyData
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public Guid PersonalDataId { get; set; }
        public Guid RelationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual TransactionPersonalData PersonalData { get; set; }
        public virtual MasterRelationType Relation { get; set; }
    }
}
