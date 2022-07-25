using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class TransactionPhoneNumber
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public Guid PersonalDataId { get; set; }
        public Guid ContactTypeId { get; set; }
        public string Number { get; set; }

        public virtual MasterContactType ContactType { get; set; }
        public virtual TransactionPersonalData PersonalData { get; set; }
    }
}
