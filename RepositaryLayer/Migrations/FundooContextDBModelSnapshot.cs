﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositary_Layer.FundooContext;

namespace RepositaryLayer.Migrations
{
    [DbContext(typeof(FundooContextDB))]
    partial class FundooContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepositaryLayer.Entites.Label", b =>
                {
                    b.Property<int>("LabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LabelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NoteId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LabelId");

                    b.HasIndex("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("RepositaryLayer.Entites.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchieve")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemainder")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTrash")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RemainderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("colour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Repositary_Layer.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RepositaryLayer.Entites.Label", b =>
                {
                    b.HasOne("RepositaryLayer.Entites.Note", "Note")
                        .WithMany("Labels")
                        .HasForeignKey("NoteId");

                    b.HasOne("Repositary_Layer.Entities.User", "User")
                        .WithMany("Labels")
                        .HasForeignKey("UserId");

                    b.Navigation("Note");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RepositaryLayer.Entites.Note", b =>
                {
                    b.HasOne("Repositary_Layer.Entities.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RepositaryLayer.Entites.Note", b =>
                {
                    b.Navigation("Labels");
                });

            modelBuilder.Entity("Repositary_Layer.Entities.User", b =>
                {
                    b.Navigation("Labels");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
