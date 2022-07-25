using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class TransactionTransportation
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public Guid PersonalDataId { get; set; }
        public Guid TransportationTypeId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid IdentityId { get; set; }
        public string PlatNumber { get; set; }

        public virtual TransactionDocument Document { get; set; }
        public virtual MasterIdentity Identity { get; set; }
        public virtual TransactionPersonalData PersonalData { get; set; }
        public virtual MasterTransportationType TransportationType { get; set; }
    }
}
