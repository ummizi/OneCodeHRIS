using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class TransactionDocument
    {
        public TransactionDocument()
        {
            TransactionDocumentFiles = new HashSet<TransactionDocumentFile>();
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public Guid PersonalDataId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid IdentityId { get; set; }
        public string SerialNumber { get; set; }

        public virtual MasterDocumentType DocumentType { get; set; }
        public virtual MasterIdentity Identity { get; set; }
        public virtual TransactionPersonalData PersonalData { get; set; }
        public virtual ICollection<TransactionDocumentFile> TransactionDocumentFiles { get; set; }
    }
}
