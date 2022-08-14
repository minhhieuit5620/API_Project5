using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API_Project5.Models;

namespace API_Project5.Models
{
    public partial class Iterior_DesignContext : DbContext
    {
        //public Iterior_DesignContext()
        //{
        //}

        public Iterior_DesignContext(DbContextOptions<Iterior_DesignContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryNew> CategoryNew { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProduct { get; set; }
        public virtual DbSet<CategoryProject> CategoryProject { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<LienHe> LienHe { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Rols> Rols { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<intruduce> Intruduces { get; set; }
        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-I3H4F8O\\MINHHIEU;Database=Iterior_Design;Integrated Security=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryNew>(entity =>
            {
                entity.HasKey(e => e.IdCategoryNew);

                entity.ToTable("Category_new");

                entity.Property(e => e.IdCategoryNew).HasColumnName("Id_category_new");

                entity.Property(e => e.DescriptionCateNew)
                    .HasColumnName("Description_cate_new")
                    .HasMaxLength(4000);

                entity.Property(e => e.ImageCateNew)
                    .HasColumnName("Image_cate_new")
                    .HasMaxLength(250);

                entity.Property(e => e.NameCategoryNew)
                    .HasColumnName("Name_category_new")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.ToTable("Category_product");

                entity.Property(e => e.ImageCate)
                    .HasColumnName("Image_Cate")
                    .HasMaxLength(250);

                entity.Property(e => e.NameCate)
                    .HasColumnName("Name_Cate")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<CategoryProject>(entity =>
            {
                entity.HasKey(e => e.IdCateProject);

                entity.ToTable("Category_project");

                entity.Property(e => e.IdCateProject).HasColumnName("Id_cate_project");

                entity.Property(e => e.DescriptionCateProject)
                    .HasColumnName("Description_cate_project")
                    .HasMaxLength(4000);

                entity.Property(e => e.ImageCateProject)
                    .HasColumnName("Image_cate_project")
                    .HasMaxLength(250);

                entity.Property(e => e.NameCateProject)
                    .HasColumnName("Name_cate_project")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<intruduce>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.title).HasMaxLength(50);

                entity.Property(e => e.description).HasMaxLength(4000);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.AddressCus).HasMaxLength(500);

                entity.Property(e => e.EmailCus).HasMaxLength(250);

                entity.Property(e => e.NameCus).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            modelBuilder.Entity<LienHe>(entity =>
            {
                entity.ToTable("lienHe");

                entity.Property(e => e.Id).HasColumnName("id");
              
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Phone)
                   .HasColumnName("phone")
                   .HasMaxLength(20);
                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250);

                entity.Property(e => e.NameCus)
                    .HasColumnName("nameCus")
                    .HasMaxLength(50);

                entity.Property(e => e.NoiDung)
                    .HasColumnName("noiDung")
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.IdNew);

                entity.Property(e => e.IdNew).HasColumnName("Id_new");

                entity.Property(e => e.AvaterNew)
                    .HasColumnName("Avater_new")
                    .HasMaxLength(250);

                entity.Property(e => e.DescriptionNew)
                    .HasColumnName("Description_new")
                    .HasMaxLength(4000);

                entity.Property(e => e.IdCategoryNew).HasColumnName("Id_Category_new");

                entity.Property(e => e.ImageNew)
                    .HasColumnName("Image_new")
                    .HasMaxLength(250);

                entity.Property(e => e.NameNew)
                    .HasColumnName("Name_new")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.IdOrderDetail);

                entity.Property(e => e.NameProduct).HasMaxLength(250);

                entity.Property(e => e.Note).HasMaxLength(4000);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.DayOrder).HasColumnType("date");

                entity.Property(e => e.NameCus).HasMaxLength(250);

                entity.Property(e => e.Note).HasMaxLength(4000);
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.NameProcess)
                    .HasColumnName("Name_process")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.IdProject);

                entity.Property(e => e.IdProject).HasColumnName("Id_project");

                entity.Property(e => e.AvatarProject)
                    .HasColumnName("Avatar_project")
                    .HasMaxLength(250);

                entity.Property(e => e.DateFinish)
                    .HasColumnName("Date_finish")
                    .HasColumnType("date");

                entity.Property(e => e.DateStart)
                    .HasColumnName("Date_start")
                    .HasColumnType("date");

                entity.Property(e => e.DescriptionProject)
                    .HasColumnName("Description_project").HasMaxLength(4000);

                entity.Property(e => e.IdCategoryProject).HasColumnName("Id_category_project");

                entity.Property(e => e.IdCustomer).HasColumnName("Id_Customer");

                entity.Property(e => e.ImageProject)
                    .HasColumnName("Image_project")
                    .HasMaxLength(250);

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.NameCustomer)
                    .HasColumnName("Name_Customer")
                    .HasMaxLength(50);

                entity.Property(e => e.NameProject)
                    .HasColumnName("Name_project")
                    .HasMaxLength(500);

                entity.Property(e => e.PriceProject).HasColumnName("Price_project");
            });

            modelBuilder.Entity<Rols>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.Permission).HasMaxLength(250);
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.ShipId);

                entity.Property(e => e.ShipId).HasColumnName("shipId");

                entity.Property(e => e.CardNumber).HasColumnName("cardNumber");
                entity.Property(e => e.idOrder).HasColumnName("idOrder");

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customerEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customerName")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerPhone)
                    .HasColumnName("customerPhone")
                     .HasMaxLength(15);
                entity.Property(e => e.IssueDate)
                    .HasColumnName("issueDate")
                    .HasColumnType("date");

                entity.Property(e => e.NameOnCard)
                    .HasColumnName("nameOnCard")
                    .HasMaxLength(50);
                entity.Property(e => e.address)
                    .HasColumnName("address")
                    .HasMaxLength(250);
                entity.Property(e => e.Note)
                    .HasColumnName("note")
                     .HasMaxLength(4000);

                entity.Property(e => e.Payments)
                    .IsRequired()
                    .HasColumnName("payments")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.Address).HasMaxLength(250);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.DayStart).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<API_Project5.Models.intruduce> introduce { get; set; }
    }
}
