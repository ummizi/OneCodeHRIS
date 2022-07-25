using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class TransactionEmail
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public Guid PersonalDataId { get; set; }
        public Guid ContactTypeId { get; set; }
        public Guid EmailTypeId { get; set; }
        public string EmailAddress { get; set; }

        public virtual MasterContactType ContactType { get; set; }
        public virtual MasterEmailType EmailType { get; set; }
        public virtual TransactionPersonalData PersonalData { get; set; }
    }
}
