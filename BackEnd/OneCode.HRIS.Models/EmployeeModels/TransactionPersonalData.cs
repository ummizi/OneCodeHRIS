using System;
using System.Collections.Generic;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class TransactionPersonalData
    {
        public TransactionPersonalData()
        {
            TransactionAddresses = new HashSet<TransactionAddress>();
            TransactionBankAccounts = new HashSet<TransactionBankAccount>();
            TransactionDocuments = new HashSet<TransactionDocument>();
            TransactionEmails = new HashSet<TransactionEmail>();
            TransactionEmergencyContacts = new HashSet<TransactionEmergencyContact>();
            TransactionFacilities = new HashSet<TransactionFacility>();
            TransactionFamilyData = new HashSet<TransactionFamilyData>();
            TransactionPhoneNumbers = new HashSet<TransactionPhoneNumber>();
            TransactionSpecialCases = new HashSet<TransactionSpecialCase>();
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string StatusDelete { get; set; }
        public string Description { get; set; }
        public Guid? MaritalStatusId { get; set; }
        public string Nik { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime? JoinDate { get; set; }

        public virtual MasterMaritalStatus MaritalStatus { get; set; }
        public virtual ICollection<TransactionAddress> TransactionAddresses { get; set; }
        public virtual ICollection<TransactionBankAccount> TransactionBankAccounts { get; set; }
        public virtual ICollection<TransactionDocument> TransactionDocuments { get; set; }
        public virtual ICollection<TransactionEmail> TransactionEmails { get; set; }
        public virtual ICollection<TransactionEmergencyContact> TransactionEmergencyContacts { get; set; }
        public virtual ICollection<TransactionFacility> TransactionFacilities { get; set; }
        public virtual ICollection<TransactionFamilyData> TransactionFamilyData { get; set; }
        public virtual ICollection<TransactionPhoneNumber> TransactionPhoneNumbers { get; set; }
        public virtual ICollection<TransactionSpecialCase> TransactionSpecialCases { get; set; }
    }
}
