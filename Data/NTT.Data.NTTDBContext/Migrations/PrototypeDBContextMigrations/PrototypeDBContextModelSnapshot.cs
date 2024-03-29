﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTT.Data.NTTDBContext.NTTContexts;

namespace NTT.Data.NTTDBContext.Migrations.PrototypeDBContextMigrations
{
    [DbContext(typeof(PrototypeDBContext))]
    partial class PrototypeDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<long>("DepartmentID")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long?>("UpdateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.CourseAssignment", b =>
                {
                    b.Property<long>("CourseID")
                        .HasColumnType("bigint");

                    b.Property<long>("InstructorID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseID", "InstructorID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseAssignment");
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<long?>("CreateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("InstructorID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InstructorID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.Enrollment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<long>("StudentID")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.Instructor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long?>("UpdateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.OfficeAssignment", b =>
                {
                    b.Property<long>("InstructorID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long?>("UpdateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InstructorID");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long?>("UpdateById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EnrollmentDate = new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Carson",
                            LastName = "Alexander"
                        },
                        new
                        {
                            Id = 2L,
                            EnrollmentDate = new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Meredith",
                            LastName = "Alonso"
                        },
                        new
                        {
                            Id = 3L,
                            EnrollmentDate = new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Arturo",
                            LastName = "Anand"
                        },
                        new
                        {
                            Id = 4L,
                            EnrollmentDate = new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Gytis",
                            LastName = "Barzdukas"
                        },
                        new
                        {
                            Id = 5L,
                            EnrollmentDate = new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Yan",
                            LastName = "Li"
                        },
                        new
                        {
                            Id = 6L,
                            EnrollmentDate = new DateTime(2011, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Peggy",
                            LastName = "Justice"
                        },
                        new
                        {
                            Id = 7L,
                            EnrollmentDate = new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Laura",
                            LastName = "Norman"
                        },
                        new
                        {
                            Id = 8L,
                            EnrollmentDate = new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Nino",
                            LastName = "Olivetto"
                        });
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.Course", b =>
                {
                    b.HasOne("NTT.Data.EntityModel.PrototypeEntity.Department", null)
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.CourseAssignment", b =>
                {
                    b.HasOne("NTT.Data.EntityModel.PrototypeEntity.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NTT.Data.EntityModel.PrototypeEntity.Instructor", "Instructor")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.Department", b =>
                {
                    b.HasOne("NTT.Data.EntityModel.PrototypeEntity.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorID");
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.Enrollment", b =>
                {
                    b.HasOne("NTT.Data.EntityModel.PrototypeEntity.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NTT.Data.EntityModel.PrototypeEntity.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NTT.Data.EntityModel.PrototypeEntity.OfficeAssignment", b =>
                {
                    b.HasOne("NTT.Data.EntityModel.PrototypeEntity.Instructor", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("NTT.Data.EntityModel.PrototypeEntity.OfficeAssignment", "InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
