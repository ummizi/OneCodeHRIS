using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OneCode.HRIS.Models.EmployeeModels
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MasterAddressType> MasterAddressTypes { get; set; }
        public virtual DbSet<MasterBloodType> MasterBloodTypes { get; set; }
        public virtual DbSet<MasterContactType> MasterContactTypes { get; set; }
        public virtual DbSet<MasterDocumentType> MasterDocumentTypes { get; set; }
        public virtual DbSet<MasterEmailType> MasterEmailTypes { get; set; }
        public virtual DbSet<MasterEmployeePosition> MasterEmployeePositions { get; set; }
        public virtual DbSet<MasterEmployementStatus> MasterEmployementStatuses { get; set; }
        public virtual DbSet<MasterFacilityType> MasterFacilityTypes { get; set; }
        public virtual DbSet<MasterFileType> MasterFileTypes { get; set; }
        public virtual DbSet<MasterGenderType> MasterGenderTypes { get; set; }
        public virtual DbSet<MasterIdentity> MasterIdentities { get; set; }
        public virtual DbSet<MasterMaritalStatus> MasterMaritalStatuses { get; set; }
        public virtual DbSet<MasterRelationType> MasterRelationTypes { get; set; }
        public virtual DbSet<MasterSpecialCaseType> MasterSpecialCaseTypes { get; set; }
        public virtual DbSet<MasterTransportationType> MasterTransportationTypes { get; set; }
        public virtual DbSet<MasterUser> MasterUsers { get; set; }
        public virtual DbSet<TransactionAddress> TransactionAddresses { get; set; }
        public virtual DbSet<TransactionBankAccount> TransactionBankAccounts { get; set; }
        public virtual DbSet<TransactionDocument> TransactionDocuments { get; set; }
        public virtual DbSet<TransactionDocumentFile> TransactionDocumentFiles { get; set; }
        public virtual DbSet<TransactionEmail> TransactionEmails { get; set; }
        public virtual DbSet<TransactionEmergencyContact> TransactionEmergencyContacts { get; set; }
        public virtual DbSet<TransactionFacility> TransactionFacilities { get; set; }
        public virtual DbSet<TransactionFamilyData> TransactionFamilyDatas { get; set; }
        public virtual DbSet<TransactionPersonalData> TransactionPersonalDatas { get; set; }
        public virtual DbSet<TransactionPhoneNumber> TransactionPhoneNumbers { get; set; }
        public virtual DbSet<TransactionSpecialCase> TransactionSpecialCases { get; set; }
        public virtual DbSet<TransactionTransportation> TransactionTransportations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-CK1QGGA6;Database=Employee;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MasterAddressType>(entity =>
            {
                entity.ToTable("Master.AddressType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterBloodType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master.BloodType");

                entity.Property(e => e.BloodName).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterContactType>(entity =>
            {
                entity.ToTable("Master.ContactType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterDocumentType>(entity =>
            {
                entity.ToTable("Master.DocumentType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterEmailType>(entity =>
            {
                entity.ToTable("Master.EmailType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterEmployeePosition>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master.EmployeePosition");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.PositionName).HasMaxLength(100);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterEmployementStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master.EmployementStatus");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.StatusName).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterFacilityType>(entity =>
            {
                entity.ToTable("Master.FacilityType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterFileType>(entity =>
            {
                entity.ToTable("Master.FileType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(25);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterGenderType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master.GenderType");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterIdentity>(entity =>
            {
                entity.ToTable("Master.Identity");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterMaritalStatus>(entity =>
            {
                entity.ToTable("Master.MaritalStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterRelationType>(entity =>
            {
                entity.ToTable("Master.RelationType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterSpecialCaseType>(entity =>
            {
                entity.ToTable("Master.SpecialCaseType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterTransportationType>(entity =>
            {
                entity.ToTable("Master.TransportationType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<MasterUser>(entity =>
            {
                entity.ToTable("Master.User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UserGroupId).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<TransactionAddress>(entity =>
            {
                entity.ToTable("Transaction.Address");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Building).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Kecamatan).HasMaxLength(25);

                entity.Property(e => e.Kelurahan).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(7);

                entity.Property(e => e.Rtrw)
                    .HasMaxLength(10)
                    .HasColumnName("RTRW");

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.StreetAddress).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.TransactionAddresses)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Address_Transaction.Address");

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionAddresses)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Address_Transaction.PersonalData");
            });

            modelBuilder.Entity<TransactionBankAccount>(entity =>
            {
                entity.ToTable("Transaction.BankAccount");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionBankAccounts)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.BankAccount_Transaction.BankAccount");
            });

            modelBuilder.Entity<TransactionDocument>(entity =>
            {
                entity.ToTable("Transaction.Document");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.SerialNumber).HasMaxLength(25);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.TransactionDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Document_Master.DocumentType");

                entity.HasOne(d => d.Identity)
                    .WithMany(p => p.TransactionDocuments)
                    .HasForeignKey(d => d.IdentityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Document_Master.Identity");

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionDocuments)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Document_Transaction.PersonalData");
            });

            modelBuilder.Entity<TransactionDocumentFile>(entity =>
            {
                entity.ToTable("Transaction.DocumentFile");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DocFile).HasMaxLength(500);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.TransactionDocumentFiles)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.DocumentFile_Transaction.Document");

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.TransactionDocumentFiles)
                    .HasForeignKey(d => d.FileTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.DocumentFile_Master.FileType");

                entity.HasOne(d => d.Identity)
                    .WithMany(p => p.TransactionDocumentFiles)
                    .HasForeignKey(d => d.IdentityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.DocumentFile_Master.Identity");
            });

            modelBuilder.Entity<TransactionEmail>(entity =>
            {
                entity.ToTable("Transaction.Email");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.TransactionEmails)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Email_Master.ContactType");

                entity.HasOne(d => d.EmailType)
                    .WithMany(p => p.TransactionEmails)
                    .HasForeignKey(d => d.EmailTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Email_Master.EmailType");

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionEmails)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Email_Transaction.PersonalData");
            });

            modelBuilder.Entity<TransactionEmergencyContact>(entity =>
            {
                entity.ToTable("Transaction.EmergencyContact");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.TransactionEmergencyContacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.EmergencyContact_Master.ContactType");

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionEmergencyContacts)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.EmergencyContact_Transaction.PersonalData");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.TransactionEmergencyContacts)
                    .HasForeignKey(d => d.RelationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.EmergencyContact_Master.RelationType");
            });

            modelBuilder.Entity<TransactionFacility>(entity =>
            {
                entity.ToTable("Transaction.Facility");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.SerialNumber).HasMaxLength(25);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.FacilityType)
                    .WithMany(p => p.TransactionFacilities)
                    .HasForeignKey(d => d.FacilityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Facility_Master.FacilityType");

                entity.HasOne(d => d.Identity)
                    .WithMany(p => p.TransactionFacilities)
                    .HasForeignKey(d => d.IdentityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Facility_Master.Identity");

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionFacilities)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Facility_Transaction.PersonalData");
            });

            modelBuilder.Entity<TransactionFamilyData>(entity =>
            {
                entity.ToTable("Transaction.FamilyData");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionFamilyData)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.FamilyData_Transaction.PersonalData");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.TransactionFamilyData)
                    .HasForeignKey(d => d.RelationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.FamilyData_Master.RelationType");
            });

            modelBuilder.Entity<TransactionPersonalData>(entity =>
            {
                entity.ToTable("Transaction.PersonalData");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.Gender).HasMaxLength(15);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.Nik).HasMaxLength(20);

                entity.Property(e => e.PlaceOfBirth).HasMaxLength(50);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.TransactionPersonalData)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK_Transaction.PersonalData_Master.MaritalStatus");
            });

            modelBuilder.Entity<TransactionPhoneNumber>(entity =>
            {
                entity.ToTable("Transaction.PhoneNumber");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Number).HasMaxLength(25);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.TransactionPhoneNumbers)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.PhoneNumber_Master.ContactType");

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionPhoneNumbers)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.PhoneNumber_Transaction.PersonalData");
            });

            modelBuilder.Entity<TransactionSpecialCase>(entity =>
            {
                entity.ToTable("Transaction.SpecialCase");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.StatusVaksin).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.PersonalData)
                    .WithMany(p => p.TransactionSpecialCases)
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.SpecialCase_Transaction.PersonalData");

                entity.HasOne(d => d.SpecialCaseType)
                    .WithMany(p => p.TransactionSpecialCases)
                    .HasForeignKey(d => d.SpecialCaseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.SpecialCase_Master.SpecialCase");
            });

            modelBuilder.Entity<TransactionTransportation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Transaction.Transportation");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.PlatNumber).HasMaxLength(10);

                entity.Property(e => e.StatusDelete).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Document)
                    .WithMany()
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Transportation_Transaction.Document");

                entity.HasOne(d => d.Identity)
                    .WithMany()
                    .HasForeignKey(d => d.IdentityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Transportation_Master.Identity");

                entity.HasOne(d => d.PersonalData)
                    .WithMany()
                    .HasForeignKey(d => d.PersonalDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Transportation_Transaction.PersonalData");

                entity.HasOne(d => d.TransportationType)
                    .WithMany()
                    .HasForeignKey(d => d.TransportationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction.Transportation_Master.TransportationType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
