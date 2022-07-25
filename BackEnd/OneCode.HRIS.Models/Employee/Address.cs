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
    [Table("Address", Schema="Transaction")]
    public class Address:BaseEntity
    {
        
        [ForeignKey("PersonalData")]
        public Guid PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }

        [ForeignKey("AddressType")]
        public Guid AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }

        public string StreetAddress { get; set; }
        public string Building { get; set; }
        public string RTRW { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }


    }
}
