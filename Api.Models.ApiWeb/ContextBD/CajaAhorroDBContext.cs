using Api.Models.ApiWeb.Models.CajaAhorro;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.ContextBD
{
    public partial class CajaAhorroDBContext : DbContext
    {

        private String _Constring = String.Empty;


        public CajaAhorroDBContext(DbContextOptions<CajaAhorroDBContext> options, string pConstring)
            : base(options)
        {
            _Constring = pConstring;
        }
        public CajaAhorroDBContext(string pConstring)
        {
            _Constring = pConstring;
        }
        public CajaAhorroDBContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_Constring);
            var lf = new LoggerFactory();
            //lf.AddProvider(new LoggerProvider());
            optionsBuilder.UseLoggerFactory(lf);
            //Personalización para el servicio
        }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Ahorro> Ahorro { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserInfo>(entity =>
            //{
            //    entity.HasNoKey();
            //    entity.ToTable("UserInfo");
            //    entity.Property(e => e.UserId).HasColumnName("UserId");
            //    entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
            //    entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
            //    entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
            //    entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            //    entity.Property(e => e.CreatedDate).IsUnicode(false);
            //});

            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    entity.ToTable("Employee");
            //    entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
            //    entity.Property(e => e.NationalIDNumber).HasMaxLength(15).IsUnicode(false);
            //    entity.Property(e => e.EmployeeName).HasMaxLength(100).IsUnicode(false);
            //    entity.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
            //    entity.Property(e => e.JobTitle).HasMaxLength(50).IsUnicode(false);
            //    entity.Property(e => e.BirthDate).IsUnicode(false);
            //    entity.Property(e => e.MaritalStatus).HasMaxLength(1).IsUnicode(false);
            //    entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false);
            //    entity.Property(e => e.HireDate).IsUnicode(false);
            //    entity.Property(e => e.VacationHours).IsUnicode(false);
            //    entity.Property(e => e.SickLeaveHours).IsUnicode(false);
            //    entity.Property(e => e.RowGuid).HasMaxLength(50).IsUnicode(false);
            //    entity.Property(e => e.ModifiedDate).IsUnicode(false);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
