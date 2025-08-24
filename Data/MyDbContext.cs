using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Temperature_and_Humidity_Collection.Models;

namespace Temperature_and_Humidity_Collection.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DataTable> DataTables { get; set; }

    public virtual DbSet<LoginInformationTable> LoginInformationTables { get; set; }

    public virtual DbSet<OperationLogTable> OperationLogTables { get; set; }

    public virtual DbSet<UserInformationTable> UserInformationTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=喵内;Initial Catalog=Temperature-and-Humidity-Collection;Integrated Security=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataTable>(entity =>
        {
            entity.ToTable("DataTable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datetime).HasColumnName("datetime");
            entity.Property(e => e.Humidity).HasColumnName("humidity");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
        });

        modelBuilder.Entity<LoginInformationTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LoginInformationTable");

            entity.Property(e => e.Datetime).HasColumnName("datetime");
            entity.Property(e => e.ErrorCode).HasColumnName("error_code");
            entity.Property(e => e.LoginOrLogout).HasColumnName("login_or_logout");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Uid).HasColumnName("uid");

            entity.HasOne(d => d.UidNavigation).WithMany()
                .HasForeignKey(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoginInformationTable_UserInformationTable");
        });

        modelBuilder.Entity<OperationLogTable>(entity =>
        {
            entity.ToTable("OperationLogTable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datetime).HasColumnName("datetime");
            entity.Property(e => e.ErrorCode).HasColumnName("error_code");
            entity.Property(e => e.OperationCode).HasColumnName("operation_code");
            entity.Property(e => e.PUid).HasColumnName("p_uid");
            entity.Property(e => e.PUserAccessLevel).HasColumnName("p_user_access_level");
            entity.Property(e => e.PUserAccount)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("p_user_account");
            entity.Property(e => e.PUserName)
                .HasMaxLength(10)
                .HasColumnName("p_user_name");
            entity.Property(e => e.PUserPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("p_user_password");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Uid).HasColumnName("uid");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.OperationLogTables)
                .HasForeignKey(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OperationLogTable_UserInformationTable");
        });

        modelBuilder.Entity<UserInformationTable>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("UserInformationTable");

            entity.HasIndex(e => e.UserAccount, "UN_UserInformationTable_user_account_one").IsUnique();

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.UserAccessLevel).HasColumnName("user_access_level");
            entity.Property(e => e.UserAccount)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_account");
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
