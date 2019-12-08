namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NTT.Data.EntityModel.PrototypeEntity;
    using System;

    [DBContext(Name = "PrototypeDBContext")]
    public class StudentMap : TrackingSystemEntityTypeConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasData(
                 new
                 {
                     Id = (long)1,
                     FirstMidName = "Carson",
                     LastName = "Alexander",
                     EnrollmentDate = DateTime.Parse("2010-09-01")
                 },
                new
                {
                    Id = (long)2,
                    FirstMidName = "Meredith",
                    LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new
                {
                    Id = (long)3,
                    FirstMidName = "Arturo",
                    LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new
                {
                    Id = (long)4,
                    FirstMidName = "Gytis",
                    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new
                {
                    Id = (long)5,
                    FirstMidName = "Yan",
                    LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new
                {
                    Id = (long)6,
                    FirstMidName = "Peggy",
                    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01")
                },
                new
                {
                    Id = (long)7,
                    FirstMidName = "Laura",
                    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new
                {
                    Id = (long)8,
                    FirstMidName = "Nino",
                    LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01")
                }
                );
        }
    }
}
