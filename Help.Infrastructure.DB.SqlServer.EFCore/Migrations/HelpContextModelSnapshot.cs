﻿// <auto-generated />
using System;
using Help.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Help.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    [DbContext(typeof(HelpContext))]
    partial class HelpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ApplicantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ExpertId")
                        .HasColumnType("bigint");

                    b.Property<long>("HelpRequestId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<short>("Score")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("HelpRequestId");

                    b.HasIndex("ParentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.HelpRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ApplicantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<double>("ProposedPrice")
                        .HasColumnType("float");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StatusId");

                    b.ToTable("HelpRequests");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.HelpRequestPicture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("HelpRequestId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HelpRequestId");

                    b.ToTable("HelpRequestPictures");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.HelpRequestStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("HelpRequestStatuses");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Proposal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("ExpertId")
                        .HasColumnType("bigint");

                    b.Property<long>("HelpRequestId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<double>("SuggestedPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("SuggestedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HelpRequestId");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("KeyWords")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<long>("PictureId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.ServiceCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceCategories");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.ServicePicture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("ServicePictures");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("ExpertId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<short>("Level")
                        .HasColumnType("smallint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Category", b =>
                {
                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Comment", b =>
                {
                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.HelpRequest", "HelpRequest")
                        .WithMany("Comments")
                        .HasForeignKey("HelpRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HelpRequest");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.HelpRequest", b =>
                {
                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.Service", "Service")
                        .WithMany("HelpRequests")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.HelpRequestStatus", "Status")
                        .WithMany("HelpRequests")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.HelpRequestPicture", b =>
                {
                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.HelpRequest", "HelpRequest")
                        .WithMany("Pictures")
                        .HasForeignKey("HelpRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HelpRequest");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Proposal", b =>
                {
                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.HelpRequest", "HelpRequest")
                        .WithMany("Proposals")
                        .HasForeignKey("HelpRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HelpRequest");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.ServiceCategory", b =>
                {
                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.Category", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.Service", "Service")
                        .WithMany("Categories")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.ServicePicture", b =>
                {
                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.Service", "Service")
                        .WithOne("Picture")
                        .HasForeignKey("Help.Domain.Core.ServiceAgg.Entities.ServicePicture", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Skill", b =>
                {
                    b.HasOne("Help.Domain.Core.ServiceAgg.Entities.Service", "Service")
                        .WithMany("Skills")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Category", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Comment", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.HelpRequest", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Pictures");

                    b.Navigation("Proposals");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.HelpRequestStatus", b =>
                {
                    b.Navigation("HelpRequests");
                });

            modelBuilder.Entity("Help.Domain.Core.ServiceAgg.Entities.Service", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("HelpRequests");

                    b.Navigation("Picture")
                        .IsRequired();

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
