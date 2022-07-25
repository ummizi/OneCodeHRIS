using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class MasterAddressType
    {
        public MasterAddressType()
        {
            TransactionAddresses = new HashSet<TransactionAddress>();
        }
        
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual ICollection<TransactionAddress> TransactionAddresses { get; set; }
    }
}
