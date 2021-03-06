// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Repository
{
    public partial class AksaContext : DbContext
    {
        public AksaContext()
        {
        }

        public AksaContext(DbContextOptions<AksaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ParamGen> ParamGen { get; set; }
        public virtual DbSet<ParamGenList> ParamGenList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParamGen>(entity =>
            {
                entity.ToTable("PARAM_GEN");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_PARAM_GEN")
                    .IsUnique();

                entity.HasIndex(e => new { e.ParameterId, e.Value, e.Isactive })
                    .HasName("IX_PARAM_GEN_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.ParamGen)
                    .HasForeignKey(d => d.ParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAM_GEN_PARAM_GEN_LIST");
            });

            modelBuilder.Entity<ParamGenList>(entity =>
            {
                entity.ToTable("PARAM_GEN_LIST");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_PARAM_GEN_LIST")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}