using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class MasterContactType
    {
        public MasterContactType()
        {
            TransactionEmails = new HashSet<TransactionEmail>();
            TransactionEmergencyContacts = new HashSet<TransactionEmergencyContact>();
            TransactionPhoneNumbers = new HashSet<TransactionPhoneNumber>();
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual ICollection<TransactionEmail> TransactionEmails { get; set; }
        public virtual ICollection<TransactionEmergencyContact> TransactionEmergencyContacts { get; set; }
        public virtual ICollection<TransactionPhoneNumber> TransactionPhoneNumbers { get; set; }
    }
}
