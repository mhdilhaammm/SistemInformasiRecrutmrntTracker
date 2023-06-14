using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Recruitment_Tracker.data;

public partial class DbrecruitmentContext : DbContext
{
    public DbrecruitmentContext()
    {
    }
    public DbrecruitmentContext(DbContextOptions<DbrecruitmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DataCalonKaryawan> DataCalonKaryawans { get; set; }

    public virtual DbSet<DataPelamar> DataPelamars { get; set; }

    public virtual DbSet<Pengumuman> Pengumumen { get; set; }

    public virtual DbSet<User> Users { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IAM;Database=DBRecruitment;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataCalonKaryawan>(entity =>
        {
            entity.HasKey(e => e.IdCalonKaryawan);

            entity.ToTable("DataCalonKaryawan");

            entity.Property(e => e.IdCalonKaryawan).HasColumnName("id_calonKaryawan");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nama)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DataPelamar>(entity =>
        {
            entity.ToTable("DataPelamar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Agama)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Alamat)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdCalonKaryawan).HasColumnName("id_calonKaryawan");
            entity.Property(e => e.IdPengumuman).HasColumnName("id_pengumuman");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Jurusan)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nama)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NamaPerguruan)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nik)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NIK");
            entity.Property(e => e.Pendidikan)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TahunLulus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TanggalLahir).HasColumnType("datetime");
            entity.Property(e => e.TempatLahir)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCalonKaryawanNavigation).WithMany(p => p.DataPelamars)
                .HasForeignKey(d => d.IdCalonKaryawan)
                .HasConstraintName("FK_DataPelamar_DataCalonKaryawan");

            entity.HasOne(d => d.IdPengumumanNavigation).WithMany(p => p.DataPelamars)
                .HasForeignKey(d => d.IdPengumuman)
                .HasConstraintName("FK_DataPelamar_Pengumuman");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.DataPelamars)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_DataPelamar_User");
        });

        modelBuilder.Entity<Pengumuman>(entity =>
        {
            entity.HasKey(e => e.IdPengumuman);

            entity.ToTable("Pengumuman");

            entity.Property(e => e.IdPengumuman).HasColumnName("id_pengumuman");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nama)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nama).HasMaxLength(50);
            entity.Property(e => e.NamaUser)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Rolle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("rolle");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
