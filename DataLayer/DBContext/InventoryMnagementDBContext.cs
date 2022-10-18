using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;

namespace DataLayer
{
    public class InventoryMnagementDBContext : DbContext
    {
        public InventoryMnagementDBContext(DbContextOptions<InventoryMnagementDBContext> options) : base(options)
        { }


        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<CustomerMaster> CustomerMaster { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<ProductInformation> ProductInformation { get; set; }
        public DbSet<StoreInfo> StoreInfo { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<ProductCustomerUnitPrice> ProductCustomerUnitPrice { get; set; }
        public DbSet<ProductSupplierUnitPrice> ProductSupplierUnitPrice { get; set; }
        public DbSet<StoreProduct> StoreProduct { get; set; }
        public DbSet<RunLevel> RunLevel { get; set; }
        public DbSet<OrderTemplate> OrderTemplate { get; set; }
        public DbSet<OrderTemplateProducts> OrderTemplateProducts { get; set; }
        public DbSet<Excemptions> Excemptions { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryCustomer> CategoryCustomer { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }
        public DbSet<CategoryStore> CategoryStore { get; set; }
        public DbSet<StoreGroupDriverMapping> StoreGroupDriverMapping { get; set; }
        public DbSet<StoreGroupStoreMapping> StoreGroupStoreMapping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName, e.Email, e.MobileNumber, e.ContactTypeId }).IsUnique();
            });
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
            });
            modelBuilder.Entity<ProductInformation>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });
            modelBuilder.Entity<CategoryCustomer>(entity =>
            {
                entity.HasIndex(e => new { e.CategoryId, e.CustomerMasterId }).IsUnique();
            });
            //modelBuilder.Entity<StoreDriverMapping>(entity =>
            //{
            //    entity.HasIndex(e => new { e.StoreId, e.DriverId }).IsUnique();
            //});
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasIndex(e => new { e.CategoryId, e.ProductId }).IsUnique();
            });
            modelBuilder.Entity<CategoryStore>(entity =>
            {
                entity.HasIndex(e => new { e.CategoryId, e.StoreId }).IsUnique();
            });

            modelBuilder.Entity<OrderTemplateProducts>(entity =>
            {
                entity.HasIndex(e => new { e.OrderTemplateId, e.ProductId, e.StoreId, e.SupplierId }).IsUnique();
            });
            modelBuilder.Entity<OrderProducts>(entity =>
            {
                entity.HasIndex(e => new { e.OrderId, e.TemplateId, e.ProductId, e.StoreId, e.SupplierId }).IsUnique();
            });
            modelBuilder.Entity<ProductSupplierUnitPrice>(entity =>
            {
                entity.HasIndex(e => new { e.SupplierId, e.ProductId, e.EffectiveFromDate, e.EffectiveTillDate }).IsUnique();
            });
            modelBuilder.Entity<RunLevel>(entity =>
            {
                entity.HasIndex(e => new { e.DriverId, e.OrderProductId }).IsUnique();
            });
            modelBuilder.Entity<StoreGroupDriverMapping>(entity =>
            {
                entity.HasIndex(e => e.GroupeName).IsUnique();
            });
            modelBuilder.Entity<StoreGroupStoreMapping>(entity =>
            {
                entity.HasIndex(e => new { e.StoreGroupId, e.StoreId }).IsUnique();
            });
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ID = 1,
                Email = "admin.inventoryManagement@gmail.com",
                FirstName = "Admin",
                LastName = "Admin",
                ContactTypeId = 4,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                IsActive = true,
                LocationId = 1,
                MobileNumber = "0000000000"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ID = 2,
                Email = "",
                FirstName = "No Contact",
                LastName = "",
                ContactTypeId = 1,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                IsActive = true,
                LocationId = 1,
                MobileNumber = "0000000000"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ID = 3,
                Email = "",
                FirstName = "No Contact",
                LastName = "",
                ContactTypeId = 2,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                IsActive = true,
                LocationId = 1,
                MobileNumber = "0000000000"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ID = 4,
                Email = "",
                FirstName = "No Contact",
                LastName = "",
                ContactTypeId = 3,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                IsActive = true,
                LocationId = 1,
                MobileNumber = "0000000000"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ID = 5,
                Email = "",
                FirstName = "No Contact",
                LastName = "",
                ContactTypeId = 5,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                IsActive = true,
                LocationId = 1,
                MobileNumber = "0000000000"
            });
            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo()
                {
                    ID = 1,
                    UserName = "admin.inventoryManagement@gmail.com",
                    Password = "inventoryManagementps",
                    ContactId = 1,
                    CreatedBy = 0,
                    IsLoginEnabled = true,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
            modelBuilder.Entity<ContactType>().HasData(
                new ContactType() { ID = 1, Name = "Supplier", CreatedBy = 1, CreatedDate = DateTime.Now, IsActive = true },
                new ContactType() { ID = 2, Name = "Customer", CreatedBy = 1, CreatedDate = DateTime.Now, IsActive = true },
                new ContactType() { ID = 3, Name = "Driver", CreatedBy = 1, CreatedDate = DateTime.Now, IsActive = true },
                new ContactType() { ID = 4, Name = "Admin", CreatedBy = 1, CreatedDate = DateTime.Now, IsActive = true },
                 new ContactType() { ID = 5, Name = "Store", CreatedBy = 1, CreatedDate = DateTime.Now, IsActive = true }
                );

            modelBuilder.Entity<CustomerType>().HasData(
                new CustomerType() { ID = 1, Name = "Individual", CreatedBy = 1, CreatedDate = DateTime.Now, IsActive = true },
                new CustomerType() { ID = 2, Name = "SuperMarket", CreatedBy = 1, CreatedDate = DateTime.Now, IsActive = true },
                new CustomerType() { ID = 3, Name = "CafeChain", CreatedBy = 1, CreatedDate = DateTime.Now, IsActive = true });

            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    ID = 1,
                    Latitude = "Default",
                    Longitude = "default",
                    AddressLine1 = "Default",
                    AddressLine2 = "Default",
                    State = "NSW",
                    Suburb = "Default",
                    PostalCode = "000000",
                    CreatedBy = 0,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //SET CUSTOM DEFAULT VALUE ON CREATION
        //    //MODIFIED DATE: 
        //    DateTime modifiedDate = new DateTime(1900, 1, 1);

        //    #region Applicant
        //    modelBuilder.Entity<Applicant>().ToTable("applicant");
        //    //Primary Key & Identity Column
        //    modelBuilder.Entity<Applicant>().HasKey(ap => ap.Applicant_ID);
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("applicant_id");
        //    //COLUMN SETTINGS
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_Name).IsRequired(true).HasMaxLength(100).HasColumnName("applicant_name");
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_Surname).IsRequired(true).HasMaxLength(100).HasColumnName("applicant_surname");
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_BirthDate).IsRequired(true).HasColumnName("applicant_birthdate");
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Contact_Email).IsRequired(false).HasMaxLength(250).HasColumnName("contact_email");//(no Applicant_)Will be guardians/parents Email
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Contact_Number).IsRequired(true).HasMaxLength(25).HasColumnName("contact_number");//(no Applicant_)Might not be the applicants email, could be guardians/parents
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("applicant_creationdate");
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("applicant_modifieddate");
        //    //RelationShips
        //    modelBuilder.Entity<Applicant>()
        //           .HasMany<Application>(app => app.Applications)
        //           .WithOne(ap => ap.Applicant)
        //           .HasForeignKey(app => app.Applicant_ID)
        //           .OnDelete(DeleteBehavior.Restrict);//Can't delete an applicants info Ever, We can update it though.
        //    #endregion

        //    #region Application Status
        //    modelBuilder.Entity<ApplicationStatus>().ToTable("application_status");
        //    //Primary Key & Identity Column
        //    modelBuilder.Entity<ApplicationStatus>().HasKey(apps => apps.ApplicationStatus_ID);
        //    modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.ApplicationStatus_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("application_status_id");
        //    //COLUMN SETTINGS
        //    modelBuilder.Entity<ApplicationStatus>().HasIndex(apps => apps.ApplicationStatus_Name).IsUnique(); // Application Status Name is Unique
        //    modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.ApplicationStatus_Name).IsRequired(true).HasMaxLength(100).HasColumnName("application_status_name");
        //    modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.ApplicationStatus_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("application_status_creationdate");
        //    modelBuilder.Entity<ApplicationStatus>().Property(ap => ap.ApplicationtStatus_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("application_status_modifieddate");

        //    //RelationShips
        //    modelBuilder.Entity<ApplicationStatus>()
        //           .HasMany<Application>(app => app.Applications)
        //           .WithOne(apps => apps.ApplicationStatus)
        //           .HasForeignKey(app => app.ApplicationStatus_ID)
        //           .OnDelete(DeleteBehavior.Restrict);//Can't delete an ApplicationStatus, We can update it though.
        //    #endregion

        //    #region Grade
        //    modelBuilder.Entity<Grade>().ToTable("grade");
        //    //Primary Key & Identity Column
        //    modelBuilder.Entity<Grade>().HasKey(g => g.Grade_ID);
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("grade_id");
        //    //COLUMN SETTINGS
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_Name).IsRequired(true).HasMaxLength(100).HasColumnName("grade_name");
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_Number).IsRequired(true).HasColumnName("grade_number");
        //    modelBuilder.Entity<Grade>().HasIndex(g => g.Grade_Name).IsUnique(); // Grade Name is Unique
        //    modelBuilder.Entity<Grade>().HasIndex(g => g.Grade_Number).IsUnique(); // Grade Number is Unique
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_Capacity).IsRequired(true).HasColumnName("grade_capacity");
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("grade_creationdate");
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("grade_modifieddate");

        //    //RelationShips
        //    modelBuilder.Entity<Grade>()
        //           .HasMany<Application>(g => g.Applications)
        //           .WithOne(app => app.Grade)
        //           .HasForeignKey(app => app.Grade_ID)
        //           .OnDelete(DeleteBehavior.Restrict);//Can't delete a Grade Ever, We can update it though.
        //    #endregion

        //    #region Application
        //    modelBuilder.Entity<Application>().ToTable("application");
        //    //Primary Key & Identity Column
        //    modelBuilder.Entity<Application>().HasKey(app => app.Application_ID);
        //    modelBuilder.Entity<Application>().Property(app => app.Application_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("application_id");
        //    //COLUMN SETTINGS
        //    modelBuilder.Entity<Application>().Property(app => app.Applicant_ID).IsRequired(true).HasColumnName("applicant_id");
        //    modelBuilder.Entity<Application>().Property(app => app.Grade_ID).IsRequired(true).HasColumnName("grade_id");
        //    modelBuilder.Entity<Application>().Property(app => app.ApplicationStatus_ID).IsRequired(true).HasColumnName("application_status_id");
        //    modelBuilder.Entity<Application>().Property(app => app.Application_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("application_creationdate");
        //    modelBuilder.Entity<Application>().Property(app => app.Application_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("application_modifieddate");
        //    modelBuilder.Entity<Application>().Property(app => app.SchoolYear).IsRequired(true).HasColumnName("application_schoolyear");
        //    //Relationships

        //    //Applicant link
        //    modelBuilder.Entity<Application>()
        //         .HasOne<Applicant>(app => app.Applicant)
        //         .WithMany(ap => ap.Applications)//CAN HAVE MANY APPLICATIONS
        //         .HasForeignKey(app => app.Applicant_ID)
        //         .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

        //    //Grade link
        //    modelBuilder.Entity<Application>()
        //         .HasOne<Grade>(app => app.Grade)
        //         .WithMany(ap => ap.Applications)//Grade is linked to many applications
        //         .HasForeignKey(app => app.Grade_ID)
        //         .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

        //    //Status link
        //    modelBuilder.Entity<Application>()
        //        .HasOne<ApplicationStatus>(app => app.ApplicationStatus)
        //        .WithMany(ap => ap.Applications)//Status is linked to many applications
        //        .HasForeignKey(app => app.ApplicationStatus_ID)
        //        .OnDelete(DeleteBehavior.NoAction);//Can delete an application.
        //    #endregion
        //}
    }
}

