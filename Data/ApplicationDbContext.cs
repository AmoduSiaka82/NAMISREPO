using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NAMIS.Models;
using Microsoft.AspNetCore.Identity;

namespace NAMIS.Data
{
    // public class ApplicationDbContext : IdentityDbContext<useraccount, AppRoles, string>
    public class ApplicationDbContext : IdentityDbContext<useraccount>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<useraccount>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(200));
           modelBuilder.Entity<useraccount>(entity => entity.Property(m => m.Id).HasMaxLength(200));
            modelBuilder.Entity<useraccount>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(200));


            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(200));
            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(200));


            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
           modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(200));
           modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(200));
            

            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));


            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(200));

            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));
        }
        public DbSet<nextofkin> nextofkin { get; set; }
        public DbSet<NAMIS.Models.biodata> biodata { get; set; }
        public DbSet<NAMIS.Models.bydeaths> bydeaths { get; set; }
        public DbSet<NAMIS.Models.byresignationorinvalidating> byresignationorinvalidating { get; set; }
        public DbSet<NAMIS.Models.bytransfers> bytransfers { get; set; }
        public DbSet<NAMIS.Models.dpps> dpps { get; set; }
        public DbSet<NAMIS.Models.dsinforce> dsinforce { get; set; }
        public DbSet<NAMIS.Models.educations> educations { get; set; }
        public DbSet<NAMIS.Models.marragehistory> marragehistory { get; set; }
        public DbSet<NAMIS.Models.languages> languages { get; set; }
        public DbSet<NAMIS.Models.particularofchildren> particularofchildren { get; set; }
        public DbSet<NAMIS.Models.dpq> dpq { get; set; }
        public DbSet<NAMIS.Models.schoolcertificatehelds> schoolcertificatehelds { get; set; }
        public DbSet<NAMIS.Models.tourandleaverecord> tourandleaverecord { get; set; }
        public DbSet<NAMIS.Models.recordofsickleaves> recordofsickleaves { get; set; }
        public DbSet<NAMIS.Models.rofcandcs> rofcandcs { get; set; }
        public DbSet<NAMIS.Models.rofgpm> rofgpm { get; set; }
        public DbSet<NAMIS.Models.recordofservice> recordofservice { get; set; }
        public DbSet<NAMIS.Models.recordofemolument> recordofemolument { get; set; }
        public DbSet<NAMIS.Models.totalpreviousservice> totalpreviousservice { get; set; }
        public DbSet<NAMIS.Models.CountryMaster> CountryMaster { get; set; }
        public DbSet<NAMIS.Models.useraccount> useraccount { get; set; }
        public DbSet<NAMIS.Models.department> department { get; set; }
        public DbSet<NAMIS.Models.station> station { get; set; }
        public DbSet<NAMIS.Models.states> states { get; set; }
        public DbSet<NAMIS.Models.locals> locals { get; set; }
        public DbSet<NAMIS.Models.designation> designation { get; set; }
        public DbSet<NAMIS.Models.register> register { get; set; }
        public DbSet<NAMIS.Models.unit> unit { get; set; }
        public DbSet<NAMIS.Models.scheduled> scheduled { get; set; }
        public DbSet<NAMIS.Models.createschedule> createschedule { get; set; }
        public DbSet<NAMIS.Models.biodataViewModel> biodataViewModel { get; set; }
        public DbSet<NAMIS.Models.sections> sections { get; set; }
        public DbSet<NAMIS.Models.Box> Box { get; set; }
        public DbSet<NAMIS.Models.CareerProgression> CareerProgression { get; set; }
        public DbSet<NAMIS.Models.TopMenus> TopMenus { get; set; }
        public DbSet<NAMIS.Models.LoadUserPage> LoadUserPage { get; set; }
        public DbSet<NAMIS.Models.Leaves> Leaves { get; set; }
        public DbSet<NAMIS.Models.Confirmationofappointment> Confirmationofappointment { get; set; }
        public DbSet<NAMIS.Models.StaffPosting> StaffPosting { get; set; }
        public DbSet<NAMIS.Models.monthlyreturn> monthlyreturn { get; set; }
        public DbSet<NAMIS.Models.retirementbiodata> retirementbiodata { get; set; }
        public DbSet<NAMIS.Models.FileDestination> FileDestination { get; set; }
        public DbSet<NAMIS.Models.PersonelFile> PersonelFile { get; set; }
        public DbSet<NAMIS.Models.TrainingAndStudy> TrainingAndStudy { get; set; }
        public DbSet<NAMIS.Models.itstudent> itstudent { get; set; }
        public DbSet<NAMIS.Models.reportwriting> reportwriting { get; set; }

        public DbSet<NAMIS.Models.reportupload> reportupload { get; set; }

        public DbSet<NAMIS.ViewModels.reportUploadModel> reportUploadModel { get; set; }

        public DbSet<NAMIS.Models.Memo> Memo { get; set; }

        public DbSet<NAMIS.Models.signatures> signatures { get; set; }

        public DbSet<NAMIS.Models.Visitor> Visitor { get; set; }

        public DbSet<NAMIS.Models.VehicleRecord> VehicleRecord { get; set; }

        public DbSet<NAMIS.Models.DailyMotorVehicleWorkBook> DailyMotorVehicleWorkBook { get; set; }
        public DbSet<NAMIS.Models.MinuteRegister> MinuteRegister { get; set; }
        public DbSet<NAMIS.Models.MinuteOfMeeting> MinuteOfMeeting { get; set; }
        public DbSet<NAMIS.Models.Directive> Directives { get; set; }
        public DbSet<NAMIS.Models.Refrence> Refrences { get; set; }
        public DbSet<NAMIS.Models.Qualification> Qualifications { get; set; }
        public DbSet<NAMIS.Models.VariationAdvice> VariationAdvices { get; set; }
        public DbSet<NAMIS.Models.Disposition> Dispositions { get; set; }

    }
}
