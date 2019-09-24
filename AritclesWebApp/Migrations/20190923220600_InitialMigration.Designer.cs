﻿// <auto-generated />
using System;
using AritclesWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AritclesWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190923220600_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AritclesWebApp.Models.Class.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AritclesWebApp.Models.Class.Posts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("PostedAt");

                    b.Property<string>("Text");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Posts");
                });

            modelBuilder.Entity("AritclesWebApp.Models.Class.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Language")
                        .HasMaxLength(2);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("AritclesWebApp.Models.Class.TagsArticles", b =>
                {
                    b.Property<int>("TagsId");

                    b.Property<int>("ArticlesId");

                    b.Property<int>("Id");

                    b.HasKey("TagsId", "ArticlesId");

                    b.HasIndex("ArticlesId");

                    b.ToTable("TagsArticles");
                });

            modelBuilder.Entity("AritclesWebApp.Models.Class.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Bio");

                    b.Property<string>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Photo")
                        .HasMaxLength(350);

                    b.Property<string>("Token");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Bio = "",
                            CreatedAt = "24.9.2019 01:06:00",
                            Email = "admin@webarticles.com",
                            Name = "Admin",
                            Password = "@dM!n123",
                            Photo = "",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("AritclesWebApp.Models.Class.Articles", b =>
                {
                    b.HasBaseType("AritclesWebApp.Models.Class.Posts");

                    b.Property<bool>("Active");

                    b.Property<bool>("AllowsComments");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Photo")
                        .HasMaxLength(350);

                    b.Property<string>("SubTitle");

                    b.Property<string>("ThumbnailPhoto")
                        .HasMaxLength(350);

                    b.Property<int>("UserId");

                    b.HasDiscriminator().HasValue("Articles");
                });

            modelBuilder.Entity("AritclesWebApp.Models.Class.Comments", b =>
                {
                    b.HasBaseType("AritclesWebApp.Models.Class.Posts");

                    b.Property<bool>("Active")
                        .HasColumnName("Comments_Active");

                    b.Property<int>("ArticleId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Ip");

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.Property<int?>("ParentId");

                    b.HasDiscriminator().HasValue("Comments");
                });

            modelBuilder.Entity("AritclesWebApp.Models.Class.TagsArticles", b =>
                {
                    b.HasOne("AritclesWebApp.Models.Class.Articles", "Article")
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AritclesWebApp.Models.Class.Tags", "Tag")
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}