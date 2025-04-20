using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_SocialMediaProject.Models;

public partial class CiitcoderDbContext : DbContext
{
    public CiitcoderDbContext()
    {
    }

    public CiitcoderDbContext(DbContextOptions<CiitcoderDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblcontentUserComment> TblcontentUserComments { get; set; }

    public virtual DbSet<TblcontentVideoLike> TblcontentVideoLikes { get; set; }

    public virtual DbSet<TblcontentVideoVisit> TblcontentVideoVisits { get; set; }

    public virtual DbSet<Tbltopic> Tbltopics { get; set; }

    public virtual DbSet<TbltopicContent> TbltopicContents { get; set; }

    public virtual DbSet<Tbluser> Tblusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SHIVARAJ;Database =CIITCoderDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblcontentUserComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__tblconte__E79576873FE97DC6");

            entity.ToTable("tblcontent_user_comments");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Comment)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.CommentDate)
                .HasColumnType("datetime")
                .HasColumnName("comment_date");
            entity.Property(e => e.ContentId).HasColumnName("content_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Content).WithMany(p => p.TblcontentUserComments)
                .HasForeignKey(d => d.ContentId)
                .HasConstraintName("fkcontentid");

            entity.HasOne(d => d.User).WithMany(p => p.TblcontentUserComments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkcsdfontentid");
        });

        modelBuilder.Entity<TblcontentVideoLike>(entity =>
        {
            entity.HasKey(e => e.LikeId).HasName("PK__tblconte__992C793010CC63FB");

            entity.ToTable("tblcontent_video_likes");

            entity.Property(e => e.LikeId).HasColumnName("like_id");
            entity.Property(e => e.ContentId).HasColumnName("content_id");
            entity.Property(e => e.IsLike).HasColumnName("is_like");
            entity.Property(e => e.LikeDate)
                .HasColumnType("datetime")
                .HasColumnName("like_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Content).WithMany(p => p.TblcontentVideoLikes)
                .HasForeignKey(d => d.ContentId)
                .HasConstraintName("fkcontendftid");

            entity.HasOne(d => d.User).WithMany(p => p.TblcontentVideoLikes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkcsdfontendfdftid");
        });

        modelBuilder.Entity<TblcontentVideoVisit>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PK__tblconte__375A75E1448E3167");

            entity.ToTable("tblcontent_video_visits");

            entity.Property(e => e.VisitId).HasColumnName("visit_id");
            entity.Property(e => e.ContentId).HasColumnName("content_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VisitDate)
                .HasColumnType("datetime")
                .HasColumnName("visit_date");

            entity.HasOne(d => d.Content).WithMany(p => p.TblcontentVideoVisits)
                .HasForeignKey(d => d.ContentId)
                .HasConstraintName("fkcodfntendftid");

            entity.HasOne(d => d.User).WithMany(p => p.TblcontentVideoVisits)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkcsdfodfntendfdftid");
        });

        modelBuilder.Entity<Tbltopic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__tbltopic__D5DAA3E921983FD9");

            entity.ToTable("tbltopics");

            entity.HasIndex(e => e.TopicName, "UQ__tbltopic__54BAE5ECADF8544D").IsUnique();

            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.TopicName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("topic_name");
        });

        modelBuilder.Entity<TbltopicContent>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK__tbltopic__655FE5103EA09792");

            entity.ToTable("tbltopic_contents");

            entity.Property(e => e.ContentId).HasColumnName("content_id");
            entity.Property(e => e.ContentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("content_name");
            entity.Property(e => e.CoverPhoto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cover_photo");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("video_url");

            entity.HasOne(d => d.Topic).WithMany(p => p.TbltopicContents)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("dftpi");
        });

        modelBuilder.Entity<Tbluser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tblusers__B9BE370FA3B5FD24");

            entity.ToTable("tblusers");

            entity.HasIndex(e => e.EmailAddress, "UQ__tblusers__20C6DFF5D415B0DC").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_address");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.JoiningDate)
                .HasColumnType("datetime")
                .HasColumnName("joining_date");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mobile_number");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPhoto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_photo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
