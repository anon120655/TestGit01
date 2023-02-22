using System;
using System.Collections.Generic;
using APIDotNet7.Infrastructure.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace APIDotNet7.Infrastructure.Data.ConnectionContext;

public partial class WBContext : DbContext
{
    public WBContext()
    {
    }

    public WBContext(DbContextOptions<WBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I8ALPVV;Database=WebboardDB;MultipleActiveResultSets=True;persist security info=false;user id=sa;password=Ibusiness02;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFCAE425DE8F");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Comment1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Comment");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.CommentCreateUsers)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__CreateU__4BAC3F29");

            entity.HasOne(d => d.Topic).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__TopicId__3B75D760");

            entity.HasOne(d => d.UpdateUser).WithMany(p => p.CommentUpdateUsers)
                .HasForeignKey(d => d.UpdateUserId)
                .HasConstraintName("FK__Comment__UpdateU__4CA06362");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F5D63239928");

            entity.ToTable("Topic");

            entity.Property(e => e.TopicId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Topic1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Topic");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.TopicCreateUsers)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Topic__CreateUse__49C3F6B7");

            entity.HasOne(d => d.UpdateUser).WithMany(p => p.TopicUpdateUsers)
                .HasForeignKey(d => d.UpdateUserId)
                .HasConstraintName("FK__Topic__UpdateUse__4AB81AF0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C7FD145D9");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
