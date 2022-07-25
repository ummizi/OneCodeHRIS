using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class MasterIdentity
    {
        public MasterIdentity()
        {
            TransactionDocumentFiles = new HashSet<TransactionDocumentFile>();
            TransactionDocuments = new HashSet<TransactionDocument>();
            TransactionFacilities = new HashSet<TransactionFacility>();
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public string TableName { get; set; }

        public virtual ICollection<TransactionDocumentFile> TransactionDocumentFiles { get; set; }
        public virtual ICollection<TransactionDocument> TransactionDocuments { get; set; }
        public virtual ICollection<TransactionFacility> TransactionFacilities { get; set; }
    }
}
