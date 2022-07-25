using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class TransactionAddress
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public Guid PersonalDataId { get; set; }
        public Guid AddressTypeId { get; set; }
        public string StreetAddress { get; set; }
        public string Building { get; set; }
        public string Rtrw { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public virtual MasterAddressType AddressType { get; set; }
        public virtual TransactionPersonalData PersonalData { get; set; }
    }
}
