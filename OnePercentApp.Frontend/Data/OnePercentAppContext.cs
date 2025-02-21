using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnePercentApp.Frontend.Data;

public partial class OnePercentAppContext : DbContext
{
    public OnePercentAppContext()
    {
    }

    public OnePercentAppContext(DbContextOptions<OnePercentAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVAN-PERSONAL\\SQLEXPRESS;Database=OnePercentApp;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B464D3B1B2");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryDescription).HasColumnName("category_description");
            entity.Property(e => e.CategoryTitle)
                .HasMaxLength(50)
                .HasColumnName("category_title");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__log__9E2397E0CED12EFC");

            entity.ToTable("log");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.LogDate).HasColumnName("log_date");
            entity.Property(e => e.LogDescription).HasColumnName("log_description");
            entity.Property(e => e.LogTitle)
                .HasMaxLength(50)
                .HasColumnName("log_title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__log__user_id__412EB0B6");

            entity.HasMany(d => d.Categories).WithMany(p => p.Logs)
                .UsingEntity<Dictionary<string, object>>(
                    "LogCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__log_categ__categ__46E78A0C"),
                    l => l.HasOne<Log>().WithMany()
                        .HasForeignKey("LogId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__log_categ__log_i__45F365D3"),
                    j =>
                    {
                        j.HasKey("LogId", "CategoryId").HasName("PK__log_cate__C377797BBF876D85");
                        j.ToTable("log_category");
                        j.IndexerProperty<int>("LogId").HasColumnName("log_id");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__760965CC2E8D6966");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F15473BBD");

            entity.ToTable("user");

            entity.HasIndex(e => e.UserEmail, "UQ__user__B0FBA2122800B4AB").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .HasColumnName("user_password");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__role_id__3E52440B");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_acc__3214EC07748F45A1");

            entity.ToTable("user_account");

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
